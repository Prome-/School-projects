using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace H9WanhojenKirjojenKauppaORM
{

    public class DBBooks
    {
        public static DataTable GetTestData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("author", typeof(string));
            dt.Columns.Add("country", typeof(string));
            dt.Columns.Add("year", typeof(int));

            dt.Rows.Add(11, "Pekka Lipposen seikkailut", "Alzheimer", "Suomi", 1946);
            dt.Rows.Add(11, "Lucky luke", "Nicke knackerton", "Suomi", 1946);

            return dt;
        }
        public static DataTable GetBooks(string connstr)
        {
            try
            {
                SqlDataAdapter da;
                DataTable dt;
                using (SqlConnection conn = new SqlConnection(connstr))
                {
                    conn.Open();
                    string sqlString = "SELECT id, name, author, country, year FROM books";
                    SqlCommand command = new SqlCommand(sqlString,conn);
                    da = new SqlDataAdapter(command);
                    dt = new DataTable("Books");
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

        public static int UpdateBook(string connstr, int id, string name, string author, string country, int year)
        {

            int lkm;
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                conn.Open();
                string sqlString = string.Format("UPDATE books SET name=@nimi, author = @kirjailija, country='{1}', year={2} WHERE id={0}", id, country, year);                
                SqlCommand command = new SqlCommand(sqlString, conn);

                SqlParameter param;
                param = new SqlParameter("nimi", SqlDbType.NVarChar);
                param.Value = name;
                command.Parameters.Add(param);
                param = new SqlParameter("kirjailija", SqlDbType.NVarChar);
                param.Value = author;
                command.Parameters.Add(param);                
                lkm = command.ExecuteNonQuery();
                conn.Close();
            }
            return lkm;
        }
    }
    
}
