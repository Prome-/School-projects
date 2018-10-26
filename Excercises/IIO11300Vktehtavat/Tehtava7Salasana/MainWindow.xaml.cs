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


namespace Tehtava7Salasana
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void txtInput_PasswordChanged(object sender, RoutedEventArgs e)
        {
            try
            {
                int result;
                result = JAMK.IT.IIO11300.Salasana.AnalyzePassword(txtInput.Password);

                txtLowercaseCount.Text = "Lowercase: " + JAMK.IT.IIO11300.Salasana.lowercase.ToString();
                txtUppercaseCount.Text = "Uppercase: " + JAMK.IT.IIO11300.Salasana.uppercase.ToString();
                txtNumberCount.Text = "Numbers: " + JAMK.IT.IIO11300.Salasana.numbers.ToString();
                txtSymbolCount.Text = "Length: " + JAMK.IT.IIO11300.Salasana.symbolCount.ToString();
                txtSpecialCount.Text = "Special characters: " + JAMK.IT.IIO11300.Salasana.special.ToString();

                if (result == 4)
                {
                    txtOutput.Text = "Good";
                    txtOutput.Background = Brushes.Green;
                }
                else if (result == 3)
                {
                    txtOutput.Text = "Moderate";
                    txtOutput.Background = Brushes.LightGreen;
                }
                else if (result == 2)
                {
                    txtOutput.Text = "Fair";
                    txtOutput.Background = Brushes.Yellow;
                }
                else if (result == 1)
                {
                    txtOutput.Text = "Bad";
                    txtOutput.Background = Brushes.Orange;
                }
                else
                {
                    txtOutput.Text = "";
                    txtOutput.Background = Brushes.Gray;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
