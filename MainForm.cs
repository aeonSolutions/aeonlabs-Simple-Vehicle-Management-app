using Invoice_Management;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;

using System.Windows.Forms;

namespace Vehicle_Management
{
    public partial class MainForm : Form
    {
        private static String imagesPath = String.Format("{0}\\images\\", Environment.CurrentDirectory);
        private static String basePath = String.Format("{0}\\", Environment.CurrentDirectory);
        private static String tmpPath = String.Format("{0}\\tmp\\", Environment.CurrentDirectory);
        private static String databasePath = String.Format("{0}\\database\\", Environment.CurrentDirectory);
        private static String libraryPath = String.Format("{0}\\library\\", Environment.CurrentDirectory);
        private string filename = @libraryPath + @"settings.cfg";
        private string filenameUpdate = @libraryPath + @"update.cfg";

        private static String dbFile = databasePath + "invoices.db";
        private static String connString = string.Format(@"Data Source={0}; Pooling=false; FailIfMissing=false;", dbFile);

        public static int reminderDays = 0;
        public static bool checkUpdateEnabled = false;

        private loadedInvoiceStruct loadedInvoice = new loadedInvoiceStruct();
        
        //Elements of the combobox
        private string[] ComboxBoxItems;
        private Boolean invoiceLoaded = false;

        // Create the ToolTip and associate with the Form container.
        ToolTip toolTip1 = new ToolTip();

        public struct loadedInvoiceStruct
        {
            public int loadedInvoicePos;
            public int loadedCustomerPos;
            public int loadedVehiclerPos;

            public List<String[]> invoice;
            public List<String[]> customers;
            public List<String[]> jobs;
            public List<String[]> vehicles;
        }

 //*************************************************************************************
        public MainForm()
        {
            InitializeComponent();
            if (!Directory.Exists(databasePath))
            {
                Directory.CreateDirectory(databasePath);
            }

            // check for DB file
            if (!File.Exists(dbFile))
            {
                createNewDatabaseFile();
            }

            loadInvoices();
            loadCustomers();

            //InitializeComponent jobs table
            initializeJobsTable();

            invoice_date.Value = DateTime.Now;
            del_btn.Enabled = false;

            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;

            // Set up the ToolTip text for the Button and Checkbox.
            toolTip1.SetToolTip(this.invoice_number, "Type to Search an Invocie");
            toolTip1.SetToolTip(this.clearFieldsBtn, "Click to clear all fields");
            toolTip1.SetToolTip(this.searchBtn, "Click to begin a search");
            toolTip1.SetToolTip(this.buildInvoice_pdf, "Click to make a PDF of this invoice");
            toolTip1.SetToolTip(this.customerDelBtn, "Click to delete this customer");
            toolTip1.SetToolTip(this.vehicleDelBtn, "Click to delete this vehicle");
            toolStripStatusLabel1.Text = "";
            
            loadUpdateSettings();
            downloadUpdate();
            loadSettings();
        }

        //*************************************************************************************************************

        //************************************************************************************************************************************
        void createNewDatabaseFile()
        {
            using (var factory = new System.Data.SQLite.SQLiteFactory())
            {
                using (System.Data.Common.DbConnection dbConn = factory.CreateConnection())
                {
                    dbConn.ConnectionString = connString;
                    dbConn.Open();
                    using (System.Data.Common.DbCommand cmd = dbConn.CreateCommand())
                    {
                        //create invoices table
                        cmd.CommandText = @"CREATE TABLE IF NOT EXISTS invoices (invoiceId integer primary key, customerId integer, vehicleId, notes text, invoiceDate text);";
                        cmd.ExecuteNonQuery();

                        //create customer table
                        cmd.CommandText = @"CREATE TABLE IF NOT EXISTS customers (customerId integer primary key, name text, address text, phone text, email text, postal text);";
                        cmd.ExecuteNonQuery();

                        //create jobs table
                        cmd.CommandText = @"CREATE TABLE IF NOT EXISTS jobs (jobId integer primary key, invoiceId integer, description text, cost text);";
                        cmd.ExecuteNonQuery();

                        //create jobs table
                        cmd.CommandText = @"CREATE TABLE IF NOT EXISTS vehicles (vehicleId integer primary key, customerId integer, make text, model text, registration, motDate text, setReminder text, reminderSent text);";
                        cmd.ExecuteNonQuery();
                    }
                    if (dbConn.State != System.Data.ConnectionState.Closed) dbConn.Close();
                    dbConn.Dispose();
                    factory.Dispose();
                }
            }
        }
        //*************************************************************************************************************
        private void loadUpdateSettings() {
            StreamReader readme = null;

            try
            {
                readme = File.OpenText(filenameUpdate);
                string value = readme.ReadToEnd();

                int n;
                bool isNumeric = int.TryParse(value, out n);
                if (isNumeric)
                {
                    if (n==0) {
                        checkUpdateEnabled = false;
                    } else {
                        checkUpdateEnabled = true;
                    }
                    
                }
                else
                {
                    checkUpdateEnabled = false;
                }
            }
            // will return an invalid file name error
            catch (Exception errorMsg)
            {
                checkUpdateEnabled = false;
            }
            finally
            {
                if (readme != null)
                {
                    readme.Close();
                }
            }
        }
        //*****************************************************************************************************
        private void loadSettings() {
            StreamReader readme = null;

            try
            {
                readme = File.OpenText(filename);
                string value = readme.ReadToEnd();

                int n;
                bool isNumeric = int.TryParse(value, out n);
                if (isNumeric)
                {
                    reminderDays = n;
                }
                else
                {
                    reminderDays=0;
                }
            }
            // will return an invalid file name error
            catch (Exception errorMsg)
            {
                reminderDays = 0;
            }
            finally
            {
                if (readme != null)
                {
                    readme.Close();
                }
            }

        }

