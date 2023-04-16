using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Invoice_Management.Vehicles
{
    class VehiclesManagement
    {

        private string connString;
        private Vehicle_Management.MainForm.loadedInvoiceStruct loadedInvoice = new Vehicle_Management.MainForm.loadedInvoiceStruct();

        public VehiclesManagement(string _connString, Vehicle_Management.MainForm.loadedInvoiceStruct _loadedInvoice)
        {
            this.connString = _connString;
            this.loadedInvoice = _loadedInvoice;

        }
        //*************************************************************************************************************
        public void deleteVehicleOnDB(int id)
        {
            using (var factory = new System.Data.SQLite.SQLiteFactory())
            {
                using (System.Data.Common.DbConnection dbConn = factory.CreateConnection())
                {
                    dbConn.ConnectionString = this.connString;
                    dbConn.Open();
                    using (System.Data.Common.DbCommand cmd = dbConn.CreateCommand())
                    {
                        //del job tasks
                        cmd.CommandText = @"delete from vehicles where vehicleId='" + this.loadedInvoice.vehicles.ElementAt(id)[0] + "'";
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
        public void editVehicleOnDatabase( string vehicleId, ref TextBox make_txt, ref TextBox model_txt, ref TextBox registration_txt, ref DateTimePicker mot_date, string reminder)
        {
            using (var factory = new System.Data.SQLite.SQLiteFactory())
            {
                using (System.Data.Common.DbConnection dbConn = factory.CreateConnection())
                {
                    dbConn.ConnectionString = connString;
                    dbConn.Open();
                    using (System.Data.Common.DbCommand cmd = dbConn.CreateCommand())
                    {
                        //edit vehicle
                        cmd.CommandText = @"update vehicles set reminderSent='0', setReminder='"+ reminder +"', make='" + make_txt.Text.ToString() + "', model='" + model_txt.Text.ToString() + "', registration='" + registration_txt.Text.ToString() + "', motDate='"+ mot_date.Value.Date.ToString("yyyy-MM-dd") + "' where vehicleId='" + vehicleId + "'";
                        cmd.ExecuteNonQuery();

                    }
                    if (dbConn.State != System.Data.ConnectionState.Closed) dbConn.Close();
                    dbConn.Dispose();
                    factory.Dispose();
                }
            }

        }
        //************************************************************************************
        public void addNewVehicleToDatabase(string customerId, ref TextBox make_txt, ref TextBox model_txt, ref TextBox registration_txt, ref DateTimePicker mot_date, string reminder)
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
                        cmd.CommandText = @"INSERT INTO vehicles (customerId, model, make, registration, motDate, setReminder, reminderSent) VALUES(@customerId, @model, @make, @registration, @motDate, @setReminder, @reminderSent)";
                        cmd.Parameters.Add(buildParameter(cmd, "@customerId", customerId));
                        cmd.Parameters.Add(buildParameter(cmd, "@model", model_txt.Text.ToString()));
                        cmd.Parameters.Add(buildParameter(cmd, "@make", make_txt.Text.ToString()));
                        cmd.Parameters.Add(buildParameter(cmd, "@registration", registration_txt.Text.ToString()));
                        cmd.Parameters.Add(buildParameter(cmd, "@motDate", mot_date.Value.Date.ToString("yyyy-MM-dd")));
                        cmd.Parameters.Add(buildParameter(cmd, "@setReminder", reminder));
                        cmd.Parameters.Add(buildParameter(cmd, "@reminderSent", "0"));

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
