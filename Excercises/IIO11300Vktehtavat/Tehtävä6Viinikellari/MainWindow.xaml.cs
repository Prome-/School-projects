using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Linq;

namespace Tehtävä6Viinikellari
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitMyStuff();
        }

        private void InitMyStuff()
        {
            cmbBox.Items.Add("All");
            cmbBox.Items.Add("Germany");
            cmbBox.Items.Add("Romanien");
            cmbBox.Items.Add("France");
            cmbBox.Items.Add("Suomi");
            cmbBox.Items.Add("South Africa");
            cmbBox.Items.Add("Chile");
            cmbBox.Items.Add("Portugal");
            cmbBox.Items.Add("Hungary");
            cmbBox.SelectedIndex = 0;
        }

        private string GetFileName()
        {
            return Tehtävä6Viinikellari.Properties.Settings.Default.XMLTiedosto;
        }

        private void btnHaeViinit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                XElement data = XElement.Load(GetFileName());
                if (cmbBox.Text == "All")
                {
                   // var viinit = from ele in data.Elements() select ele.Parent;
                   // dgWine.ItemsSource = viinit;
                }
                else
                {
                     var haetut = from ele in data.Elements() where ele.Element("maa").Value == cmbBox.Text select ele;

                    MessageBox.Show(haetut.ToList().ToString());
                    /* ICollectionView view = CollectionViewSource.GetDefaultView(GetFileName());

                     view.Filter = delegate (object item)
                     {
                         bool match = ((XElement)(item)).Element("maa").Value == cmbBox.Text;
                         return match;
                     };*/



                    /*List<Viini> viinit = new List<Viini>();

                    foreach (var item in haetut)
                    {
                        Viini viini = new Viini(item.Element("nimi").Value, item.Element("maa").Value, item.Element("arvio").Value);
                        viinit.Add(viini);
                    }

                    dgWine.ItemsSource = viinit;*/
                     dgWine.DataContext = haetut;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
