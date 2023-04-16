using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Vehicle_Management
{
    public partial class aboutForm : Form
    {
        public aboutForm()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try {
                var ps = new ProcessStartInfo("http://www.aeonlabs.solutions")
                {
                    UseShellExecute = true,
                    Verb = "open"
                };
                Process.Start(ps);
            }
            catch (Win32Exception)
            {
                Process.Start("IExplore.exe", "http://www.aeonlabs.solutions");
            }

        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutForm_Load(object sender, EventArgs e)
        {
            string currentVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            version_txt.Text = "version " + currentVersion;

        }
    }
}
