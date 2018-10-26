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

namespace H9WanhojenKirjojenKauppaORM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Book> books;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnGetBooks_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                books = BookShop.GetTestBooks();
                dgBooks.DataContext = books;
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
                Book current = (Book)spBook.DataContext;
                int rows = BookShop.UpdateBook(current);
                MessageBox.Show(rows + " riviä muutettu!");
                dgBooks.DataContext = BookShop.GetBooks(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgBooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                spBook.DataContext = dgBooks.SelectedItem;
            }
            catch (Exception ex)
            {
                 MessageBox.Show(ex.Message);
            }
        }

        private void btnGetBooksSQL_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dgBooks.DataContext = BookShop.GetBooks(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
