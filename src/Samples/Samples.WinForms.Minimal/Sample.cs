﻿using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Samples.WinForms.Minimal
{
    public partial class Sample : Form
    {
        public Sample()
        {
            InitializeComponent();
            vlcControl.Play(new Uri("http://download.blender.org/peach/bigbuckbunny_movies/big_buck_bunny_480p_surround-fix.avi"));
        }

        /// <summary>
        /// When the Vlc control needs to find the location of the libvlc.dll.
        /// You could have set the VlcLibDirectory in the designer, but for this sample, we are in AnyCPU mode, and we don't know the process bitness.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void vlcControl_VlcLibDirectoryNeeded(object sender, Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs e)
        {
            var currentAssembly = Assembly.GetEntryAssembly();
            var currentDirectory = new FileInfo(currentAssembly.Location).DirectoryName;
            // Default libraries are stored here, but they are old, don't use them.
            // We need a better way to install them, see https://github.com/ZeBobo5/Vlc.DotNet/issues/288
            if (IntPtr.Size == 4)
                e.VlcLibDirectory = new DirectoryInfo(Path.Combine(currentDirectory, @"..\..\..\..\..\lib\x86\"));
            else
                e.VlcLibDirectory = new DirectoryInfo(Path.Combine(currentDirectory, @"..\..\..\..\..\lib\x64\"));
        }
    }
}