        //******************************************************************************************************
        private void clearFields()
        {
            clearCustomerFields();
            clearVehicleFields();
            clearInvoiceFields();
        }
        private void clearInvoiceFields() {
            notes_txt.Text = "";
            loadedInvoice.loadedInvoicePos = -1;

            invoice_total_lbl.Text = "Total: £0.0";
            job_items_table.DataSource = null;
            job_items_table.Rows.Clear();
            invoice_date.Value = DateTime.Now;
            if (invoice_number.Items.Count > 0)
                invoice_number.SelectedIndex = 0;

        }

        private void clearCustomerFields() {
            name_txt.Text = "";
            address_txt.Text = "";
            email_txt.Text = "";
            phone_txt.Text = "";
            post_code_txt.Text = "";
            customerDelBtn.Visible = false;

        }

        private void clearVehicleFields()
        {

            reminderChk.Checked = false;
            make_txt.Text = "";
            model_txt.Text = "";
            registration_txt.Text = "";
            mot_date.Value= DateTime.Now;
            vehicleDelBtn.Visible = false;
            vehicleGroupBox.Enabled = false;
            vehicles_list.Items.Clear();
            vehicles_list.Items.Add("New vehicle");
            loadedInvoice.loadedVehiclerPos = -1;
        }

        private void clearFieldsBtn_Click(object sender, EventArgs e)
        {
            clearFields();
            if (customers_list.Items.Count > 0)
                customers_list.SelectedIndex = 0;
        }

        //*************************************************************************************************************
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        //*************************************************************************************************************
        public static int InArray(ref List<string[]> arr, string needle, int pos)
        {
            int i;
            if (arr is null)
            {
                return -2;
            }

            var loopTo = arr.Count - 1;
            for (i = 0; i <= loopTo; i++)
            {
                if (arr.ElementAt(i)[pos].ToString().Equals(needle))
                {
                    return i;
                }
            }
            return -1;
        }

        //*****************************************************************************************************
        private void enableButtons(bool state)
        {
            invoice_number.Enabled = state;
            groupBox1.Enabled = state;
            enableInvoiceFields(state);
        }

        private void enableInvoiceFields(bool state)
        {
            buildInvoice_pdf.Enabled = state;
            save_btn.Enabled = state;
            del_btn.Enabled = state;
            job_items_table.Enabled = state;
            notes_txt.Enabled = state;
        }

