using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace Tehtava9ViiniCRUD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataTable table;
        public MainWindow()
        {
            InitializeComponent();
            InitMyStuff();
        }

        private static string GetConnectionString()
        {
            //Luetaan string App.Configista
            return Tehtava9ViiniCRUD.Properties.Settings.Default.Tietokanta;
        }
        private void InitMyStuff()
        {
            try
            {
                table = new DataTable();
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
                table = JAMK.IT.IIO11300.DBViini.GetAllCustomersData();
                dgCustomers.DataContext = table.Rows;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                spAddWorker.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               // JAMK.IT.IIO11300.DBViini.RemoveWorker();
                table = JAMK.IT.IIO11300.DBViini.GetAllCustomersData();
                dgCustomers.DataContext = table.Rows;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
           {

                JAMK.IT.IIO11300.DBViini.AddWorker(txtFirstName.Text, txtLastName.Text, txtAddress.Text, txtCity.Text);
                table = JAMK.IT.IIO11300.DBViini.GetAllCustomersData();
                dgCustomers.DataContext = table.Rows;
                spAddWorker.Visibility = Visibility.Collapsed;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
