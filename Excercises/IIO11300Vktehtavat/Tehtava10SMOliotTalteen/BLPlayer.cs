using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel;

namespace JAMK.IT.IIO11300
{
    [Serializable]
    public class Player : INotifyPropertyChanged
    {
        #region PROPERTIES

        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                Notify("FirstName");
            }            
        }

        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                Notify("LastName");
            }
        }
        public string FullName
        {
            get { return LastName + " " + FirstName; }
        }

        public string PresentationName
        {
            get { return FirstName + " " + LastName + ", " + Team; }
        }

        private int transfer;

        public int Transfer
        {
            get { return transfer; }
            set
            {
                transfer = value;
                Notify("Transfer");
            }
        }

        private string team;

        public string Team
        {
            get { return team; }
            set
            {
                team = value;
                Notify("Team");
            }
        }

        #endregion
        #region CONSTRUCTORS

        public Player() { }

        public Player(string fname, string lname, string tm, int tcost)
        {
            this.firstName = fname;
            this.lastName = lname;
            this.team = tm;
            this.transfer = tcost;
        }
        #endregion

        #region METHODS
        public override string ToString()
        {
            return PresentationName;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void Notify(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        #endregion

    }

    public class Liiga
    {
        #region METHODS

        public static List<Player> GetPlayers()
        {
            try
            {
                List<Team> teams = GetTeams();
                List<Player> players = new List<Player>();
                DataTable dtPlayers = new DataTable();
                dtPlayers = DBPlayer.GetAllPlayers();

                foreach (DataRow dr in dtPlayers.Rows)
                {
                    players.Add(new Player(dr["Fname"].ToString(), dr["Lname"].ToString(), dr["TeamName"].ToString(), Convert.ToInt32(dr["Transfer"])));
                }
                return players;
            }

            catch (Exception ex)
            {
                throw ex;
            }


        }

        public static List<Team> GetTeams()
        {
            try
            {                
                DataTable dtTeams = new DataTable();
                dtTeams = DBPlayer.GetAllTeams();

                List<Team> teams = new List<Team>();

                foreach (DataRow dr in dtTeams.Rows)
                {
                    teams.Add(new Team(Convert.ToInt32(dr["PKey"].ToString()) ,dr["Name"].ToString()));
                }

                return teams;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void UpdatePlayers(List<Player> players)
        {
            try
            {
                // Rakensin arkkitehtuurin datatablen ympärille, mutta en oivaltanut ennen koodin valmistumista että uutta datatablea luodessa kaikki rivit ovat uusia, joten ne kaikki lisätään kantaan duplikaatteina
                // En keksinyt nopeaa keinoa kiertää datatablen tuottamat ongelmat. Aika loppuu kesken, joten tämän on kelvattava.

                List<Team> teams = new List<Team>();
                teams = GetTeams();

                DataTable dt = new DataTable();

                  dt.Columns.Add("Fname", typeof(string));
                  dt.Columns.Add("Lname", typeof(string));
                  dt.Columns.Add("Transfer", typeof(int));
                  dt.Columns.Add("Team", typeof(int));

                  foreach (Player player in players)
                  {
                      DataRow row = dt.NewRow();

                      row["Fname"] = player.FirstName;
                      row["Lname"] = player.LastName;
                      row["Transfer"] = player.Transfer;
                      foreach(Team team in teams)
                      {
                          if(player.Team == team.Name)
                          {
                              row["Team"] = team.Key;
                          }
                      }

                      dt.Rows.Add(row);


                  }

                  DBPlayer.UpdateWorker(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }

    public class Team
    {
        #region PROPERTIES

        private int key;

        public int Key
        {
            get { return key; }
            set { key = value; }
        }


        private string name;

        public string Name
        {
            get { return name; }
        }

        #endregion

        #region CONSTRUCTORS

        //public Team() { }
        public Team(int PKey ,string TeamName)
        {
            this.key = PKey;
            this.name = TeamName;
        }

        #endregion
        #region METHODS
        public override string ToString()
        {
            return name; 
        }
        #endregion
    }
}
