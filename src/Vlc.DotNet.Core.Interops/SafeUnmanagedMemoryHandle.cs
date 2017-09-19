namespace Vlc.DotNet.Core.Interops
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security.Permissions;

    /// <summary>
    /// Contains a handle that is safely released when not used anymore.
    /// </summary>
    /// <remarks>Inspired from code at https://msdn.microsoft.com/en-us/library/microsoft.win32.safehandles.safehandlezeroorminusoneisinvalid(v=vs.80).aspx#code-snippet-4 </remarks>
    [SecurityPermission(SecurityAction.Demand, UnmanagedCode = true)]
    internal sealed class SafeUnmanagedMemoryHandle : SafeHandle
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SafeUnmanagedMemoryHandle"/> class by providing the handle to be stored.
        /// </summary>
        /// <param name="preexistingHandle">The handle that is stored by this instance at initialization.</param>
        internal SafeUnmanagedMemoryHandle(IntPtr preexistingHandle)
            : base(IntPtr.Zero, true)
        {
            this.SetHandle(preexistingHandle);
        }

        /// <summary>
        /// Releases the memory associated to this handle
        /// </summary>
        /// <returns>A value indicating whether the release operation was successful</returns>
        protected override bool ReleaseHandle()
        {
            if (this.handle == IntPtr.Zero)
            {
                return false;
            }

            // Free the handle.
            Marshal.FreeHGlobal(this.handle);

            // Set the handle to zero.
            this.handle = IntPtr.Zero;

            // Return success.
            return true;
        }

        /// <summary>En cas de substitution dans une classe dérivée, obtient une valeur indiquant si la valeur du handle n'est pas valide.</summary>
        /// <returns>true si la valeur du handle n'est pas valide, sinon false.</returns>
        public override bool IsInvalid => this.handle == IntPtr.Zero;
    }
}