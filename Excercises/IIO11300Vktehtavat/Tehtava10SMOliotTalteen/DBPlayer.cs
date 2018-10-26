using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;

namespace JAMK.IT.IIO11300
{
    class DBPlayer
    {
        public static DataTable GetAllPlayers()
        {
            try
            {
                DataTable dt = new DataTable();
                using (SQLiteConnection conn = new SQLiteConnection(Tehtava10SMOliotTalteen.Properties.Settings.Default.Tietokanta))
                {
                    conn.Open();
                    string sqlString = "SELECT P.Fname, P.Lname, P.Transfer, T.Name as TeamName FROM player as P JOIN team as T ON P.Team=T.PKey";
                    SQLiteDataAdapter da = new SQLiteDataAdapter(sqlString, conn);
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

        public static DataTable GetAllTeams()
        {
            try
            {
                DataTable dt = new DataTable();
                using (SQLiteConnection conn = new SQLiteConnection(Tehtava10SMOliotTalteen.Properties.Settings.Default.Tietokanta))
                {
                    conn.Open();
                    string sqlString = "SELECT * FROM team";
                    SQLiteDataAdapter da = new SQLiteDataAdapter(sqlString, conn);
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

        public static int UpdatePlayer(int id, string fname, string lname, int transfer, int team)
        {
            int lkm;
            using (SQLiteConnection conn = new SQLiteConnection(Tehtava10SMOliotTalteen.Properties.Settings.Default.Tietokanta))
            {
                conn.Open();
                string sqlString = string.Format("UPDATE player SET Fname=@Enimi, Lname = @sukunimi, Transfer='{1}', Team={2} WHERE PKey={0}", id, transfer, team);
                SQLiteCommand command = new SQLiteCommand(sqlString, conn);

                SQLiteParameter param;
                param = new SQLiteParameter("Enimi", SqlDbType.NVarChar);
                param.Value = fname;
                command.Parameters.Add(param);
                param = new SQLiteParameter("sukunimi", SqlDbType.NVarChar);
                param.Value = lname;
                command.Parameters.Add(param);

                lkm = command.ExecuteNonQuery();
                conn.Close();
            }
            return lkm;

        }

        public static void UpdateWorker(DataTable dt)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(Tehtava10SMOliotTalteen.Properties.Settings.Default.Tietokanta))
                {
                    conn.Open();
                    SQLiteDataAdapter da = new SQLiteDataAdapter();

                    da.UpdateCommand = new SQLiteCommand("UPDATE player SET Fname = @newFname, Lname = @newLname, Transfer = @newTransfer, Team = @newTeam" +
                        "WHERE (Fname = @oldFname) AND (Lname = @oldLname) AND (Transfer = @oldTransfer) AND (Team = @oldTeam)", conn);

                    SQLiteParameter param1 = da.UpdateCommand.Parameters.Add("@oldFname", DbType.String, 20, "Fname");
                    param1.SourceVersion = DataRowVersion.Original;
                    SQLiteParameter param2 = da.UpdateCommand.Parameters.Add("@oldLname", DbType.String, 30, "Lname");
                    param2.SourceVersion = DataRowVersion.Original;
                    SQLiteParameter param3 = da.UpdateCommand.Parameters.Add("@oldTransfer", DbType.Int32, 20, "Transfer");
                    param3.SourceVersion = DataRowVersion.Original;
                    SQLiteParameter param4 = da.UpdateCommand.Parameters.Add("@oldTeam", DbType.Int32, 20, "Team");
                    param4.SourceVersion = DataRowVersion.Original;

                    SQLiteParameter paramA = da.UpdateCommand.Parameters.Add("@newFname", DbType.String, 20, "Fname");
                    paramA.SourceVersion = DataRowVersion.Current;
                    SQLiteParameter paramB = da.UpdateCommand.Parameters.Add("@newLname", DbType.String, 30, "Lname");
                    paramB.SourceVersion = DataRowVersion.Current;
                    SQLiteParameter paramC = da.UpdateCommand.Parameters.Add("@newTransfer", DbType.Int32, 20, "Transfer");
                    paramC.SourceVersion = DataRowVersion.Current;
                    SQLiteParameter paramD = da.UpdateCommand.Parameters.Add("@newTeam", DbType.Int32, 20, "Team");
                    paramD.SourceVersion = DataRowVersion.Current;

                    da.InsertCommand = new SQLiteCommand("INSERT INTO player (Fname, Lname, Transfer, Team) VALUES (@Fname, @Lname, @Transfer, @Team)", conn);

                    da.InsertCommand.Parameters.Add("@Fname", DbType.String, 20, "Fname");
                    da.InsertCommand.Parameters.Add("@Lname", DbType.String, 30, "Lname");
                    da.InsertCommand.Parameters.Add("@Transfer", DbType.Int32, 20, "Transfer");
                    da.InsertCommand.Parameters.Add("@Team", DbType.Int32, 20, "Team");

                    da.DeleteCommand = new SQLiteCommand("DELETE FROM player WHERE (Fname = '@Fname') AND (Lname = '@Lname') AND (Transfer = '@Transfer') AND (Team = '@Team')", conn);
                    da.DeleteCommand.Parameters.Add("@Fname", DbType.String, 20, "Fname");
                    da.DeleteCommand.Parameters.Add("@Lname", DbType.String, 30, "Lname");
                    da.DeleteCommand.Parameters.Add("@Transfer", DbType.Int32, 20, "Transfer");
                    da.DeleteCommand.Parameters.Add("@Team", DbType.Int32, 20, "Team");

                    da.Update(dt);
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
