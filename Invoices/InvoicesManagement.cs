using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Invoice_Management.Invoices
{
    class InvoicesManagement
    {
        private string connString;
        private Vehicle_Management.MainForm.loadedInvoiceStruct loadedInvoice= new Vehicle_Management.MainForm.loadedInvoiceStruct();
        
        public InvoicesManagement(string _connString, Vehicle_Management.MainForm.loadedInvoiceStruct _loadedInvoice) {
            this.connString = _connString;
            this.loadedInvoice = _loadedInvoice;

        }
//*************************************************************************************************************
        public void deleteInvoiceOnDB(int id)
        {
            using (var factory = new System.Data.SQLite.SQLiteFactory())
            {
                using (System.Data.Common.DbConnection dbConn = factory.CreateConnection())
                {
                    dbConn.ConnectionString = this.connString;
                    dbConn.Open();
                    using (System.Data.Common.DbCommand cmd = dbConn.CreateCommand())
                    {
                        //del customer
                        cmd.CommandText = @"delete from customers where customerId='" + this.loadedInvoice.invoice.ElementAt(id)[1] + "'";
                        cmd.ExecuteNonQuery();
                        //del invoice
                        cmd.CommandText = @"delete from invoices where invoiceId='" + this.loadedInvoice.invoice.ElementAt(id)[0] + "'";
                        cmd.ExecuteNonQuery();

                        //del job tasks
                        cmd.CommandText = @"delete from jobs where invoiceId='" + this.loadedInvoice.invoice.ElementAt(id)[0] + "'";
                        cmd.ExecuteNonQuery();

                    }
                    if (dbConn.State != System.Data.ConnectionState.Closed) dbConn.Close();
                    dbConn.Dispose();
                    factory.Dispose();
                }
            }
        }
        //*************************************************************************************************************

        // ******************************************************************************************************************
        private DbParameter buildParameter(System.Data.Common.DbCommand cmd, String tableField, object tableValue)
        {
            DbParameter Columnvalue = cmd.CreateParameter();

            Columnvalue.ParameterName = tableField;
            Columnvalue.Value = tableValue;

            return Columnvalue;
        }
        //*************************************************************************************************************
        public void editInvoiceOnDatabase(ref DataGridView job_items_table, ref ComboBox invoice_number, ref TextBox notes_txt)
        {
            using (var factory = new System.Data.SQLite.SQLiteFactory())
            {
                using (System.Data.Common.DbConnection dbConn = factory.CreateConnection())
                {
                    dbConn.ConnectionString = connString;
                    dbConn.Open();
                    using (System.Data.Common.DbCommand cmd = dbConn.CreateCommand())
                    {
                        cmd.CommandText = @"update invoices set notes='" + notes_txt.Text.ToString() + "' where invoiceId='" + loadedInvoice.invoice.ElementAt(invoice_number.SelectedIndex - 1)[0] + "'";
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = @"delete from jobs where invoiceId='" + loadedInvoice.invoice.ElementAt(invoice_number.SelectedIndex - 1)[0] + "'";
                        cmd.ExecuteNonQuery();

                        System.Int64 invoiceId = long.Parse(loadedInvoice.invoice.ElementAt(invoice_number.SelectedIndex - 1)[0]);
                        //add job tasks
                        for (int i = 0; i < job_items_table.RowCount; i++)
                        {
                            if (job_items_table[0, i].Value != null && job_items_table[1, i].Value != null)
                            {
                                cmd.CommandText = @"INSERT INTO jobs (invoiceId, description, cost) VALUES(@invoiceId, @description, @cost)";
                                cmd.Parameters.Add(buildParameter(cmd, "@invoiceId", invoiceId));
                                cmd.Parameters.Add(buildParameter(cmd, "@description", job_items_table[0, i].Value.ToString()));
                                cmd.Parameters.Add(buildParameter(cmd, "@cost", job_items_table[1, i].Value.ToString()));
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    if (dbConn.State != System.Data.ConnectionState.Closed) dbConn.Close();
                    dbConn.Dispose();
                    factory.Dispose();
                }
            }

        }
        //************************************************************************************
        public string addNewInvoiceToDatabase(string customerId, string vehicleId, ref DataGridView job_items_table, ref DateTimePicker invoice_date, ref TextBox notes_txt)
        {

            System.Int64 invoiceId;
            using(var factory = new System.Data.SQLite.SQLiteFactory())
            {
                using (System.Data.Common.DbConnection dbConn = factory.CreateConnection())
                {
                    dbConn.ConnectionString = connString;
                    dbConn.Open();
                    using (System.Data.Common.DbCommand cmd = dbConn.CreateCommand())
                    {
 
                        //add invoice
                        cmd.CommandText = @"INSERT INTO invoices (customerId, vehicleId, notes, invoiceDate) VALUES(@customerId, @vehicleId, @notes, @invoiceDate)";
                        cmd.Parameters.Add(buildParameter(cmd, "@customerId", customerId));
                        cmd.Parameters.Add(buildParameter(cmd, "@vehicleId", vehicleId));
                        cmd.Parameters.Add(buildParameter(cmd, "@notes", notes_txt.Text.ToString()));
                        cmd.Parameters.Add(buildParameter(cmd, "@invoiceDate", invoice_date.Value.Date.ToString("yyyy-MM-dd")));
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = @"select last_insert_rowid()";
                        invoiceId = (System.Int64)cmd.ExecuteScalar();
                        
                        //add job tasks
                        for (int i = 0; i < job_items_table.RowCount; i++)
                        {
                            if (job_items_table[0, i].Value != null && job_items_table[1, i].Value != null)
                            {
                                cmd.CommandText = @"INSERT INTO jobs (invoiceId, description, cost) VALUES(@invoiceId, @description, @cost)";
                                cmd.Parameters.Add(buildParameter(cmd, "@invoiceId", invoiceId));
                                cmd.Parameters.Add(buildParameter(cmd, "@description", job_items_table[0, i].Value.ToString()));
                                cmd.Parameters.Add(buildParameter(cmd, "@cost", job_items_table[1, i].Value.ToString()));
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    if (dbConn.State != System.Data.ConnectionState.Closed) dbConn.Close();
                    dbConn.Dispose();
                    factory.Dispose();
                }
            }
            return invoiceId.ToString();
        }
//*****************************************************************************************************************
    }
}
