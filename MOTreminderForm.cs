using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Vehicle_Management;

namespace Invoice_Management
{
    public partial class MOTreminderForm : Form
    {
        private List<string[]> reminders = null;

        public MOTreminderForm()
        {
            InitializeComponent();
            loadReminders();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void SendBtn_Click(object sender, EventArgs e)
        {
            if (customersList.SelectedIndex>-1) {
                  var psi = new ProcessStartInfo
                    {
                        FileName = "https://api.whatsapp.com/send?phone=" + reminders.ElementAt(customersList.SelectedIndex)[1],
                        UseShellExecute = true
                    };
                    Process.Start(psi);

                    MainForm.QueryDB("update vehicles set reminderSent='1' where vehicleId='"+ reminders.ElementAt(customersList.SelectedIndex)[4] + "'");
                }
            this.Close();
        }

        private void MOTreminderForm_Load(object sender, EventArgs e)
        {

        }
        private void loadReminders()
        {
            DateTime endDate = DateTime.Now;
            endDate=endDate.AddDays(MainForm.reminderDays);
            string reminderDate = endDate.Date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture); 

            reminders = MainForm.QueryDB("SELECT customers.name, customers.phone, vehicles.make, vehicles.model, vehicles.vehicleId from vehicles inner join customers on customers.customerId=vehicles.customerId where setReminder='1' and reminderSent='0' and vehicles.motDate='"+ reminderDate + "' ");

            customersList.Items.Clear();
            if (reminders.Count > 0)
            {
                for (int i = 0; i < reminders.Count; i++)
                {
                    customersList.Items.Add(reminders.ElementAt(i)[3]+"("+ reminders.ElementAt(i)[2] + "), "+reminders.ElementAt(i)[0]);

                }
                customersList.SelectedIndex = 0;
                customersList.Enabled = true;
            }

        }

        private void customersList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (customersList.SelectedIndex>-1) {
                SendBtn.Text = "Send";
            } else {
                SendBtn.Text = "Close";
            }
        }
    }
}
