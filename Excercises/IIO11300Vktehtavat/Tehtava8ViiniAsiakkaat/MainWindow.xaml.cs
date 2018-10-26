using System;
using System.Collections.Generic;
using System.Data; // For general ADO classes
using System.Data.SqlClient; // For SQL server specific classes
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

namespace Tehtava8ViiniAsiakkaat
{
    // HUOM NÄITÄ KYSELLÄÄN KOKEESSA
    // LAITA TIEDOT PROJEKTIN APP.CONFIGGIIN OLEELLINEN DATA
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataTable table = new DataTable();
        DataView dv;
        List<String> cities;
        public MainWindow()
        {
            InitializeComponent();            
          //  InitMyStuff();
        }

        #region METHODS
        private static string GetConnectionString()
        {
            //Luetaan string App.Configista
            return Tehtava8ViiniAsiakkaat.Properties.Settings.Default.Tietokanta;
        }
        private void InitMyStuff()
        {
            try
            {
                cities = new List<string>();
                /*cities.Add("Jyväskylä");
                cities.Add("Helsinki");
                cities.Add("New York");*/
                string kaupunki = "";
                foreach (DataRow item in table.Rows)
                {
                    kaupunki = item[3].ToString();
                    if (!cities.Contains(kaupunki))
                    {
                        cities.Add(kaupunki);
                    }
                    
                }
                // VE3 LINQ:lla voi tehdä kyselyn tyypitettyyn datatableen, huom ei kaikille datatablella
             //   var result = (from c in table select c.City).Distinct();
                // databindaus
                cbCities.ItemsSource = cities;

                            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGetCustomers_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GetData();
                InitMyStuff();
                lbCustomers.DataContext = table;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void GetData()
        {
            string connStr = GetConnectionString();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sqlString = "SELECT firstname, lastname, address, city FROM vCustomers";
                SqlDataAdapter da = new SqlDataAdapter(sqlString, conn);
                da.Fill(table);
                // huom voidaan myös käyttää dataviewiä, joka on erityisesti hyvä lajittelussa ja filtteröinnissä
                dv = table.DefaultView;
                // tällöin käytetään datakontekstina dv:tä eikä dt:tä
                conn.Close();
            }
        }

        private void lbCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            customerDataView.DataContext = lbCustomers.SelectedItem;
        }
        #endregion

        private void cbCities_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dv.RowFilter = string.Format("City LIKE '{0}'", cbCities.SelectedValue);
        }
    }
}
