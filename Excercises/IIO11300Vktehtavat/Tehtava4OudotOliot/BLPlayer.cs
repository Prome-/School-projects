using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace JAMK.IT.IIO11300
{
    public class Player
    { 

        #region PROPERTIES
        private string firstName;

            public string FirstName
            {
                get { return firstName; }
                set { firstName = value; }
            }

            private string lastName;

            public string LastName
            {
                get { return lastName; }
                set { lastName = value; }
            }

            public string FullName
            {
                get { return LastName+" "+FirstName; }
            }

            public string PresentationName
            {
                get { return FirstName+" "+LastName+", "+Team; }
            }

            private int transferCost;

            public int TransferCost
            {
                get { return transferCost; }
                set { transferCost = value; }
            }

            private string team;

            public string Team
            {
                get { return team; }
                set { team = value; }
            }

            private string face;

            public string Face
            {
                get { return face; }
                set { face = value; }
            }

            public string SaveForm
            {
                get { return FirstName + "," + LastName + "," + Team + "," + TransferCost + "," + Face;  }
            }


        #endregion
        #region CONSTRUCTORS

        public Player() { }

        public Player(string fname, string lname, string tm, int tcost, string faceName)
        {
            this.FirstName = fname;
            this.LastName = lname;
            this.Team = tm;
            this.TransferCost = tcost;
            this.face = faceName;
        }

        #endregion
        #region METHODS
        public static void saveDataToTxt(List<Player> playerList, string myFile)
        {
            try
            {
                // tutkitaan onko tiedosto olemassa
                if (!System.IO.File.Exists(myFile))
                {
                    // luodaan uusi tiedosto kun ei löytynyt
                    using (StreamWriter sw = File.CreateText(myFile))
                    {
                        // käydään kokoelma läpi ja kirjoitetaan kukin mittausdata omalle rivilleen
                        foreach (var item in playerList)
                        {
                            // DataMuoto on itse luotu mittausdata-luokan property joka sisältää paremman kirjoitusasun datalle
                            sw.WriteLine(item.SaveForm);
                        }
                    }
                }
                else
                {
                    // tyhjennetään tiedosto ettei data tuplaannu
                    File.WriteAllText(myFile, string.Empty);
                    // lisätään olemassaolevaan tiedostoon mittaustieto
                    using (StreamWriter sw = File.AppendText(myFile))
                    {
                        foreach (var item in playerList)
                        {
                            sw.WriteLine(item.SaveForm);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static List<Player> loadDataFromTxt(string myFile)
        {
            try
            {
                if(System.IO.File.Exists(myFile))
                {
                    using (StreamReader sr = File.OpenText(myFile))
                    {
                        Player player;
                        List<Player> loadedData = new List<Player>();
                        string row = "";
                        while ((row = sr.ReadLine()) != null)
                        {
                            
                            if ((row.Length > 3) && row.Contains(","))
                            {
                                string[] split = row.Split(',');
                                // luodaan tekstinpätkistä olio
                                player = new Player(split[0], split[1], split[2], Convert.ToInt32(split[3]), split[4]);
                                loadedData.Add(player);
                            }
                        }
                        // palautetaan listan mittausolioita
                        return loadedData;
                    }

                }
                else
                {
                    List<Player> loadedData = new List<Player>();
                    return loadedData;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool checkForSimilarities(List<Player> playerList,string fname, string lname)
        {
            if (playerList != null)
            {
                foreach (var item in playerList)
                {
                    if (item.FullName == lname + " " + fname)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        #endregion

        public override string ToString()
        {
            //return base.ToString();
            return PresentationName;
        } 
    }
}
