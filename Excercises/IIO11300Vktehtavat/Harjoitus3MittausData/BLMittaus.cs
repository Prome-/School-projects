using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace JAMK.IT.IIO11300
{
    public class MittausData
    {
        private string kello;

        public string Kello
        {
            get { return kello; }
            set { kello = value; }
        }

        private string mittaus;

        public string Mittaus
        {
            get { return mittaus; }
            set { mittaus = value; }
        }

        public String DataMuoto
        {
            get { return kello + ";" + mittaus; }
        }
        #region CONSTRUCTORS
        // luokalle tehdään kaksi konstruktoria
        public MittausData()
        {
            kello = "0:00";
            mittaus = "empty";
        }

        public MittausData(string klo, string mdata)
        {
            this.kello = klo;
            this.mittaus = mdata;
        }
        #endregion

        // koska olioiden on osattava näyttää sisältämänsä mittausdata nimensä sijaan, niin ToString täytyy ylikirjoittaa
        public override string ToString()
        {
            //return base.ToString();
            return kello + ", " + mittaus;
        }

        #region METHODS

        public static void SaveDataToFile(List<MittausData> data, string filu)
        {
            // kirjoitetaan data tiedostoon, jos tiedosto on jo olemassa niin liitetään se olemassaolevaan

            try
            {
                // tutkitaan onko tiedosto olemassa
                if(!System.IO.File.Exists(filu))
                {
                    // luodaan uusi tiedosto kun ei löytynyt
                    using (StreamWriter sw = File.CreateText(filu))
                    {
                        // käydään kokoelma läpi ja kirjoitetaan kukin mittausdata omalle rivilleen
                        foreach (var item in data)
                        {
                            // DataMuoto on itse luotu mittausdata-luokan property joka sisältää paremman kirjoitusasun datalle
                            sw.WriteLine(item.DataMuoto);
                        }
                    }
                }
                else
                {
                    // lisätään olemassaolevaan tiedostoon mittaustieto
                    using (StreamWriter sw = File.AppendText(filu))
                    {
                        foreach (var item in data)
                        {
                            sw.WriteLine(item.DataMuoto);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        public static List<MittausData> ReadDataFromFile(string filu)
        {
            // luetaan käyttäjän antamasta tiedostosta tekstirivejä ja muutetaan ne mittausdataksi
            try
            {
                
                if (File.Exists(filu))
                {
                    using (StreamReader sr = File.OpenText(filu))
                    {
                       // luetaan rivi kerrallaan tiedostoa
                        MittausData md;
                        List<MittausData> loadedData = new List<MittausData>();
                        string row = "";
                        while((row = sr.ReadLine()) != null)
                        {
                            // tutkitaan löytyykö sovittu erotinmerkki, eli puolipiste (;) jonka edessä on kellonaika ja takana mittausarvo
                            if((row.Length > 3) && row.Contains(";"))
                            {
                                string[] split = row.Split(';');
                                // luodaan tekstinpätkistä olio
                                md = new MittausData(split[0], split[1]);
                                loadedData.Add(md);
                            }
                        }
                        // palautetaan listan mittausolioita
                        return loadedData;
                    }
                }
                else
                {
                    throw new FileNotFoundException();
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        #endregion

    }
}
