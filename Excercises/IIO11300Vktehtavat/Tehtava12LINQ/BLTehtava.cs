using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Xml.Linq;

namespace Tehtava12LINQ
{
    public class Tehtava : INotifyPropertyChanged
    {
        private bool done;

        public bool Done
        {
            get { return done; }
            set { done = value;  Notify("Done"); }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; Notify("Description"); }
        }

        private string date;

        public string Date
        {
            get { return date; }
            set { date = value; Notify("Date"); }
        }

        private int key;

        public int Key
        {
            get { return key; }
            set { key = value; }
        }
        

        public Tehtava(string kuvaus, bool tila, string pvm)
        {
            this.description = kuvaus;
            this.done = tila;
            this.date = pvm;
        }

        public Tehtava(int id, string kuvaus, bool tila, string pvm)
        {
            this.key = id;
            this.description = kuvaus;
            this.done = tila;
            this.date = pvm;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void Notify(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        public override string ToString()
        {
            if(done == true)
            {
                return description + ", " + date + ", tehty"; 
            }
            return description + ", " + date + ", tekemättä";
        }
    }

    public static class Lista
    {
        public static ObservableCollection<Tehtava> loadXML()
        {
            try
            {
                XmlDocument document = new XmlDocument();
                ObservableCollection<Tehtava> tehtavat = new ObservableCollection<Tehtava>();

                if (!File.Exists("Tehtavat.xml"))
                {
                    //Populate with data here if necessary, then save to make sure it exists
                    XmlDeclaration xmlDeclaration = document.CreateXmlDeclaration("1.0", "UTF-8", null);

                    XmlElement root = document.CreateElement("Tehtavat");
                    document.AppendChild(root);

                    document.Save("Tehtavat.xml");

                }
                else
                {
                    //We know it exists so we can load it
                    document.Load("Tehtavat.xml");

                    XmlElement root = document.DocumentElement;
                    XmlNodeList nodes = root.SelectNodes("Tehtava");
                    foreach (XmlNode node in nodes)
                    {
                        if (node["Tehty"].InnerText == "true")
                        {
                            tehtavat.Add(new Tehtava(
                            node["Kuvaus"].InnerText,
                            true,
                            node["Pvm"].InnerText
                            ));
                        }
                        else
                        {
                            tehtavat.Add(new Tehtava(
                            node["Kuvaus"].InnerText,
                            false,
                            node["Pvm"].InnerText
                            ));
                        }

                    }
                }

                return tehtavat;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public static void SaveXML(ObservableCollection<Tehtava> tehtavat)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("Tehtavat.xml");
                int maxId = 0;

                if (xmlDoc.DocumentElement.ChildNodes.Count > 0)
                {
                    maxId = xmlDoc.SelectNodes("Tehtavat/Tehtava/Avain")
                       .Cast<XmlNode>()
                       .Max(node => int.Parse(node.InnerText));
                }           

                XDocument file = new XDocument();
                XElement root = new XElement("Tehtavat");
                XElement container;
                XElement kuvaus;
                XElement tila;
                XElement avain;
                XElement pvm;

                foreach (Tehtava tehtava in tehtavat)
                {
                    container = new XElement("Tehtava");
                    kuvaus = new XElement("Kuvaus");
                    tila = new XElement("Tehty");
                    avain = new XElement("Avain");
                    pvm = new XElement("Pvm");

                    kuvaus.Value = tehtava.Description;
                    tila.Value = tehtava.Done.ToString();
                    avain.Value = maxId.ToString();
                    pvm.Value = tehtava.Date;

                    container.Add(avain);
                    container.Add(kuvaus);
                    container.Add(tila);
                    container.Add(pvm);

                    root.Add(container);
                    maxId++;
                }

                XDocument xdoc = new XDocument();
                xdoc.Add(root);
                xdoc.Save("Tehtavat.xml");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
