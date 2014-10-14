using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using Vlc.DotNet.Core;
using Vlc.DotNet.Core.Interops.Signatures.Rincewind;

namespace Vlc.DotNet.Core.Interops.Tests
{
    [TestClass]
    public class RincewindUnitTest
    {
        private readonly DirectoryInfo myVlcDirectory;

        public RincewindUnitTest()
        {
            var currentAssembly = Assembly.GetAssembly(typeof(RincewindUnitTest));
            var basePath = Path.Combine(currentAssembly.Location, @"..\..\..\..\..\vlc\");
            if (AssemblyName.GetAssemblyName(currentAssembly.Location).ProcessorArchitecture == ProcessorArchitecture.X86)
                myVlcDirectory = new DirectoryInfo(Path.Combine(basePath, "x86"));
            else
                myVlcDirectory = new DirectoryInfo(Path.Combine(basePath, "x64"));
        }

        [TestMethod]
        public void TestManager()
        {
            using (var manager = VlcRincewindManager.GetInstance(new DirectoryInfo(Path.Combine(myVlcDirectory.FullName, "Rincewind"))))
            {
                Assert.IsNotNull(manager.VlcVersion.Codename);
                Assert.AreEqual(manager.VlcVersion, VlcVersions.Rincewind);
                var instance = manager.CreateNewInstance(new string[0]);
                Assert.AreNotEqual(instance, IntPtr.Zero);


                var mediaInstance = manager.CreateNewMediaFromPath(instance, @"D:\Mashur & Kevlar - Alone (I Am Robot Flip).mp3");
                Assert.AreNotEqual(mediaInstance, IntPtr.Zero);
                var mediaPlayerInstance = manager.CreateMediaPlayerFromMedia(mediaInstance);
                Assert.AreNotEqual(mediaPlayerInstance, IntPtr.Zero);
                manager.ReleaseMedia(mediaInstance);

                var mediaPlayerEventManager = manager.GetMediaPlayerEventManager(mediaPlayerInstance);
                Assert.AreNotEqual(mediaPlayerEventManager, IntPtr.Zero);

                var result = manager.Play(mediaPlayerInstance);
                Assert.IsTrue(result);
                Thread.Sleep(1000);
                manager.Stop(mediaPlayerInstance);
                manager.ReleaseMediaPlayer(mediaPlayerInstance);


                manager.ReleaseInstance(instance);
            }
        }
    }
}
