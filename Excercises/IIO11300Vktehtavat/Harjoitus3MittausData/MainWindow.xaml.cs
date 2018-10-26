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
using System.Windows.Navigation;
using System.Windows.Shapes;
using JAMK.IT.IIO11300;

namespace Harjoitus3MittausData
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // luodaan kokoelma mittaus-olioille
        List<MittausData> measurements;

        public MainWindow()
        {
            InitializeComponent();
            InitMyStuff();
        }
        private void InitMyStuff()
        {
            // omat ikkunaan liittyvät alustukset
            txtToday.Text = DateTime.Today.ToShortDateString();
            measurements = new List<MittausData>();
        }

        private void btnSaveData_Click(object sender, RoutedEventArgs e)
        {
            MittausData newData = new MittausData(txtClock.Text, txtData.Text);
          //  lbData.Items.Add(newData); // alkuperäinen huonompi tapa
            // lisätään mittaus-olio kokoelmaan
            measurements.Add(newData);
            ApplyChanges();

        }

        private void ApplyChanges()
        {
            // päivitetään UI vastaamaan kokoelmaa
            lbData.ItemsSource = null;
            lbData.ItemsSource = measurements;

        }

        private void btnSaveToFile_Click(object sender, RoutedEventArgs e)
        {
            // kutsu BL:n tallennusmetodia
            try
            {
                MittausData.SaveDataToFile(measurements, txtFileName.Text);
                MessageBox.Show("Tiedostot tallennettu onnistuneesti tiedostoon " + txtFileName.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //MessageBox.Show(ex.ToString());
                
            }
        }

        private void btnLoadFromFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                measurements = null;
                measurements = MittausData.ReadDataFromFile(txtFileName.Text);
                ApplyChanges();
                MessageBox.Show("Tiedot luettu onnistuneesti tiedostosta " + txtFileName.Text);
            }
            catch (Exception ex)
            {
                // luetaan data käyttäjän antamasta tiedostosta
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSaveToXML_Click(object sender, RoutedEventArgs e)
        {
            // serialisoidaan XML:ksi
            JAMK.IT.IIO11300.Serialisointi.SerialisoiXml(@"d:\testi.xml", measurements);
        }
    }
}
