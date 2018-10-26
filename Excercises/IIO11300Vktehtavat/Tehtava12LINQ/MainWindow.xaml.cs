using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Tehtava12LINQ
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Tehtava> tehtavat;
        int counter;
        public MainWindow()
        {
            InitializeComponent();
            InitMyStuff();
        }

        public void InitMyStuff()
        {
            try
            {
                counter = 0;
                tehtavat = Lista.loadXML();
                RefreshJobs();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void RefreshJobs()
        {
            try
            {
                dgJobs.ItemsSource = null;
                dgJobs.ItemsSource = tehtavat;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddJob_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                tehtavat.Add(new Tehtava(txtDescription.Text, (bool)cbState.IsChecked, txtDate.Text));
                RefreshJobs();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }   

        private void btnDeleteJob_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                tehtavat.RemoveAt(dgJobs.SelectedIndex);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnSaveJobs_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Lista.SaveXML(tehtavat);
                MessageBox.Show("Tallennus onnistui");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SetData()
        {
            myGrid.DataContext = tehtavat[counter];
        }

        private void dgJobs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if ((dgJobs.SelectedIndex >= 0) && (dgJobs.SelectedIndex < tehtavat.Count))
                {
                    counter = dgJobs.SelectedIndex;
                    SetData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtSearchDescr_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                var results = from tehtava in tehtavat where tehtava.Description.Contains(txtSearchDescr.Text) select tehtava;
                dgJobs.ItemsSource = results.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dpSearchDate_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                var results = from tehtava in tehtavat where tehtava.Date.Contains(txtSearchDate.Text) select tehtava;
                dgJobs.ItemsSource = results.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