        private void enableVehicleFields(bool state) {
            vehicleDelBtn.Visible = state;
            vehicleGroupBox.Enabled = state;
        }
        //*************************************************************************************************************
        public static List<String[]> QueryDB(string query)
        {

            List<String[]> result = new List<string[]>();
            string[] row = new string[0];

            using (var factory = new System.Data.SQLite.SQLiteFactory())
            using (System.Data.Common.DbConnection dbConn = factory.CreateConnection())
            {
                dbConn.ConnectionString = connString;
                dbConn.Open();
                using (System.Data.Common.DbCommand cmd = dbConn.CreateCommand())
                {
                    //read from the table
                    cmd.CommandText = @query;
                    using (System.Data.Common.DbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            row = new string[reader.FieldCount];
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                try
                                {
                                    row[i] = reader.GetString(i);
                                }
                                catch (Exception e)
                                {
                                    try
                                    {
                                        row[i] = Convert.ToString(reader.GetInt64(i));
                                    }
                                    catch (Exception ex)
                                    {

                                    }
                                }

                            }
                            result.Add(row);
                        }
                    }
                }
                if (dbConn.State != System.Data.ConnectionState.Closed) dbConn.Close();
                dbConn.Dispose();
                factory.Dispose();
            }
            return result;
        }
        //*************************************************************************************************************
        void initializeJobsTable()
        {
            job_items_table.RowHeadersVisible = false;
            job_items_table.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            job_items_table.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            job_items_table.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            job_items_table.Rows.Clear();
            job_items_table.RowCount = 1;

            job_items_table.ColumnCount = 2;
            job_items_table.Columns[0].HeaderCell.Value = "Description";
            job_items_table.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            job_items_table.Columns[0].HeaderCell.Style.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            job_items_table.Columns[0].Width = job_items_table.Width - 150;
            job_items_table.Columns[0].CellTemplate.ValueType = typeof(string);

            job_items_table.Columns[1].HeaderCell.Value = "Amount";
            job_items_table.Columns[1].Width = 150;
            job_items_table.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            job_items_table.Columns[1].HeaderCell.Style.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            job_items_table.Columns[1].Resizable = DataGridViewTriState.False;

            // Do not allow automatic editing.
            job_items_table.EditMode = DataGridViewEditMode.EditOnEnter;
            job_items_table.AllowUserToAddRows = true;
            job_items_table.AllowUserToDeleteRows = true;
            job_items_table.ReadOnly = false;
            job_items_table.Columns[1].DefaultCellStyle.Format = "c2";
            job_items_table.Columns[1].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("en-GB");

            job_items_table.CellValidating += new DataGridViewCellValidatingEventHandler(job_items_table_CellValidating);
        }

        //*************************************************************************************************************
        private void job_items_table_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 1 && Convert.ToString(e.FormattedValue) != String.Empty) // 1 should be your column index
            {
                double val;

                if (!double.TryParse(Convert.ToString(e.FormattedValue), out val))
                {
                    e.Cancel = true;
                    job_items_table.EditingControl.Text = string.Empty;
                    job_items_table.EndEdit();
                    MessageBox.Show("please enter a numeric value", "warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    job_items_table.EndEdit();
                    //job_items_table.Text = job_items_table[e.ColumnIndex, e.RowIndex].Value.ToString();
                    // the input is numeric
                    double amount = 0.0;
                    for (int i = 0; i < job_items_table.RowCount; i++)
                    {
                        if (job_items_table[1, i].Value != null)
                            amount += double.Parse(job_items_table[1, i].Value.ToString());
                    }
                    invoice_total_lbl.Text = String.Format("Total: £{0:0.00}", amount);
                }
            }
        }

      //**********************************************************************************
        private void job_items_table_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            job_items_table.EndEdit();
        }
        //******************************************************************************************************
        public void job_items_table_LostFocus(object sender, EventArgs e){
            //Do stuff when focus is lost
            job_items_table.EndEdit();
            double val;

            // the input is numeric
            double amount = 0.0;
            for (int i = 0; i < job_items_table.RowCount; i++)
            {
                if (job_items_table[1, i].Value != null)
                {
                    if (double.TryParse(Convert.ToString(job_items_table[1, i].Value), out val))
                    {
                        amount += double.Parse(job_items_table[1, i].Value.ToString());
                    }
                }
            }
            invoice_total_lbl.Text = String.Format("Total: £{0:0.00}", amount);
        }

        // ******************** SEARCH METHODS ************************************************************************************
        //*************************************************************************************************************************
        private void searchBtn_Click(object sender, EventArgs e)
        {
            if (!name_title.Checked && !email_title.Checked && !phone_title.Checked)
            {
                MessageBox.Show("You need to select a field by clicking on a checkbox", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string query = "select customerId from customers where ";
            string addAnd = "";

            if (name_title.Checked)
            {
                query += "name='" + name_txt.Text.ToString() + "'";
                addAnd = " and ";
            }
            if (email_title.Checked)
            {
                query += addAnd + "email='" + email_txt.Text.ToString() + "'";
                addAnd = " and ";
            }
            if (phone_title.Checked)
            {
                query += addAnd + "phone='" + phone_txt.Text.ToString() + "'";
            }
            DoSearchOnDB(query);
        }
        //*************************************************************************************************************************
        private void DoSearchOnDB(string query)
        {
            string result = "No invoices found for your search query";

            using (var factory = new System.Data.SQLite.SQLiteFactory())
            {
                using (System.Data.Common.DbConnection dbConn = factory.CreateConnection())
                {
                    dbConn.ConnectionString = connString;
                    dbConn.Open();
                    using (System.Data.Common.DbCommand cmd = dbConn.CreateCommand())
                    {
                        List<string[]> customer = QueryDB(query);
                        if (customer.Count != 0)
                        {
                            query = "select invoiceId from invoices where ";
                            string addOr = "";
                            for (int i = 0; i < customer.Count; i++)
                            {
                                query += addOr + "customerId='" + customer.ElementAt(i)[0] + "'";
                                addOr = " or ";
                            }
                            List<string[]> invoices = QueryDB(query);
                            if (invoices.Count != 0)
                            {
                                result = "Found invoies: ";
                                string addAnd = "";
                                for (int i = 0; i < invoices.Count; i++)
                                {
                                    result += addAnd + " n.:" + invoices.ElementAt(i)[0] + ",";
                                    addAnd = " and ";
                                }
                            }
                        }
                    }
                    if (dbConn.State != System.Data.ConnectionState.Closed) dbConn.Close();
                    dbConn.Dispose();
                    factory.Dispose();
                }
            }
            MessageBox.Show(result, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //******************************************************************************************************************
        // Build Invoice PDF
        //*****************************************************************************************************************
        private void buildInvoicePDF() {
            RichTextBox richtext = new RichTextBox();

            try {
                FileSystem.Kill(Environment.CurrentDirectory + "\\tmp\\invoice.rtf");
                FileSystem.Kill(Environment.CurrentDirectory + "\\tmp\\invoice.pdf");
                FileSystem.Kill(Environment.CurrentDirectory + "\\tmp\\build.exe");
            } catch {

            }

            richtext.LoadFile(Environment.CurrentDirectory + "\\library\\build.tpl", RichTextBoxStreamType.RichText);
            String str = richtext.Rtf;

            String description = "";
            String amount = "";

            double totalAmount = 0.0;
            for (int i = 0; i <=8; i++)
            {
                // jobId, invoiceId, description, cost
                if (i < loadedInvoice.jobs.Count)
                {
                    description += loadedInvoice.jobs.ElementAt(i)[2] + " \\line\\line";
                    amount += "£" + loadedInvoice.jobs.ElementAt(i)[3] + " \\line";
                    totalAmount += double.Parse(loadedInvoice.jobs.ElementAt(i)[3]);
                }
                else {
                    description+= " \\line";
                    amount += " \\line";
                }

            }

            str= str.Replace("[invoice]", invoice_number.SelectedItem.ToString());
            str = str.Replace("[date]", invoice_date.Value.ToString("yyyy-MM-dd"));
            str = str.Replace("[name]", name_txt.Text.ToString());
            str = str.Replace("[address]", address_txt.Text.ToString());
            str = str.Replace("[postal]", post_code_txt.Text.ToString());
            str = str.Replace("[email]", email_txt.Text.ToString());
            str = str.Replace("[phone]", phone_txt.Text.ToString());
            str = str.Replace("[total]", Convert.ToString(totalAmount));
            str = str.Replace("[description]", description);
            str = str.Replace("[amount]", amount);
            str = str.Replace("[make]", make_txt.Text.ToString());
            str = str.Replace("[model]", model_txt.Text.ToString());
            str = str.Replace("[registration]", registration_txt.Text.ToString());

            richtext.Rtf = str;

            richtext.SaveFile(Environment.CurrentDirectory + "\\tmp\\invoice.rtf");

            File.Copy(@Environment.CurrentDirectory + "\\library\\task.bin", @Environment.CurrentDirectory + "\\tmp\\build.exe");
            ProcessStartInfo p= new ProcessStartInfo();
            p.FileName = Environment.CurrentDirectory + "\\tmp\\build.exe";
            p.Arguments = @" -f """ + Environment.CurrentDirectory + @"\\tmp\\invoice.rtf """ + @" -O """ + Environment.CurrentDirectory + @"\\tmp\\invoice.pdf""" + " -T wdFormatPDF -Q";
            p.WindowStyle = ProcessWindowStyle.Hidden;
            p.UseShellExecute = false;
            p.RedirectStandardOutput = true;
            p.CreateNoWindow = true;
            Process.Start(p);

            FileInfo file = new FileInfo(Environment.CurrentDirectory + "\\tmp\\invoice.pdf");

            Stopwatch start = Stopwatch.StartNew();
            while (start.ElapsedMilliseconds < 20000 & !file.Exists)
            {
                System.Windows.Forms.Application.DoEvents();
                file.Refresh();
            }

            if (!file.Exists)
            {
                MessageBox.Show("Unable to build the invoice document. Try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else {
                // save file dialog box
                try
                {
                    FileSystem.Kill(Environment.CurrentDirectory + "\\tmp\\build.exe");
                }
                catch
                {
                }


                SaveFileDialog savefile = new SaveFileDialog();
                // set a default file name
                savefile.FileName = "invoice n"+invoice_number.SelectedItem.ToString()+" --"+ invoice_date.Value.ToString("yyyy-MM-dd")+" --"+name_txt.Text.ToString()+" --Reg number "+ registration_txt.Text.ToString()+".pdf";
                // set filters - this can be done in properties as well
                savefile.Filter = "PDF files (*.pdf)|*.pdf";

                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        FileInfo fileS = new FileInfo(savefile.FileName);
                        if (fileS.Exists) {
                            fileS.Delete();
                        }
                        File.Copy(@Environment.CurrentDirectory + "\\tmp\\invoice.pdf", savefile.FileName);
                    }
                    catch
                    {
                        MessageBox.Show("Unable to save file. Try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                }
            }
        }

//******************************************************************************************************************
        private void buildInvoice_pdf_Click(object sender, EventArgs e)
        {
            enableButtons(false);
            toolStripStatusLabel1.Text = "Building PDF file. Wait one moment.";
            buildInvoicePDF();
            enableButtons(true);
            toolStripStatusLabel1.Text ="";
        }

        //*******************************************************************************************
        // INVOICE
        // ***************************************************************************************************************

        private void loadInvoices()
        {
            using (var factory = new System.Data.SQLite.SQLiteFactory())
            {
                using (System.Data.Common.DbConnection dbConn = factory.CreateConnection())
                {
                    dbConn.ConnectionString = connString;
                    dbConn.Open();
                    using (System.Data.Common.DbCommand cmd = dbConn.CreateCommand())
                    {
                        loadedInvoice.invoice = QueryDB("SELECT invoiceId, customerId, notes, invoiceDate, vehicleId from invoices");

                        clearFields();
                        invoice_number.Items.Clear();
                        ComboxBoxItems = new string[loadedInvoice.invoice.Count];

                        invoice_number.Items.Add("New Invoice");

                        for (int i = 0; i < loadedInvoice.invoice.Count; i++)
                        {
                            invoice_number.Items.Add(loadedInvoice.invoice.ElementAt(i)[0]);
                            ComboxBoxItems[i] = loadedInvoice.invoice.ElementAt(i)[0];
                        }
                        loadedInvoice.loadedInvoicePos = -1;

                        invoice_number.SelectedIndex = 0;
                        invoice_number.Enabled = true;

                    }
                }
            }
        }

        //***********************************************************************************************************
        private Boolean validateFields()
        {
            String errMsg = "";
            if (job_items_table[0, 0].Value == null || job_items_table[1, 0].Value == null)
                errMsg = "You need to add a Job first";
            if (job_items_table[0, 0].Value != null && job_items_table[1, 0].Value != null)
            {
                if (job_items_table[0, 0].Value.Equals("") && job_items_table[1, 0].Value.Equals(""))
                    errMsg = "You need to add a Job first";
            }
            if (name_txt.Text.ToString().Equals(""))
                errMsg = "You need to add a name first";
            if (address_txt.Text.ToString().Equals(""))
                errMsg = "You need to add a name first";
            if (post_code_txt.Text.ToString().Equals(""))
                errMsg = "You need to add a postal code first";
            if (email_txt.Text.ToString().Equals("") || !IsValidEmail(email_txt.Text.ToString()))
                errMsg = "You need to add an email first";
            if (phone_txt.Text.ToString().Equals(""))
                errMsg = "You need to add an phone number first";

            if (make_txt.Text.ToString().Equals(""))
                errMsg = "You need to add a Make first";
            if (model_txt.Text.ToString().Equals(""))
                errMsg = "You need to add a model first";
            if (registration_txt.Text.ToString().Equals(""))
                errMsg = "You need to add a registration first";

            if (errMsg.Equals(""))
            {

                return true;
            }
            else
            {
                MessageBox.Show(errMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //*************************************************************************************************************
        private void loadInvoiceRecord()
        {
            int invoicePos = InArray(ref loadedInvoice.invoice, invoice_number.SelectedItem.ToString(), 0);
            loadedInvoice.loadedCustomerPos = InArray(ref loadedInvoice.customers, loadedInvoice.invoice.ElementAt(invoicePos)[1], 0);
            
            using (var factory = new System.Data.SQLite.SQLiteFactory())
            {
                using (System.Data.Common.DbConnection dbConn = factory.CreateConnection())
                {
                    dbConn.ConnectionString = connString;
                    dbConn.Open();
                    using (System.Data.Common.DbCommand cmd = dbConn.CreateCommand())
                    {
                        string query = "select jobId, invoiceId, description, cost from jobs where invoiceId='" + loadedInvoice.invoice.ElementAt(invoicePos)[0] + "' ";
                        loadedInvoice.jobs = QueryDB(query);
                    }
                    if (dbConn.State != System.Data.ConnectionState.Closed) dbConn.Close();
                    dbConn.Dispose();
                    factory.Dispose();
                }
            }
        }

        //*************************************************************************************************************
        private void save_btn_Click(object sender, EventArgs e)
        {
            if (!validateFields())
            {
                return;
            }

            Invoice_Management.Invoices.InvoicesManagement mngt = new Invoice_Management.Invoices.InvoicesManagement(connString, loadedInvoice);
            if (save_btn.Text.Equals("New Invoice"))
            {
                string invoiceId = mngt.addNewInvoiceToDatabase(loadedInvoice.customers.ElementAt(loadedInvoice.loadedCustomerPos)[0], loadedInvoice.vehicles.ElementAt(loadedInvoice.loadedVehiclerPos)[0], ref job_items_table, ref invoice_date, ref notes_txt);
                
                if (customers_list.Items.Count > 0)
                    customers_list.SelectedIndex = 0;

                clearFields();
                loadInvoices();


                loadedInvoice.loadedInvoicePos = InArray(ref loadedInvoice.invoice, invoiceId, 0);
                invoice_number.SelectedIndex = loadedInvoice.loadedInvoicePos + 1;

                MessageBox.Show("Invoice created on the database", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            { // edit invoice 
                mngt.editInvoiceOnDatabase(ref job_items_table, ref invoice_number, ref notes_txt);

                MessageBox.Show("Invoice updated on the database", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

         //**************************************************************************************************
        private void del_btn_Click(object sender, EventArgs e)
        {
            Invoice_Management.Invoices.InvoicesManagement mngt = new Invoice_Management.Invoices.InvoicesManagement(connString, loadedInvoice);
            mngt.deleteInvoiceOnDB(invoice_number.SelectedIndex - 1);

            MessageBox.Show("Invoice deleted on database", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadInvoices();
            if (customers_list.Items.Count > 0)
                customers_list.SelectedIndex = 0;
        }
        //************************************************************************************************************************************
        private void invoice_number_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (invoice_number.Items.Count < 1)
                return;

            if (invoice_number.SelectedIndex == 0)
            {
                clearInvoiceFields();
                save_btn.Text = "New Invoice";
                del_btn.Enabled = false;
                buildInvoice_pdf.Visible = false;
            }
            else
            {
                enableVehicleFields(true);
                enableButtons(true);

                invoiceLoaded = true;
                buildInvoice_pdf.Visible = true;
                del_btn.Enabled = true;
                save_btn.Text = "Save Invoice";
                // new invoice
                loadInvoiceRecord();

                loadedInvoice.loadedInvoicePos  = InArray(ref loadedInvoice.invoice, invoice_number.SelectedItem.ToString(), 0);
                loadedInvoice.loadedCustomerPos = InArray(ref loadedInvoice.customers, loadedInvoice.invoice.ElementAt(loadedInvoice.loadedInvoicePos)[1], 0);

                //  invoice info
                notes_txt.Text = loadedInvoice.invoice.ElementAt(loadedInvoice.loadedInvoicePos)[2];
                invoice_date.Value = DateTime.ParseExact(loadedInvoice.invoice.ElementAt(loadedInvoice.loadedInvoicePos)[3], "yyyy-MM-dd", CultureInfo.InvariantCulture);

                customers_list.SelectedIndex = loadedInvoice.loadedCustomerPos + 1;
                loadVehicles();
                

                job_items_table.Rows.Clear();
                if (loadedInvoice.jobs.Count == 0)
                {
                    job_items_table.RowCount = 1;
                }
                else
                {
                    job_items_table.RowCount = loadedInvoice.jobs.Count;
                }

                double amount = 0.0;
                for (int i = 0; i < loadedInvoice.jobs.Count; i++)
                {
                    // jobId, invoiceId, description, cost
                    job_items_table[0, i].Value = loadedInvoice.jobs.ElementAt(i)[2];
                    job_items_table[1, i].Value = loadedInvoice.jobs.ElementAt(i)[3];
                    amount += double.Parse(loadedInvoice.jobs.ElementAt(i)[3]);
                }
                invoice_total_lbl.Text = String.Format("Total: £{0:0.00}", amount);
                invoiceLoaded = false;
            }
        }

        //*******************************************************************************************************
        private void invoice_number_TextUpdate(object sender, EventArgs e)
        {
            //Gets the items that contains the search string and orders them by its position. Without the union items that don't contain the
            //search string would be permanently removed from the combobox.
            string[] UpdatedComboBoxItems = ComboxBoxItems.Where(x => x.Contains(invoice_number.Text)).OrderBy(x => x.IndexOf(invoice_number.Text)).ToArray();

            //Removes every element from the combobox control. Combobox.Items.Clear causes the cursor position to reset.
            foreach (string Element in ComboxBoxItems)
                invoice_number.Items.Remove(Element);

            //Re-adds all the element in order.
            invoice_number.Items.AddRange(UpdatedComboBoxItems);
        }

        //*******************************************************************************************************************************************
        // VEHICLES
        //****************************************************************************************************************************************
        private Boolean validateVehicleFields()
        {
            String errMsg = "";
            if (make_txt.Text.ToString().Equals(""))
                errMsg = "YOu need to add a Make first";
            if (model_txt.Text.ToString().Equals(""))
                errMsg = "YOu need to add a model first";
            if (registration_txt.Text.ToString().Equals(""))
                errMsg = "YOu need to add a registration first";

            if (errMsg.Equals(""))
            {

                return true;
            }
            else
            {
                MessageBox.Show(errMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        
        //*************************************************************************************************************
        private void loadVehicles()
        {
            using (var factory = new System.Data.SQLite.SQLiteFactory())
            {
                using (System.Data.Common.DbConnection dbConn = factory.CreateConnection())
                {
                    dbConn.ConnectionString = connString;
                    dbConn.Open();
                    using (System.Data.Common.DbCommand cmd = dbConn.CreateCommand())
                    {
                        String query = "select vehicleId, customerId, model , make , registration , motDate, setReminder from vehicles where customerId='" + loadedInvoice.customers.ElementAt(loadedInvoice.loadedCustomerPos)[0] + "' ";
                        loadedInvoice.vehicles = QueryDB(query);

                        clearVehicleFields();
                        for (int i = 0; i < loadedInvoice.vehicles.Count; i++)
                        {
                            vehicles_list.Items.Add(loadedInvoice.vehicles.ElementAt(i)[2]+" ("+ loadedInvoice.vehicles.ElementAt(i)[3] + ")");
                        }
                        if (!invoiceLoaded)
                        {
                            vehicles_list.SelectedIndex = 0;
                            loadedInvoice.loadedVehiclerPos = -1;
                        }
                        else {
                            loadedInvoice.loadedVehiclerPos = InArray(ref loadedInvoice.vehicles, loadedInvoice.invoice.ElementAt(loadedInvoice.loadedInvoicePos)[4], 0);
                            vehicles_list.SelectedIndex = loadedInvoice.loadedVehiclerPos + 1;
                        }


                        vehicles_list.Enabled = true;
                    }
                    if (dbConn.State != System.Data.ConnectionState.Closed) dbConn.Close();
                    dbConn.Dispose();
                    factory.Dispose();
                }
            }
        }

        //***************************************************************************************************
        private void vehicleDelBtn_Click(object sender, EventArgs e)
        {
            Invoice_Management.Vehicles.VehiclesManagement mngt = new Invoice_Management.Vehicles.VehiclesManagement(connString, loadedInvoice);
            mngt.deleteVehicleOnDB(loadedInvoice.loadedVehiclerPos);

            MessageBox.Show("Vehicle deleted on database", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadVehicles();
            vehicleGroupBox.Enabled = true;
        }
//*******************************************************************************************************
        private void vehicleSaveBtn_Click(object sender, EventArgs e)
        {
            if (!validateVehicleFields())
            {
                return;
            }
            string reminder= reminderChk.Checked ? "1" : "0";

            Invoice_Management.Vehicles.VehiclesManagement mngt = new Invoice_Management.Vehicles.VehiclesManagement(connString, loadedInvoice);
            if (vehicles_list.SelectedIndex<1)
            {
                mngt.addNewVehicleToDatabase(loadedInvoice.customers.ElementAt(loadedInvoice.loadedCustomerPos)[0], ref make_txt, ref model_txt, ref registration_txt, ref mot_date, reminder);

                MessageBox.Show("Vehicle added to the database", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            { // edit invoice 
                mngt.editVehicleOnDatabase(loadedInvoice.vehicles.ElementAt(loadedInvoice.loadedVehiclerPos)[0], ref make_txt, ref model_txt, ref registration_txt, ref mot_date, reminder);

                MessageBox.Show("Vehicle data updated on the database", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            loadVehicles();
            vehicleGroupBox.Enabled = true;
        }
        //******************************************************************************************
        private void vehicles_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (vehicles_list.Items.Count==0)
                return;

            if (vehicles_list.SelectedIndex < 1)
            {
                make_txt.Text = "";
                model_txt.Text = "";
                registration_txt.Text = "";
                mot_date.Value = DateTime.Now;
                vehicleDelBtn.Visible = false;

                clearInvoiceFields();

                vehicleDelBtn.Visible = false;
                toolTip1.SetToolTip(this.vehicleSaveBtn, "add new vehicle info");
            }
            else
            {

                make_txt.Text = "";
                model_txt.Text = "";
                registration_txt.Text = "";
                mot_date.Value = DateTime.Now;
                vehicleDelBtn.Visible = false;
                vehicleGroupBox.Enabled = false;

                vehicleGroupBox.Enabled = true;
                vehicleDelBtn.Visible = true;
                toolTip1.SetToolTip(this.vehicleSaveBtn, "Save vehicle info");
                loadedInvoice.loadedVehiclerPos = vehicles_list.SelectedIndex - 1;

                // vehicle info
                model_txt.Text = loadedInvoice.vehicles.ElementAt(vehicles_list.SelectedIndex-1)[2];
                make_txt.Text = loadedInvoice.vehicles.ElementAt(vehicles_list.SelectedIndex - 1)[3];
                registration_txt.Text = loadedInvoice.vehicles.ElementAt(vehicles_list.SelectedIndex - 1)[4];
                mot_date.Value = DateTime.ParseExact(loadedInvoice.vehicles.ElementAt(vehicles_list.SelectedIndex - 1)[5], "yyyy-MM-dd", CultureInfo.InvariantCulture);
                if (loadedInvoice.vehicles.ElementAt(vehicles_list.SelectedIndex - 1)[6].Equals("1")) {
                    reminderChk.Checked = true;
                } else {
                    reminderChk.Checked = false;
                }
            }
        }

        //*******************************************************************************************************************************************
        // CUSTOMERS
        //****************************************************************************************************************************************
        private Boolean validateCustomerFields()
        {
            String errMsg = "";

            if (name_txt.Text.ToString().Equals(""))
                errMsg = "YOu need to add a name first";
            if (address_txt.Text.ToString().Equals(""))
                errMsg = "YOu need to add a name first";
            if (post_code_txt.Text.ToString().Equals(""))
                errMsg = "YOu need to add a postal code first";
            if (email_txt.Text.ToString().Equals("") || !IsValidEmail(email_txt.Text.ToString()))
                errMsg = "You need to add an email first";
            if (phone_txt.Text.ToString().Equals(""))
                errMsg = "YOu need to add an phone number first";

            if (errMsg.Equals(""))
            {

                return true;
            }
            else
            {
                MessageBox.Show(errMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        //*************************************************************************************************************
        private void loadCustomers()
        {
            int arrPos = InArray(ref loadedInvoice.invoice, invoice_number.SelectedItem.ToString(), 0);
            using (var factory = new System.Data.SQLite.SQLiteFactory())
            {
                using (System.Data.Common.DbConnection dbConn = factory.CreateConnection())
                {
                    dbConn.ConnectionString = connString;
                    dbConn.Open();
                    using (System.Data.Common.DbCommand cmd = dbConn.CreateCommand())
                    {
                        String query = "select customerId, name, address, phone, email, postal from customers";
                        loadedInvoice.customers = QueryDB(query);
                        
                        clearCustomerFields();
                        customers_list.Items.Clear();
                        customers_list.Items.Add("New Customer");

                        for (int i = 0; i < loadedInvoice.customers.Count; i++)
                        {
                            customers_list.Items.Add(loadedInvoice.customers.ElementAt(i)[1]);
                        }
                        loadedInvoice.loadedCustomerPos = -1;

                        customers_list.SelectedIndex = 0;
                        customers_list.Enabled = true;
                    }
                    if (dbConn.State != System.Data.ConnectionState.Closed) dbConn.Close();
                    dbConn.Dispose();
                    factory.Dispose();
                }
            }
        }

        //*****************************************************************************************
        private void customerDelBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("This will delete all Invoices from this customer. Do you want to continue?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Invoice_Management.Customers.CustomersManagement mngt = new Invoice_Management.Customers.CustomersManagement(connString, loadedInvoice);
                mngt.deleteCustomerOnDB(loadedInvoice.loadedCustomerPos);

                MessageBox.Show("Customer deleted on the database", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadedInvoice.loadedInvoicePos = -1;
                clearVehicleFields();
                loadCustomers();
                loadInvoices();
            }
        }
//******************************************************************************************
        private void customerSaveBtn_Click(object sender, EventArgs e)
        {
            if (!validateCustomerFields())
            {
                return;
            }

            Invoice_Management.Customers.CustomersManagement mngt = new Invoice_Management.Customers.CustomersManagement(connString, loadedInvoice);
            if (customers_list.SelectedIndex<1)
            {
                mngt.addNewCustomerToDatabase(ref  name_txt, ref  address_txt, ref  phone_txt, ref  email_txt, ref  post_code_txt);

                MessageBox.Show("customer record created on the database", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            { // edit invoice 
                mngt.editCustomerOnDatabase(loadedInvoice.customers.ElementAt(loadedInvoice.loadedCustomerPos)[0], ref  name_txt, ref  address_txt, ref  phone_txt, ref  email_txt, ref  post_code_txt);

                MessageBox.Show("Customer data updated on the database", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            loadedInvoice.loadedInvoicePos = -1;
            clearCustomerFields();
            loadCustomers();
        }

        // ****************************************************************************************************
        private void customers_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (customers_list.Items.Count == 0)
                return;

            if (customers_list.SelectedIndex <1)
            {
                clearFields();
                customerDelBtn.Visible = false;
                toolTip1.SetToolTip(this.customerSaveBtn, "add new customer info");
                vehicleGroupBox.Enabled = false;
                enableInvoiceFields(false);
            }
            else
            {
                clearCustomerFields();
                enableInvoiceFields(true);

                customerDelBtn.Visible = true;
                toolTip1.SetToolTip(this.customerSaveBtn, "save customer info");

                loadedInvoice.loadedCustomerPos = customers_list.SelectedIndex - 1;

                // customer info
                name_txt.Text = loadedInvoice.customers.ElementAt(loadedInvoice.loadedCustomerPos)[1];
                address_txt.Text = loadedInvoice.customers.ElementAt(loadedInvoice.loadedCustomerPos)[2];
                phone_txt.Text = loadedInvoice.customers.ElementAt(loadedInvoice.loadedCustomerPos)[3];
                email_txt.Text = loadedInvoice.customers.ElementAt(loadedInvoice.loadedCustomerPos)[4];
                post_code_txt.Text = loadedInvoice.customers.ElementAt(loadedInvoice.loadedCustomerPos)[5];


                if (!invoiceLoaded)
                {
                    // vehicle Info
                    loadVehicles();
                    vehicleGroupBox.Enabled = true;
                }
            }
        }

        //************************************************************************************************************************
        // MENU OPTIONS\
        //**********************************************************************************************************
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string itemText = e.ClickedItem.Text;


            switch (itemText)
            {
                case "Settings":
                    settingsForm settings_form = new settingsForm();
                    settings_form.Show();

                    break;

                case "MOT Reminders":
                    loadSettings();
                    MOTreminderForm MOTreminder_form = new MOTreminderForm();
                    MOTreminder_form.Show();
                    break;
            }
        }
        //************************************************************************************
        private void submenuAbout_ItemClicked(object sender, EventArgs e)
        {
            aboutForm about_form = new aboutForm();
            about_form.Show();
        }
        //*****************************************************************************************************************

        private void submenuUpdate_ItemClicked(object sender, EventArgs e)
        {
            Version serverVersion = new Version(checkForUpdate());
            Version currentVersion = Assembly.GetExecutingAssembly().GetName().Version;

            if (serverVersion > currentVersion)
            {
                MessageBox.Show("There is a new version. Check AeonLabs Website: http://www.aeonlabs.solutions/store or restart the program to download the update.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {  
              MessageBox.Show("You have the latest version installed.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //****************************************************************************************************
        // download updte
        //************************************************************************************
        private string checkForUpdate(bool ShowErrors=true) {
            string serverVersion = string.Empty;
            string url = @"http://www.aeonlabs.solutions/store/?v=invoice";

            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    serverVersion = reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                if (ShowErrors)
                {
                    MessageBox.Show("No internet connection found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    toolStripStatusLabel1.Text = "No internet connection found.";
                }
                return "";
            }

            return serverVersion;
        }
        //********************************************************************************
        private void downloadUpdate() {
            if (!checkUpdateEnabled)
            {
                toolStripStatusLabel1.Text = "The update check is disabled. Go to Aeonlabs.soluitons to check for new updates.";
                return;
            }


            string url = @"http://www.aeonlabs.solutions/store/?f=invoice";
            string fileName = @tmpPath + @"setup.exe";





            Version serverVersion = new Version(checkForUpdate());
            Version currentVersion = Assembly.GetExecutingAssembly().GetName().Version;
            if (serverVersion > currentVersion)
            {

                try
                {
                    toolStripStatusLabel1.Text = "Downloading the latest update....one moment.";
                    // Create a new WebClient instance.
                    using (WebClient myWebClient = new WebClient())
                    {
                        // Download the Web resource and save it into the current filesystem folder.
                        myWebClient.DownloadFile(url, fileName);
                    }
                }
                catch (Exception ex)
                {
                    toolStripStatusLabel1.Text = "No internet connection found.";
                }
            }
            else {
                toolStripStatusLabel1.Text = "The program is up to date.";
            }

            if (File.Exists(fileName))
            {
                DialogResult result = MessageBox.Show("Do you want to install the new update ?", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    var psi = new ProcessStartInfo
                    {
                        FileName = @fileName,
                        UseShellExecute = true
                    };
                    Process.Start(psi);

                    if (System.Windows.Forms.Application.MessageLoop)
                    {
                        // WinForms app
                        System.Windows.Forms.Application.Exit();
                    }
                    else
                    {
                        // Console app
                        System.Environment.Exit(1);
                    }

                }
                return;
            }

        }
    }
}

