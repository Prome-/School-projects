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
using System.IO;

namespace Tehtava2WinLotto
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


        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            try
            {
                JAMK.IT.IIO11300.Lotto newLotto = new JAMK.IT.IIO11300.Lotto();
                newLotto.LottoType = lottoSelector.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnDraw_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                JAMK.IT.IIO11300.Lotto newLotto = new JAMK.IT.IIO11300.Lotto();
                int[] array = new int[7]; 
                for (int i = 0; i<Int32.Parse(txtDrawIndex.Text);i++)
                {
                    array = newLotto.draw(lottoSelector.Text);
                    for(int a = 0; a<array.Length;a++)
                    {
                        txtResults.Text += array[a].ToString() + " ";                        
                    }
                    txtResults.Text += "\n";
                    File.WriteAllText("lottorivit.txt",txtResults.Text+Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtResults.Text = "";
            File.WriteAllText("lottorivit.txt", String.Empty);
        }

        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                string draws = correctDraws.Text;
                string[] splittedRDraws = draws.Split(' ');
                System.IO.StreamReader file = new System.IO.StreamReader("lottorivit.txt");
                string newLine;
                while ((newLine = file.ReadLine()) != null)
                {
                    string[] splittedDraws = newLine.Split(' ');

                    for (int a = 0; a < splittedRDraws.Length; a++)
                    {
                        for (int b = 0; b < splittedDraws.Length; b++)
                        {
                            if (splittedRDraws[a] == splittedDraws[b])
                            {
                                yourHits.Text += splittedRDraws[a] + " ";
                            }
                        }
                    }
                    yourHits.Text += "\n";
                }

                file.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

       
    }

}
