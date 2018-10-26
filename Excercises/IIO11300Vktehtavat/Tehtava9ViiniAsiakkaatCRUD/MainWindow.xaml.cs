using System;
using System.Collections.Generic;
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

namespace Tehtava9ViiniAsiakkaatCRUD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataTable dt;
        DataView dv;
        public MainWindow()
        {
            InitializeComponent();
            InitMyStuff();
        }

        private void InitMyStuff()
        {
            try
            {
                dt = new DataTable();
                dv = new DataView();                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetCustomers()
        {
            try
            {
                dt = JAMK.IT.IIO11300.DBCustomer.GetAllCustomersData();
                dv = dt.DefaultView;
                dgCustomers.DataContext = dv;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGetCustomers_Click(object sender, RoutedEventArgs e)
        {
            GetCustomers();
        }

        private void btnAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                spCustomerDataView.Visibility = Visibility.Visible;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnInsertCustomer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                /*DataRow dr = dt.NewRow();
                dr["firstname"] = txtFirstName.Text;
                dr["lastname"] = txtLastName.Text;
                dr["address"] = txtAddress.Text;
                dr["city"] = txtAddress.Text;
                dt.Rows.Add(dr);
                JAMK.IT.IIO11300.DBCustomer.UpdateCustomers(dt);*/

                JAMK.IT.IIO11300.DBCustomer.AddCustomer(txtFirstName.Text, txtLastName.Text, txtAddress.Text, txtZIP.Text, txtCity.Text);
                spCustomerDataView.Visibility = Visibility.Collapsed;                
                MessageBox.Show("Asiakas tallennettu onnistuneesti!");
                GetCustomers();
                
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
                DataRow dr = dt.Rows[dgCustomers.SelectedIndex];
                string id = dr["id"].ToString();
                string fname = dr["firstname"].ToString();
                string lname = dr["lastname"].ToString();
                string address = dr["address"].ToString();
                string zip = dr["zip"].ToString();
                string city = dr["city"].ToString();
                JAMK.IT.IIO11300.BusinessLogic.DeleteCustomer(id, fname, lname, address, zip, city);
                GetCustomers();      
                   
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSaveChanges_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                JAMK.IT.IIO11300.DBCustomer.UpdateCustomers(dt);
                MessageBox.Show("Muutokset tallennettu onnistuneesti!");
                GetCustomers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
