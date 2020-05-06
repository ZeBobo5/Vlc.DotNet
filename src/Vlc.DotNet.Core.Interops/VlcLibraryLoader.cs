using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
#if NETSTANDARD1_3
using System.Linq;
#endif
using System.Reflection;
using System.Runtime.InteropServices;

namespace Vlc.DotNet.Core.Interops
{
    /// <summary>
    /// This class loads the required libvlc libraries.
    /// Only one instance per directory will be created.
    ///
    /// Use <see cref="GetOrCreateLoader" /> and <see cref="ReleaseLoader"/> to get a VlcLibraryLoader instance and release it properly.
    /// Do not call Dispose() by yourself, it will be called as needed by ReleaseLoader.
    /// </summary>
    internal class VlcLibraryLoader: IDisposable
    {
        private static Dictionary<string, VlcLibraryLoader> myLoaderInstances = new Dictionary<string, VlcLibraryLoader>();

        private readonly DirectoryInfo myDynamicLinkLibrariesPath;

        /// <summary>
        /// Number of objects that are using this loader
        /// </summary>
        private int myRefCount;

        private IntPtr myLibGccDllHandle;
        private IntPtr myLibVlcDllHandle;
        private IntPtr myLibVlcCoreDllHandle;

        /// <summary>
        /// Caches of the delegates that were resolved from the libvlc.
        /// These delegates are cast to the correct delegate type when a query is made
        /// </summary>
        private readonly Dictionary<string, object> myInteropDelegates = new Dictionary<string, object>();

        /// <summary>
        /// A lock object for working with myInteropDelegates
        /// </summary>
        private readonly object _myInteropDelegatesLockObject = new object();

        private VlcLibraryLoader(DirectoryInfo dynamicLinkLibrariesPath)
        {
            myDynamicLinkLibrariesPath = dynamicLinkLibrariesPath;
            myRefCount = 1;

            var libGccDllPath = Path.Combine(dynamicLinkLibrariesPath.FullName, "libgcc_s_seh-1.dll");
            if (File.Exists(libGccDllPath))
            {
                myLibGccDllHandle = Win32Interops.LoadLibrary(libGccDllPath);
                if (myLibGccDllHandle == IntPtr.Zero)
                    throw new Win32Exception(Marshal.GetLastWin32Error());
            }

            var libVlcCoreDllPath = Path.Combine(dynamicLinkLibrariesPath.FullName, "libvlccore.dll");
            if (!File.Exists(libVlcCoreDllPath))
                throw new FileNotFoundException();
            myLibVlcCoreDllHandle = Win32Interops.LoadLibrary(libVlcCoreDllPath);
            if (myLibVlcCoreDllHandle == IntPtr.Zero)
                throw new Win32Exception(Marshal.GetLastWin32Error());

            var libVlcDllPath = Path.Combine(dynamicLinkLibrariesPath.FullName, "libvlc.dll");
            if (!File.Exists(libVlcDllPath))
                throw new FileNotFoundException();
            myLibVlcDllHandle = Win32Interops.LoadLibrary(libVlcDllPath);
            if (myLibVlcDllHandle == IntPtr.Zero)
                throw new Win32Exception(Marshal.GetLastWin32Error());
        }

        internal T GetInteropDelegate<T>()
        {
            string vlcFunctionName = null;
            try
            {
#if NETSTANDARD1_3
                var attrs = typeof(T).GetTypeInfo().GetCustomAttributes(typeof(LibVlcFunctionAttribute), false).ToArray();
#else
                var attrs = typeof(T).GetCustomAttributes(typeof(LibVlcFunctionAttribute), false);
#endif
                if (attrs.Length == 0)
                    throw new Exception("Could not find the LibVlcFunctionAttribute.");
                var attr = (LibVlcFunctionAttribute)attrs[0];
                vlcFunctionName = attr.FunctionName;

                lock (this._myInteropDelegatesLockObject)
                {
                    if (myInteropDelegates.ContainsKey(vlcFunctionName))
                    {
                        return (T)myInteropDelegates[attr.FunctionName];
                    }

                    var procAddress = Win32Interops.GetProcAddress(myLibVlcDllHandle, attr.FunctionName);
                    if (procAddress == IntPtr.Zero)
                        throw new Win32Exception();

                    var delegateForFunctionPointer = MarshalHelper.GetDelegateForFunctionPointer<T>(procAddress);

                    myInteropDelegates[attr.FunctionName] = delegateForFunctionPointer;

                    return delegateForFunctionPointer;
                }
            }
            catch (Win32Exception e)
            {
                throw new MissingMethodException(string.Format("The address of the function '{0}' does not exist in libvlc library.", vlcFunctionName), e);
            }
        }

        void IDisposable.Dispose()
        {
            if (myLibVlcDllHandle != IntPtr.Zero)
            {
                Win32Interops.FreeLibrary(myLibVlcDllHandle);
                myLibVlcDllHandle = IntPtr.Zero;
            }
            if (myLibVlcCoreDllHandle != IntPtr.Zero)
            {
                Win32Interops.FreeLibrary(myLibVlcCoreDllHandle);
                myLibVlcCoreDllHandle = IntPtr.Zero;
            }
            if (myLibGccDllHandle != IntPtr.Zero)
            {
                Win32Interops.FreeLibrary(myLibGccDllHandle);
                myLibGccDllHandle = IntPtr.Zero;
            }
        }

        /// <summary>
        /// Creates a new VlcLibraryLoader, or get the existing one for that folder from the dictionary (increment its reference count).
        /// </summary>
        /// <param name="dynamicLinkLibrariesPath">The path from the dictionary</param>
        /// <returns>The loader</returns>
        public static VlcLibraryLoader GetOrCreateLoader(DirectoryInfo dynamicLinkLibrariesPath)
        {
            if (!dynamicLinkLibrariesPath.Exists)
                throw new DirectoryNotFoundException();

            lock (myLoaderInstances)
            {
                if (myLoaderInstances.ContainsKey(dynamicLinkLibrariesPath.FullName))
                {
                    var instance = myLoaderInstances[dynamicLinkLibrariesPath.FullName];
                    instance.myRefCount++;
                    return instance;
                }

                var returnedInstance = new VlcLibraryLoader(dynamicLinkLibrariesPath);
                myLoaderInstances[dynamicLinkLibrariesPath.FullName] = returnedInstance;
                return returnedInstance;
            }
        }

        /// <summary>
        /// Decrements the reference counter of the specified loader.
        /// If this reference counter reaches 0, it is destroyed
        /// </summary>
        /// <param name="loader"></param>
        public static void ReleaseLoader(VlcLibraryLoader loader)
        {
            lock (myLoaderInstances)
            {
                loader.myRefCount--;
                if (loader.myRefCount == 0)
                {
                    ((IDisposable)loader).Dispose();
                    myLoaderInstances.Remove(loader.myDynamicLinkLibrariesPath.FullName);
                }
            }
        }
    }
}