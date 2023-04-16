using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Vehicle_Management;

namespace Invoice_Management.Customers
{
    class CustomersManagement
    {

        private string connString;
        private Vehicle_Management.MainForm.loadedInvoiceStruct loadedInvoice = new Vehicle_Management.MainForm.loadedInvoiceStruct();

        public CustomersManagement(string _connString, Vehicle_Management.MainForm.loadedInvoiceStruct _loadedInvoice)
        {
            this.connString = _connString;
            this.loadedInvoice = _loadedInvoice;

        }
        //*************************************************************************************************************
        public void deleteCustomerOnDB(int id)
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
                        cmd.CommandText = @"delete from customers where customerId='" + this.loadedInvoice.customers.ElementAt(id)[0] + "'";
                        cmd.ExecuteNonQuery();

                        //del vehicles
                        cmd.CommandText = @"delete from vehicles where customerId='" + this.loadedInvoice.customers.ElementAt(id)[0] + "'";
                        cmd.ExecuteNonQuery();

                        List<string[]> invoicesDel = MainForm.QueryDB("select invoiceId from invoices where customerId='"+ this.loadedInvoice.customers.ElementAt(id)[0] + "'");
                        if (invoicesDel.Count>0) {
                            for (int i=0; i< invoicesDel.Count;i++) {
                                //del job tasks
                                cmd.CommandText = @"delete from jobs where invoiceId='" + invoicesDel.ElementAt(i)[0] + "'";
                                cmd.ExecuteNonQuery();
                            }
                        }

                        //del invoice
                        cmd.CommandText = @"delete from invoices where customerId='" + this.loadedInvoice.customers.ElementAt(id)[0] + "'";
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
        public void editCustomerOnDatabase( string customerId, ref TextBox name_txt, ref TextBox address_txt, ref TextBox phone_txt, ref TextBox email_txt, ref TextBox post_code_txt)
        {
            using (var factory = new System.Data.SQLite.SQLiteFactory())
            {
                using (System.Data.Common.DbConnection dbConn = factory.CreateConnection())
                {
                    dbConn.ConnectionString = connString;
                    dbConn.Open();
                    using (System.Data.Common.DbCommand cmd = dbConn.CreateCommand())
                    {
                        //add customer
                        cmd.CommandText = @"update customers set name='" + name_txt.Text.ToString() + "', address='" + address_txt.Text.ToString() + "', phone='" + phone_txt.Text.ToString() + "', email='" + email_txt.Text.ToString() + "', postal='" + post_code_txt.Text.ToString() + "' where customerId='" + customerId + "'";
                        cmd.ExecuteNonQuery();
                    }
                    if (dbConn.State != System.Data.ConnectionState.Closed) dbConn.Close();
                    dbConn.Dispose();
                    factory.Dispose();
                }
            }

        }
        //************************************************************************************
        public void addNewCustomerToDatabase( ref TextBox name_txt, ref TextBox address_txt, ref TextBox phone_txt, ref TextBox email_txt, ref TextBox post_code_txt)
        {
            using (var factory = new System.Data.SQLite.SQLiteFactory())
            {
                using (System.Data.Common.DbConnection dbConn = factory.CreateConnection())
                {
                    dbConn.ConnectionString = connString;
                    dbConn.Open();
                    using (System.Data.Common.DbCommand cmd = dbConn.CreateCommand())
                    {
                        //add customer
                        cmd.CommandText = @"INSERT INTO customers (name, address, phone, email, postal) VALUES(@name, @address, @phone, @email, @postal)";
                        cmd.Parameters.Add(buildParameter(cmd, "@name", name_txt.Text.ToString()));
                        cmd.Parameters.Add(buildParameter(cmd, "@address", address_txt.Text.ToString()));
                        cmd.Parameters.Add(buildParameter(cmd, "@phone", phone_txt.Text.ToString()));
                        cmd.Parameters.Add(buildParameter(cmd, "@email", email_txt.Text.ToString()));
                        cmd.Parameters.Add(buildParameter(cmd, "@postal", post_code_txt.Text.ToString()));
                        cmd.ExecuteNonQuery();

                    }
                    if (dbConn.State != System.Data.ConnectionState.Closed) dbConn.Close();
                    dbConn.Dispose();
                    factory.Dispose();
                }
            }

        }
        //*****************************************************************************************************************

    }
}
