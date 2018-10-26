using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Linq;

namespace Tehtava4OudotOliot
{
    /// <summary>
    /// Interaction logic for Movies2.xaml
    /// </summary>
    public partial class Movies2 : Window
    {
        public Movies2()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string filu = xdpMovies.Source.LocalPath;
                xdpMovies.Document.Save(filu);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // lisätään xml-dokumenttiin uusi elementti
                // huom textboxit ja listbox bindattu dataan
                if(lbMovies.SelectedIndex > -1)
                {
                    lbMovies.SelectedIndex = -1;
                }
                else
                {
                    // lisätään uusi node
                    string filu = xdpMovies.Source.LocalPath;
                    //viittaus xmldokumenttiin ja sen juurielementtiin
                    XmlDocument doc = xdpMovies.Document;
                    XmlNode root = doc.SelectSingleNode("/Movies");
                    //luodaan uusi node
                    XmlNode newMovie = doc.CreateElement("Movie");
                    // luodaan attribuutti
                    XmlAttribute attr = doc.CreateAttribute("Name");
                    // annetaan attribuutille arvo
                    attr.Value = txtName.Text;
                    // sijoitetaan attribuutti nodelle
                    newMovie.Attributes.Append(attr);
                    // toista kahdesti
                    XmlAttribute attr2 = doc.CreateAttribute("Director");
                    attr2.Value = txtDirector.Text;
                    newMovie.Attributes.Append(attr2);
                    XmlAttribute attr3 = doc.CreateAttribute("Country");
                    attr3.Value = txtCountry.Text;
                    newMovie.Attributes.Append(attr3);
                    root.AppendChild(newMovie);
                    //tallennetaan muutokset tiedostoon
                    xdpMovies.Document.Save(filu);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Poistetaan xml-dokumentista valittu elementti
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
