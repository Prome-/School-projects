using System;
using System.Collections.Generic;
using System.Data; // ADON:n perusluokat
using System.Data.SqlClient; // SQL-serveriä varten
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harjoitus7ADO
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // basic steps
                //1. Luodaan yhteys
                string connStr = GetConnectionString();
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    //avataan yhteys
                    conn.Open();
                    //2. Tehdään sql-kysely. Siitä luodaan Command-tyyppinen olio.
                    string sql = "SELECT asioid, lastname, firstname FROM Presences WHERE asioid='salesa'";
                    // annetaan konstruktorille komento ja yhteys
                    SqlCommand cmd = new SqlCommand(sql,conn);


                    //3. Käsitellään tulos, tässä DataReader-olio
                    SqlDataReader rdr = cmd.ExecuteReader();
                    // käydään reader-olio läpi, huom. forward only! Eli voi iteroida vaan eteenpäin
                    if(rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            Console.WriteLine("Läsnäolosi {0} {1} {2}", rdr.GetString(0), rdr.GetString(1), rdr.GetString(2));
                        }
                        Console.WriteLine("Tiedot haettu onnistuneesti!");
                    }
                    rdr.Close();
                    conn.Close();
                    Console.WriteLine("Tietokantayhteys suljettu");
                }




            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                // promptaa napinpainallus
                Console.ReadKey();
            }
        }

        private static string GetConnectionString()
        {
            //Luetaan string App.Configista
            return Harjoitus7ADO.Properties.Settings.Default.Tietokanta;
        }

    }
}
