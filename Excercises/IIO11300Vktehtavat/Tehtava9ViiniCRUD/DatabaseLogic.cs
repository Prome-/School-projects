using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT.IIO11300
{
    public static class DBViini
    {
        public static DataTable GetAllCustomersData()
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection conn = new SqlConnection(Tehtava9ViiniCRUD.Properties.Settings.Default.Tietokanta))
                {
                    conn.Open();
                    string sqlString = "SELECT firstname, lastname, address, city FROM vCustomers";
                  //  SqlCommand command = new SqlCommand(sqlString, conn);
                    SqlDataAdapter da = new SqlDataAdapter(sqlString, conn);

                    da.Fill(dt);
                    conn.Close();
                }
                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void UpdateWorker(DataTable dt)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Tehtava9ViiniCRUD.Properties.Settings.Default.Tietokanta))
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter();

                    da.UpdateCommand = new SqlCommand("UPDATE worker SET Fname = @newFname, Lname = @newLname, Addr = @newAddr, Phone = @newPhone, Other = @newOther " +
                        "WHERE (Fname = @oldFname) AND (Lname = @oldLname) AND (Addr = @oldAddr) AND (Phone = @oldPhone) AND (Other = @oldOther)", conn);

                    SqlParameter param1 = da.UpdateCommand.Parameters.Add("@oldFname", SqlDbType.NVarChar, 20, "Fname");
                    param1.SourceVersion = DataRowVersion.Original;
                    SqlParameter param2 = da.UpdateCommand.Parameters.Add("@oldLname", SqlDbType.NVarChar, 30, "Lname");
                    param2.SourceVersion = DataRowVersion.Original;
                    SqlParameter param3 = da.UpdateCommand.Parameters.Add("@oldAddr", SqlDbType.NVarChar, 80, "Addr");
                    param3.SourceVersion = DataRowVersion.Original;
                    SqlParameter param4 = da.UpdateCommand.Parameters.Add("@oldPhone", SqlDbType.NVarChar, 20, "Phone");
                    param4.SourceVersion = DataRowVersion.Original;
                    SqlParameter param5 = da.UpdateCommand.Parameters.Add("@oldOther", SqlDbType.NVarChar, 40, "Other");
                    param5.SourceVersion = DataRowVersion.Original;

                    SqlParameter paramA = da.UpdateCommand.Parameters.Add("@newFname", SqlDbType.NVarChar, 20, "Fname");
                    paramA.SourceVersion = DataRowVersion.Current;
                    SqlParameter paramB = da.UpdateCommand.Parameters.Add("@newLname", SqlDbType.NVarChar, 30, "Lname");
                    paramB.SourceVersion = DataRowVersion.Current;
                    SqlParameter paramC = da.UpdateCommand.Parameters.Add("@newAddr", SqlDbType.NVarChar, 80, "Addr");
                    paramC.SourceVersion = DataRowVersion.Current;
                    SqlParameter paramD = da.UpdateCommand.Parameters.Add("@newPhone", SqlDbType.NVarChar, 20, "Phone");
                    paramD.SourceVersion = DataRowVersion.Current;
                    SqlParameter paramE = da.UpdateCommand.Parameters.Add("@newOther", SqlDbType.NVarChar, 40, "Other");
                    paramE.SourceVersion = DataRowVersion.Current;

                    da.Update(dt);
                    conn.Close();
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void AddWorker(string Fname, string Lname, string Addr, string city)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Tehtava9ViiniCRUD.Properties.Settings.Default.Tietokanta))
                {
                    conn.Open();
                    string sqlString =
                        "INSERT INTO vCustomer (firstname, lastname, address, city) VALUES ('" + Fname + "','" + Lname + "','" + Addr + "','" + city + "')";

                    SqlCommand command = new SqlCommand(sqlString, conn);
                    // Tutki kannattaako käyttää .executenonqueryasync
                    command.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void RemoveWorker(string Fname, string Lname, string Addr, string city)
        {
            try
            {                
                using (SqlConnection conn = new SqlConnection(Tehtava9ViiniCRUD.Properties.Settings.Default.Tietokanta))
                {
                    conn.Open();
                    string sqlString = "DELETE FROM vCustomer WHERE (firstname IS '" + Fname + "') AND (lastname IS '" + Lname + "') AND (address IS '" + Addr + "') AND (city IS '" + city + "')";
                    SqlCommand command = new SqlCommand(sqlString, conn);
                    command.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}