using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.ObjectModel; // for observablecollection
using System.ComponentModel;
using System.Data.Entity;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace H10BookShopEF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BookShopEntities ctx;
        ObservableCollection<Book> localbooks;
        ICollectionView view; //datagridin filtteröintiä varten
        bool IsBooks;
        public MainWindow()
        {
            InitializeComponent();
            IniMyStuff();
        }

        private void IniMyStuff()
        {
            // luodaan konteksti aka datasisältö
            ctx = new BookShopEntities();
            // ladataan kirjatiedot paikalliseksi
            ctx.Books.Load();
            //ctx.Customers.Load();
            localbooks = ctx.Books.Local;
            // täytetään comboboksi kirjailijoiden maiden nimillä
            // huoma lambda tyypin linq kysely
            cbFilter.DataContext = localbooks.Select(n => n.country).Distinct();

            // luodaan view
            view = CollectionViewSource.GetDefaultView(localbooks);
        }

        private void btnGetBooks_Click(object sender, RoutedEventArgs e)
        {
            // haetaan kirjat datagridiin
            // vaihtoehto 1
            // dgBooks.DataContext = ctx.Books.ToList();
            // vaihtoehto 2 käytetään paikallista muuttujaa
            dgBooks.DataContext = localbooks;
            IsBooks = true;
            cbFilter.SelectedIndex = -1;
        }

        private void dgBooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(IsBooks)
            {
                spBook.DataContext = dgBooks.SelectedItem;
            }
            else
            {
                spCustomers.DataContext = dgBooks.SelectedItem;
            }          
        }

        private void btnGetCustomers_Click(object sender, RoutedEventArgs e)
        {
            dgBooks.DataContext = ctx.Customers.ToList();
            IsBooks = false;
        }

        private void cbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // asetetaan filter
            view.Filter = MyCountryFilter;
        }
        private bool MyCountryFilter(object item)
        {
            if(cbFilter.SelectedIndex == -1)
            {
                return true;
            }
            else
            {
                return (item as Book).country.Contains(cbFilter.SelectedItem.ToString());
            }
        }

        private void btnOrders_Click(object sender, RoutedEventArgs e)
        {
            // haetaan EDM navigaatio-ominaisuuksien avulla valitun asiakkaan tilaukset ja sen kirjat
            string msg = "";
            Customer current = (Customer)spCustomers.DataContext;
            msg += string.Format("Asiakkaan {0} tilaukset \n", current.lastname);
            foreach(var order in current.Orders)
            {
                msg += string.Format("Tilaus {0} sisältää {1} tilausriviä:\n", order.odate, order.Orderitems.Count);
                //loopataan tilauksen tilausrivit
                foreach(var item in order.Orderitems)
                {
                    msg += string.Format("- kirja {0}\n", item.Book.name);
                }
            }
            MessageBox.Show(msg);
        }
    }
}
