using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vlc.DotNet.Core;
using Vlc.DotNet.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Networking.Init();
        }

        private void OnVlcControlNeedLibDirectory(object sender, VlcLibDirectoryNeededEventArgs e)
        {
            var currentAssembly = Assembly.GetEntryAssembly();
            var currentDirectory = new FileInfo(currentAssembly.Location).DirectoryName;
            // Default installation path of VideoLAN.LibVLC.Windows
            e.VlcLibDirectory = new DirectoryInfo(Path.Combine(currentDirectory, "libvlc", IntPtr.Size == 4 ? "win-x86" : "win-x64"));

            if (!e.VlcLibDirectory.Exists)
            {
                var folderBrowserDialog = new FolderBrowserDialog();
                folderBrowserDialog.Description = "Select Vlc libraries folder.";
                folderBrowserDialog.RootFolder = Environment.SpecialFolder.Desktop;
                folderBrowserDialog.ShowNewFolderButton = true;
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    e.VlcLibDirectory = new DirectoryInfo(folderBrowserDialog.SelectedPath);
                }
            }
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            //Networking.Send("GetSong");
            //labelSongName.Text = Networking.Read();
            Networking.Send("Play");
        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            Networking.Send("Pause");
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            Networking.Send("Stop");
        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            Networking.Send("PreviousSong");
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            Networking.Send("NextSong");
        }
    }
}
