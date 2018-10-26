using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT.IIO11300
{
    public static class DBCustomer
    {
        public static DataTable GetAllCustomersData()
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection conn = new SqlConnection(Tehtava9ViiniAsiakkaatCRUD.Properties.Settings.Default.Tietokanta))
                {
                    conn.Open();
                    string sqlString = "SELECT * FROM customer";
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

        public static void UpdateCustomers(DataTable dt)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Tehtava9ViiniAsiakkaatCRUD.Properties.Settings.Default.Tietokanta))
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter();

                    //da.InsertCommand = new SqlCommand("INSERT INTO vCustomers (firstname, lastname, address, city) VALUES (@Fname, @Lname, @Addr, @City)", conn);

                    //da.DeleteCommand = new SqlCommand("DELETE FROM vCustomers WHERE (firstname IS @oldFname) AND (lastname IS @oldLname) AND (address IS @oldAddr) AND (city IS @oldCity)", conn);

                    da.UpdateCommand = new SqlCommand("UPDATE customer SET firstname = @newFname, lastname = @newLname, address = @newAddr, zip = @newZIP, city = @newCity " +
                        "WHERE (firstname = @oldFname) AND (lastname = @oldLname) AND (address = @oldAddr) AND (zip = @oldZIP) AND (city = @oldCity)", conn);


                    SqlParameter param1 = da.UpdateCommand.Parameters.Add("@oldFname", SqlDbType.NVarChar, 20, "firstname");
                    param1.SourceVersion = DataRowVersion.Original;
                    SqlParameter param2 = da.UpdateCommand.Parameters.Add("@oldLname", SqlDbType.NVarChar, 30, "lastname");
                    param2.SourceVersion = DataRowVersion.Original;
                    SqlParameter param3 = da.UpdateCommand.Parameters.Add("@oldAddr", SqlDbType.NVarChar, 80, "address");
                    param3.SourceVersion = DataRowVersion.Original;
                    SqlParameter param4 = da.UpdateCommand.Parameters.Add("@oldZIP", SqlDbType.NVarChar, 10, "zip");
                    param4.SourceVersion = DataRowVersion.Original;
                    SqlParameter param5 = da.UpdateCommand.Parameters.Add("@oldCity", SqlDbType.NVarChar, 20, "city");
                    param4.SourceVersion = DataRowVersion.Original;
                    
                    SqlParameter paramA = da.UpdateCommand.Parameters.Add("@newFname", SqlDbType.NVarChar, 20, "firstname");
                    paramA.SourceVersion = DataRowVersion.Current;
                    SqlParameter paramB = da.UpdateCommand.Parameters.Add("@newLname", SqlDbType.NVarChar, 30, "lastname");
                    paramB.SourceVersion = DataRowVersion.Current;
                    SqlParameter paramC = da.UpdateCommand.Parameters.Add("@newAddr", SqlDbType.NVarChar, 80, "address");
                    paramC.SourceVersion = DataRowVersion.Current;
                    SqlParameter paramD = da.UpdateCommand.Parameters.Add("@newZIP", SqlDbType.NVarChar, 10, "zip");
                    paramD.SourceVersion = DataRowVersion.Current;
                    SqlParameter paramE = da.UpdateCommand.Parameters.Add("@newCity", SqlDbType.NVarChar, 40, "city");
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

        public static void AddCustomer(string Fname, string Lname, string Addr, string ZIP, string City)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Tehtava9ViiniAsiakkaatCRUD.Properties.Settings.Default.Tietokanta))
                {
                    conn.Open();
                    string sqlString =
                        "INSERT INTO customer (Firstname, Lastname, Address, ZIP, City) VALUES ('"+ Fname + "','" + Lname + "','" + Addr + "','" + ZIP + "','" + City + "')";

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

        public static void RemoveCustomer(string ID, string Fname, string Lname, string Addr, string ZIP, string City)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Tehtava9ViiniAsiakkaatCRUD.Properties.Settings.Default.Tietokanta))
                {
                    conn.Open();
                    string sqlString = "DELETE FROM customer WHERE (ID = '"+ ID +"') AND (Firstname = '" + Fname + "') AND (Lastname = '" + Lname + "') AND (Address = '" + Addr + "') AND (ZIP = '" + ZIP + "') AND (City = '" + City + "')";
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