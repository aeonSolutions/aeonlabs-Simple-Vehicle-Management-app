using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Invoice_Management
{
    public partial class settingsForm : Form
    {
        private static String libraryPath = String.Format("{0}\\library\\", Environment.CurrentDirectory);
        private string filename = @libraryPath + @"settings.cfg";
        private string filenameUpdate = @libraryPath + @"update.cfg";
        public settingsForm()
        {
            InitializeComponent();

            StreamReader readme = null;
            StreamReader readmeU = null;

            try
            {
                readme = File.OpenText(filename);
                string value= readme.ReadToEnd();
                
                readmeU = File.OpenText(filenameUpdate);
                string valueUpdate = readmeU.ReadToEnd();

                int n, nu;
                bool isNumeric = int.TryParse(value, out n);
                bool isNumericU = int.TryParse(valueUpdate, out nu);

                if (isNumeric) {
                    reminderTxt.Text = value;
                }
                else
                {
                    reminderTxt.Text = "0";
                }

                if (isNumericU)
                {
                    if (nu == 0)
                    {
                        checkUpdatesChk.Checked = false;
                    }
                    else {
                        checkUpdatesChk.Checked = true;
                    }
                }
                else
                {
                    checkUpdatesChk.Checked = false;
                }

            }
            // will return an invalid file name error
            catch (Exception errorMsg)
            {
                reminderTxt.Text = "0";
                checkUpdatesChk.Checked = false;
            }
            finally
            {
                if (readme != null)
                {
                    readme.Close();
                }
                if (readmeU != null)
                {
                    readmeU.Close();
                }
            }

        }


        private void settingsForm_Load(object sender, EventArgs e)
        {

        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            // save MOT reminder settings
            int n;
            string value = reminderTxt.Text;

            bool isNumeric = int.TryParse(reminderTxt.Text, out n);
            if (!isNumeric)
            {
                value = "0";
            }
            try {
                System.IO.File.WriteAllText(@filename, value);
            }
            catch (Exception ex) { 
           
            }

            // save update settings 
            value = "";
            if (checkUpdatesChk.Checked) {
                value = "1";
            } else {
                value = "0";
            }
            try
            {
                System.IO.File.WriteAllText(@filenameUpdate, value);
            }
            catch (Exception ex)
            {

            }

            this.Close();
        }
    }
}
