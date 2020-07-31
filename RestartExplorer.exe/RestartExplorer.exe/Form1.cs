using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace RestartExplorer.exe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //BY gmaestre002@gmail.com
        }

        private void btnKill_Click(object sender, EventArgs e)
        {
            Process processo = new Process();

            processo.StartInfo = new ProcessStartInfo("taskkill", "/F /IM explorer.exe");

            processo.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

            processo.Start();

            processo.WaitForExit();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Process.Start(Path.Combine(Environment.GetEnvironmentVariable("windir"), "explorer.exe"));
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            try
            {
                Process processo = new Process();

                processo.StartInfo = new ProcessStartInfo("taskkill", "/F /IM explorer.exe");

                processo.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

                processo.Start();

                processo.WaitForExit();

                Process.Start(Path.Combine(Environment.GetEnvironmentVariable("windir"), "explorer.exe"));

            }
            catch (Exception a)
            {
                MessageBox.Show(a.ToString() + "\n Contact the Progammer", "ERROR");
            }
        }

        private void chkStartup_CheckedChanged(object sender, EventArgs e)
        {
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey
            ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (chkStartup.Checked)
            {
                registryKey.SetValue("RestartExplorer.exe", Application.ExecutablePath);
            }
            else
            {
                registryKey.DeleteValue("RestartExplorer.exe");
            }
        }
    }
}
