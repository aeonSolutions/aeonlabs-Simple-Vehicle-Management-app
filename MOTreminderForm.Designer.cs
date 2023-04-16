
namespace Invoice_Management
{
    partial class MOTreminderForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.customersList = new System.Windows.Forms.ListBox();
            this.SendBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // customersList
            // 
            this.customersList.FormattingEnabled = true;
            this.customersList.ItemHeight = 25;
            this.customersList.Location = new System.Drawing.Point(12, 31);
            this.customersList.Name = "customersList";
            this.customersList.Size = new System.Drawing.Size(776, 229);
            this.customersList.TabIndex = 0;
            this.customersList.SelectedIndexChanged += new System.EventHandler(this.customersList_SelectedIndexChanged);
            // 
            // SendBtn
            // 
            this.SendBtn.Location = new System.Drawing.Point(676, 308);
            this.SendBtn.Name = "SendBtn";
            this.SendBtn.Size = new System.Drawing.Size(112, 34);
            this.SendBtn.TabIndex = 1;
            this.SendBtn.Text = "Close";
            this.SendBtn.UseVisualStyleBackColor = true;
            this.SendBtn.Click += new System.EventHandler(this.SendBtn_Click);
            // 
            // MOTreminderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 357);
            this.Controls.Add(this.SendBtn);
            this.Controls.Add(this.customersList);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MOTreminderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MOT reminders";
            this.Load += new System.EventHandler(this.MOTreminderForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox customersList;
        private System.Windows.Forms.Button SendBtn;
    }
}