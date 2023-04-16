
using System;

namespace Vehicle_Management
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.address_title = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.customerSaveBtn = new System.Windows.Forms.PictureBox();
            this.customerDelBtn = new System.Windows.Forms.PictureBox();
            this.customers_list = new System.Windows.Forms.ListBox();
            this.name_title = new System.Windows.Forms.CheckBox();
            this.phone_title = new System.Windows.Forms.CheckBox();
            this.email_title = new System.Windows.Forms.CheckBox();
            this.post_code_txt = new System.Windows.Forms.TextBox();
            this.post_code_title = new System.Windows.Forms.Label();
            this.clearFieldsBtn = new System.Windows.Forms.PictureBox();
            this.email_txt = new System.Windows.Forms.TextBox();
            this.searchBtn = new System.Windows.Forms.PictureBox();
            this.phone_txt = new System.Windows.Forms.TextBox();
            this.address_txt = new System.Windows.Forms.TextBox();
            this.name_txt = new System.Windows.Forms.TextBox();
            this.date_title = new System.Windows.Forms.Label();
            this.invoice_date = new System.Windows.Forms.DateTimePicker();
            this.invoice_number_title = new System.Windows.Forms.Label();
            this.invoice_number = new System.Windows.Forms.ComboBox();
            this.notes_txt = new System.Windows.Forms.TextBox();
            this.notes_title = new System.Windows.Forms.Label();
            this.job_items_table = new System.Windows.Forms.DataGridView();
            this.save_btn = new System.Windows.Forms.Button();
            this.del_btn = new System.Windows.Forms.Button();
            this.invoice_total_lbl = new System.Windows.Forms.Label();
            this.buildInvoice_pdf = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MOTreminderMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.submenuUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.submenuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.vehicleGroupBox = new System.Windows.Forms.GroupBox();
            this.reminderChk = new System.Windows.Forms.CheckBox();
            this.vehicleSaveBtn = new System.Windows.Forms.PictureBox();
            this.vehicleDelBtn = new System.Windows.Forms.PictureBox();
            this.registration_txt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.model_txt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.make_txt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.mot_date = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.vehicles_list = new System.Windows.Forms.ListBox();
            this.invoiceGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customerSaveBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerDelBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clearFieldsBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.job_items_table)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buildInvoice_pdf)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.vehicleGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vehicleSaveBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vehicleDelBtn)).BeginInit();
            this.invoiceGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // address_title
            // 
            this.address_title.AutoSize = true;
            this.address_title.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.address_title.Location = new System.Drawing.Point(430, 92);
            this.address_title.Name = "address_title";
            this.address_title.Size = new System.Drawing.Size(77, 25);
            this.address_title.TabIndex = 1;
            this.address_title.Text = "Address";
            this.address_title.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.customerSaveBtn);
            this.groupBox1.Controls.Add(this.customerDelBtn);
            this.groupBox1.Controls.Add(this.customers_list);
            this.groupBox1.Controls.Add(this.name_title);
            this.groupBox1.Controls.Add(this.phone_title);
            this.groupBox1.Controls.Add(this.email_title);
            this.groupBox1.Controls.Add(this.post_code_txt);
            this.groupBox1.Controls.Add(this.post_code_title);
            this.groupBox1.Controls.Add(this.clearFieldsBtn);
            this.groupBox1.Controls.Add(this.email_txt);
            this.groupBox1.Controls.Add(this.searchBtn);
            this.groupBox1.Controls.Add(this.phone_txt);
            this.groupBox1.Controls.Add(this.address_txt);
            this.groupBox1.Controls.Add(this.name_txt);
            this.groupBox1.Controls.Add(this.address_title);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(12, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1409, 189);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Customer";
            // 
            // customerSaveBtn
            // 
            this.customerSaveBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.customerSaveBtn.Image = ((System.Drawing.Image)(resources.GetObject("customerSaveBtn.Image")));
            this.customerSaveBtn.Location = new System.Drawing.Point(1344, 37);
            this.customerSaveBtn.Name = "customerSaveBtn";
            this.customerSaveBtn.Size = new System.Drawing.Size(30, 30);
            this.customerSaveBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.customerSaveBtn.TabIndex = 37;
            this.customerSaveBtn.TabStop = false;
            this.customerSaveBtn.Click += new System.EventHandler(this.customerSaveBtn_Click);
            // 
            // customerDelBtn
            // 
            this.customerDelBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.customerDelBtn.Image = ((System.Drawing.Image)(resources.GetObject("customerDelBtn.Image")));
            this.customerDelBtn.Location = new System.Drawing.Point(1344, 86);
            this.customerDelBtn.Name = "customerDelBtn";
            this.customerDelBtn.Size = new System.Drawing.Size(30, 30);
            this.customerDelBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.customerDelBtn.TabIndex = 36;
            this.customerDelBtn.TabStop = false;
            this.customerDelBtn.Click += new System.EventHandler(this.customerDelBtn_Click);
            // 
            // customers_list
            // 
            this.customers_list.FormattingEnabled = true;
            this.customers_list.ItemHeight = 25;
            this.customers_list.Location = new System.Drawing.Point(21, 37);
            this.customers_list.Name = "customers_list";
            this.customers_list.Size = new System.Drawing.Size(334, 129);
            this.customers_list.TabIndex = 24;
            this.customers_list.SelectedIndexChanged += new System.EventHandler(this.customers_list_SelectedIndexChanged);
            // 
            // name_title
            // 
            this.name_title.AutoSize = true;
            this.name_title.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.name_title.Location = new System.Drawing.Point(416, 39);
            this.name_title.Name = "name_title";
            this.name_title.Size = new System.Drawing.Size(85, 29);
            this.name_title.TabIndex = 17;
            this.name_title.Text = "Name";
            this.name_title.UseVisualStyleBackColor = true;
            // 
            // phone_title
            // 
            this.phone_title.AutoSize = true;
            this.phone_title.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.phone_title.Location = new System.Drawing.Point(413, 135);
            this.phone_title.Name = "phone_title";
            this.phone_title.Size = new System.Drawing.Size(88, 29);
            this.phone_title.TabIndex = 18;
            this.phone_title.Text = "Phone";
            this.phone_title.UseVisualStyleBackColor = true;
            // 
            // email_title
            // 
            this.email_title.AutoSize = true;
            this.email_title.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.email_title.Location = new System.Drawing.Point(846, 135);
            this.email_title.Name = "email_title";
            this.email_title.Size = new System.Drawing.Size(87, 29);
            this.email_title.TabIndex = 19;
            this.email_title.Text = "e-mail";
            this.email_title.UseVisualStyleBackColor = true;
            // 
            // post_code_txt
            // 
            this.post_code_txt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.post_code_txt.Location = new System.Drawing.Point(1155, 86);
            this.post_code_txt.Name = "post_code_txt";
            this.post_code_txt.Size = new System.Drawing.Size(147, 31);
            this.post_code_txt.TabIndex = 14;
            // 
            // post_code_title
            // 
            this.post_code_title.AutoSize = true;
            this.post_code_title.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.post_code_title.Location = new System.Drawing.Point(1056, 89);
            this.post_code_title.Name = "post_code_title";
            this.post_code_title.Size = new System.Drawing.Size(93, 25);
            this.post_code_title.TabIndex = 13;
            this.post_code_title.Text = "Post Code";
            this.post_code_title.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // clearFieldsBtn
            // 
            this.clearFieldsBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clearFieldsBtn.Image = ((System.Drawing.Image)(resources.GetObject("clearFieldsBtn.Image")));
            this.clearFieldsBtn.Location = new System.Drawing.Point(1344, 136);
            this.clearFieldsBtn.Name = "clearFieldsBtn";
            this.clearFieldsBtn.Size = new System.Drawing.Size(30, 30);
            this.clearFieldsBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.clearFieldsBtn.TabIndex = 12;
            this.clearFieldsBtn.TabStop = false;
            this.clearFieldsBtn.Click += new System.EventHandler(this.clearFieldsBtn_Click);
            // 
            // email_txt
            // 
            this.email_txt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.email_txt.Location = new System.Drawing.Point(939, 135);
            this.email_txt.Name = "email_txt";
            this.email_txt.Size = new System.Drawing.Size(363, 31);
            this.email_txt.TabIndex = 7;
            // 
            // searchBtn
            // 
            this.searchBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.searchBtn.Image = ((System.Drawing.Image)(resources.GetObject("searchBtn.Image")));
            this.searchBtn.Location = new System.Drawing.Point(361, 134);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(30, 30);
            this.searchBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.searchBtn.TabIndex = 11;
            this.searchBtn.TabStop = false;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // phone_txt
            // 
            this.phone_txt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.phone_txt.Location = new System.Drawing.Point(510, 135);
            this.phone_txt.Name = "phone_txt";
            this.phone_txt.Size = new System.Drawing.Size(309, 31);
            this.phone_txt.TabIndex = 6;
            // 
            // address_txt
            // 
            this.address_txt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.address_txt.Location = new System.Drawing.Point(510, 86);
            this.address_txt.Name = "address_txt";
            this.address_txt.Size = new System.Drawing.Size(527, 31);
            this.address_txt.TabIndex = 5;
            // 
            // name_txt
            // 
            this.name_txt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.name_txt.Location = new System.Drawing.Point(510, 37);
            this.name_txt.Name = "name_txt";
            this.name_txt.Size = new System.Drawing.Size(792, 31);
            this.name_txt.TabIndex = 4;
            // 
            // date_title
            // 
            this.date_title.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.date_title.AutoSize = true;
            this.date_title.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.date_title.Location = new System.Drawing.Point(977, 42);
            this.date_title.Name = "date_title";
            this.date_title.Size = new System.Drawing.Size(108, 25);
            this.date_title.TabIndex = 16;
            this.date_title.Text = "Invoice date";
            // 
            // invoice_date
            // 
            this.invoice_date.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.invoice_date.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.invoice_date.Location = new System.Drawing.Point(1091, 37);
            this.invoice_date.Name = "invoice_date";
            this.invoice_date.Size = new System.Drawing.Size(300, 31);
            this.invoice_date.TabIndex = 15;
            // 
            // invoice_number_title
            // 
            this.invoice_number_title.AutoSize = true;
            this.invoice_number_title.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.invoice_number_title.Location = new System.Drawing.Point(23, 37);
            this.invoice_number_title.Name = "invoice_number_title";
            this.invoice_number_title.Size = new System.Drawing.Size(135, 25);
            this.invoice_number_title.TabIndex = 10;
            this.invoice_number_title.Text = "Invoice number";
            // 
            // invoice_number
            // 
            this.invoice_number.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.invoice_number.FormattingEnabled = true;
            this.invoice_number.Location = new System.Drawing.Point(164, 34);
            this.invoice_number.Name = "invoice_number";
            this.invoice_number.Size = new System.Drawing.Size(335, 33);
            this.invoice_number.TabIndex = 9;
            this.invoice_number.SelectedIndexChanged += new System.EventHandler(this.invoice_number_SelectedIndexChanged);
            this.invoice_number.TextUpdate += new System.EventHandler(this.invoice_number_TextUpdate);
            // 
            // notes_txt
            // 
            this.notes_txt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.notes_txt.Location = new System.Drawing.Point(21, 445);
            this.notes_txt.Multiline = true;
            this.notes_txt.Name = "notes_txt";
            this.notes_txt.Size = new System.Drawing.Size(773, 128);
            this.notes_txt.TabIndex = 5;
            // 
            // notes_title
            // 
            this.notes_title.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.notes_title.AutoSize = true;
            this.notes_title.Location = new System.Drawing.Point(21, 413);
            this.notes_title.Name = "notes_title";
            this.notes_title.Size = new System.Drawing.Size(62, 25);
            this.notes_title.TabIndex = 6;
            this.notes_title.Text = "Notes";
            // 
            // job_items_table
            // 
            this.job_items_table.AllowUserToAddRows = false;
            this.job_items_table.AllowUserToDeleteRows = false;
            this.job_items_table.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.job_items_table.BackgroundColor = System.Drawing.SystemColors.Control;
            this.job_items_table.CausesValidation = false;
            this.job_items_table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.job_items_table.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.job_items_table.Location = new System.Drawing.Point(21, 92);
            this.job_items_table.Margin = new System.Windows.Forms.Padding(4);
            this.job_items_table.MultiSelect = false;
            this.job_items_table.Name = "job_items_table";
            this.job_items_table.ReadOnly = true;
            this.job_items_table.RowHeadersWidth = 62;
            this.job_items_table.RowTemplate.Height = 33;
            this.job_items_table.Size = new System.Drawing.Size(1370, 317);
            this.job_items_table.TabIndex = 7;
            this.job_items_table.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.job_items_table_CellLeave);
            this.job_items_table.Leave += new System.EventHandler(this.job_items_table_LostFocus);
            // 
            // save_btn
            // 
            this.save_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.save_btn.Location = new System.Drawing.Point(1254, 539);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(137, 34);
            this.save_btn.TabIndex = 8;
            this.save_btn.Text = "New Invoice";
            this.save_btn.UseVisualStyleBackColor = true;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // del_btn
            // 
            this.del_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.del_btn.Location = new System.Drawing.Point(1112, 539);
            this.del_btn.Name = "del_btn";
            this.del_btn.Size = new System.Drawing.Size(112, 34);
            this.del_btn.TabIndex = 9;
            this.del_btn.Text = "Delete";
            this.del_btn.UseVisualStyleBackColor = true;
            this.del_btn.Click += new System.EventHandler(this.del_btn_Click);
            // 
            // invoice_total_lbl
            // 
            this.invoice_total_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.invoice_total_lbl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.invoice_total_lbl.Location = new System.Drawing.Point(841, 413);
            this.invoice_total_lbl.Name = "invoice_total_lbl";
            this.invoice_total_lbl.Size = new System.Drawing.Size(550, 43);
            this.invoice_total_lbl.TabIndex = 15;
            this.invoice_total_lbl.Text = "Total: £ 0.0";
            this.invoice_total_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buildInvoice_pdf
            // 
            this.buildInvoice_pdf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buildInvoice_pdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buildInvoice_pdf.Image = ((System.Drawing.Image)(resources.GetObject("buildInvoice_pdf.Image")));
            this.buildInvoice_pdf.Location = new System.Drawing.Point(819, 516);
            this.buildInvoice_pdf.Name = "buildInvoice_pdf";
            this.buildInvoice_pdf.Size = new System.Drawing.Size(52, 57);
            this.buildInvoice_pdf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.buildInvoice_pdf.TabIndex = 17;
            this.buildInvoice_pdf.TabStop = false;
            this.buildInvoice_pdf.Visible = false;
            this.buildInvoice_pdf.Click += new System.EventHandler(this.buildInvoice_pdf_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MOTreminderMenu,
            this.settingsMenu,
            this.aboutMenu});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(1433, 33);
            this.menuStrip1.TabIndex = 19;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // MOTreminderMenu
            // 
            this.MOTreminderMenu.Name = "MOTreminderMenu";
            this.MOTreminderMenu.Size = new System.Drawing.Size(154, 29);
            this.MOTreminderMenu.Text = "MOT Reminders";
            // 
            // settingsMenu
            // 
            this.settingsMenu.Name = "settingsMenu";
            this.settingsMenu.Size = new System.Drawing.Size(92, 29);
            this.settingsMenu.Text = "Settings";
            // 
            // aboutMenu
            // 
            this.aboutMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenuUpdate,
            this.submenuAbout});
            this.aboutMenu.Name = "aboutMenu";
            this.aboutMenu.Size = new System.Drawing.Size(78, 29);
            this.aboutMenu.Text = "About";
            // 
            // submenuUpdate
            // 
            this.submenuUpdate.Name = "submenuUpdate";
            this.submenuUpdate.Size = new System.Drawing.Size(258, 34);
            this.submenuUpdate.Text = "Check for updates";
            this.submenuUpdate.Click += new System.EventHandler(this.submenuUpdate_ItemClicked);
            // 
            // submenuAbout
            // 
            this.submenuAbout.Name = "submenuAbout";
            this.submenuAbout.Size = new System.Drawing.Size(258, 34);
            this.submenuAbout.Text = "About";
            this.submenuAbout.Click += new System.EventHandler(this.submenuAbout_ItemClicked);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 1044);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1433, 32);
            this.statusStrip1.TabIndex = 20;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(179, 25);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // vehicleGroupBox
            // 
            this.vehicleGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vehicleGroupBox.Controls.Add(this.reminderChk);
            this.vehicleGroupBox.Controls.Add(this.vehicleSaveBtn);
            this.vehicleGroupBox.Controls.Add(this.vehicleDelBtn);
            this.vehicleGroupBox.Controls.Add(this.registration_txt);
            this.vehicleGroupBox.Controls.Add(this.label4);
            this.vehicleGroupBox.Controls.Add(this.model_txt);
            this.vehicleGroupBox.Controls.Add(this.label3);
            this.vehicleGroupBox.Controls.Add(this.make_txt);
            this.vehicleGroupBox.Controls.Add(this.label2);
            this.vehicleGroupBox.Controls.Add(this.mot_date);
            this.vehicleGroupBox.Controls.Add(this.label1);
            this.vehicleGroupBox.Controls.Add(this.vehicles_list);
            this.vehicleGroupBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.vehicleGroupBox.Location = new System.Drawing.Point(12, 231);
            this.vehicleGroupBox.Name = "vehicleGroupBox";
            this.vehicleGroupBox.Size = new System.Drawing.Size(1409, 191);
            this.vehicleGroupBox.TabIndex = 21;
            this.vehicleGroupBox.TabStop = false;
            this.vehicleGroupBox.Text = "Vehicles";
            // 
            // reminderChk
            // 
            this.reminderChk.AutoSize = true;
            this.reminderChk.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.reminderChk.Location = new System.Drawing.Point(1002, 147);
            this.reminderChk.Name = "reminderChk";
            this.reminderChk.Size = new System.Drawing.Size(139, 29);
            this.reminderChk.TabIndex = 36;
            this.reminderChk.Text = "Set reminder";
            this.reminderChk.UseVisualStyleBackColor = true;
            // 
            // vehicleSaveBtn
            // 
            this.vehicleSaveBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.vehicleSaveBtn.Image = ((System.Drawing.Image)(resources.GetObject("vehicleSaveBtn.Image")));
            this.vehicleSaveBtn.Location = new System.Drawing.Point(1344, 46);
            this.vehicleSaveBtn.Name = "vehicleSaveBtn";
            this.vehicleSaveBtn.Size = new System.Drawing.Size(30, 30);
            this.vehicleSaveBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.vehicleSaveBtn.TabIndex = 35;
            this.vehicleSaveBtn.TabStop = false;
            this.vehicleSaveBtn.Click += new System.EventHandler(this.vehicleSaveBtn_Click);
            // 
            // vehicleDelBtn
            // 
            this.vehicleDelBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.vehicleDelBtn.Image = ((System.Drawing.Image)(resources.GetObject("vehicleDelBtn.Image")));
            this.vehicleDelBtn.Location = new System.Drawing.Point(1344, 104);
            this.vehicleDelBtn.Name = "vehicleDelBtn";
            this.vehicleDelBtn.Size = new System.Drawing.Size(30, 30);
            this.vehicleDelBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.vehicleDelBtn.TabIndex = 34;
            this.vehicleDelBtn.TabStop = false;
            this.vehicleDelBtn.Click += new System.EventHandler(this.vehicleDelBtn_Click);
            // 
            // registration_txt
            // 
            this.registration_txt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.registration_txt.Location = new System.Drawing.Point(591, 96);
            this.registration_txt.Name = "registration_txt";
            this.registration_txt.Size = new System.Drawing.Size(180, 31);
            this.registration_txt.TabIndex = 33;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(482, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 25);
            this.label4.TabIndex = 32;
            this.label4.Text = "Registration";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // model_txt
            // 
            this.model_txt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.model_txt.Location = new System.Drawing.Point(1054, 46);
            this.model_txt.Name = "model_txt";
            this.model_txt.Size = new System.Drawing.Size(248, 31);
            this.model_txt.TabIndex = 31;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(985, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 25);
            this.label3.TabIndex = 30;
            this.label3.Text = "Model";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // make_txt
            // 
            this.make_txt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.make_txt.Location = new System.Drawing.Point(591, 43);
            this.make_txt.Name = "make_txt";
            this.make_txt.Size = new System.Drawing.Size(348, 31);
            this.make_txt.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(527, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 25);
            this.label2.TabIndex = 28;
            this.label2.Text = "Make";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mot_date
            // 
            this.mot_date.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.mot_date.Location = new System.Drawing.Point(1002, 96);
            this.mot_date.Name = "mot_date";
            this.mot_date.Size = new System.Drawing.Size(300, 31);
            this.mot_date.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(844, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 25);
            this.label1.TabIndex = 27;
            this.label1.Text = "MOT expire date";
            // 
            // vehicles_list
            // 
            this.vehicles_list.FormattingEnabled = true;
            this.vehicles_list.ItemHeight = 25;
            this.vehicles_list.Location = new System.Drawing.Point(21, 42);
            this.vehicles_list.Name = "vehicles_list";
            this.vehicles_list.Size = new System.Drawing.Size(354, 104);
            this.vehicles_list.TabIndex = 25;
            this.vehicles_list.SelectedIndexChanged += new System.EventHandler(this.vehicles_list_SelectedIndexChanged);
            // 
            // invoiceGroupBox
            // 
            this.invoiceGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.invoiceGroupBox.Controls.Add(this.invoice_number_title);
            this.invoiceGroupBox.Controls.Add(this.invoice_number);
            this.invoiceGroupBox.Controls.Add(this.invoice_date);
            this.invoiceGroupBox.Controls.Add(this.save_btn);
            this.invoiceGroupBox.Controls.Add(this.del_btn);
            this.invoiceGroupBox.Controls.Add(this.buildInvoice_pdf);
            this.invoiceGroupBox.Controls.Add(this.date_title);
            this.invoiceGroupBox.Controls.Add(this.invoice_total_lbl);
            this.invoiceGroupBox.Controls.Add(this.notes_title);
            this.invoiceGroupBox.Controls.Add(this.notes_txt);
            this.invoiceGroupBox.Controls.Add(this.job_items_table);
            this.invoiceGroupBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.invoiceGroupBox.Location = new System.Drawing.Point(12, 428);
            this.invoiceGroupBox.Name = "invoiceGroupBox";
            this.invoiceGroupBox.Size = new System.Drawing.Size(1409, 602);
            this.invoiceGroupBox.TabIndex = 22;
            this.invoiceGroupBox.TabStop = false;
            this.invoiceGroupBox.Text = "Invoice";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1433, 1076);
            this.Controls.Add(this.invoiceGroupBox);
            this.Controls.Add(this.vehicleGroupBox);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "REMO SERVICE CENTRE";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customerSaveBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerDelBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clearFieldsBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.job_items_table)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buildInvoice_pdf)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.vehicleGroupBox.ResumeLayout(false);
            this.vehicleGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vehicleSaveBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vehicleDelBtn)).EndInit();
            this.invoiceGroupBox.ResumeLayout(false);
            this.invoiceGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

        #endregion
        private System.Windows.Forms.Label address_title;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox invoice_number;
        private System.Windows.Forms.TextBox email_txt;
        private System.Windows.Forms.TextBox phone_txt;
        private System.Windows.Forms.TextBox address_txt;
        private System.Windows.Forms.TextBox name_txt;
        private System.Windows.Forms.TextBox notes_txt;
        private System.Windows.Forms.Label notes_title;
        private System.Windows.Forms.DataGridView job_items_table;
        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.Button del_btn;
        private System.Windows.Forms.Label invoice_number_title;
        private System.Windows.Forms.PictureBox clearFieldsBtn;
        private System.Windows.Forms.PictureBox searchBtn;
        private System.Windows.Forms.TextBox post_code_txt;
        private System.Windows.Forms.Label post_code_title;
        private System.Windows.Forms.Label invoice_total_lbl;
        private System.Windows.Forms.Label date_title;
        private System.Windows.Forms.DateTimePicker invoice_date;
        private System.Windows.Forms.PictureBox buildInvoice_pdf;
        private System.Windows.Forms.CheckBox email_title;
        private System.Windows.Forms.CheckBox name_title;
        private System.Windows.Forms.CheckBox phone_title;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutMenu;
        private System.Windows.Forms.ToolStripMenuItem submenuUpdate;
        private System.Windows.Forms.ToolStripMenuItem submenuAbout;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.GroupBox vehicleGroupBox;
        private System.Windows.Forms.GroupBox invoiceGroupBox;
        private System.Windows.Forms.ListBox customers_list;
        private System.Windows.Forms.ListBox vehicles_list;
        private System.Windows.Forms.TextBox model_txt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox make_txt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker mot_date;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox registration_txt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox customerSaveBtn;
        private System.Windows.Forms.PictureBox customerDelBtn;
        private System.Windows.Forms.PictureBox vehicleSaveBtn;
        private System.Windows.Forms.PictureBox vehicleDelBtn;
        private System.Windows.Forms.CheckBox reminderChk;
        private System.Windows.Forms.ToolStripMenuItem settingsMenu;
        private System.Windows.Forms.ToolStripMenuItem MOTreminderMenu;
    }
}

