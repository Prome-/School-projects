using Microsoft.Win32;
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

namespace Harjoitus1MediaPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            loadMediaFile();
        }
        private void loadMediaFile()
        {
            try
            {
                // ladataan käyttäjän valitsemaa mediatiedostoa
                // string filu = @"\\storage\homes\salesa\Jakoon\iio11300\Media\CoffeeMaker.mp4";
                string filu = fileBox.Text;
                // tutkitaan onko tiedosto olemassa
                if (System.IO.File.Exists(filu))
                {
                    mediaElement.Source = new Uri(filu);
                }
                else MessageBox.Show("Tiedostoa ei löydy");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {

            mediaElement.Play();
            ChangeButtonsState();
         
        }

        private void ChangeButtonsState()
        {
            btnPause.IsEnabled = !btnPause.IsEnabled;
            btnStop.IsEnabled = !btnStop.IsEnabled;
            btnPlay.IsEnabled = !btnPlay.IsEnabled;
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Pause();
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Stop();
            ChangeButtonsState();
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            // avataan vakio open-dialogi jotta käyttäjä voi valita tiedoston joka toistetaan
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = "D:\\";
            dlg.Filter = "MPEG (*.mp3)|*.mp3|Media files(*.wmv)|*.wmv|All files (*.*)|*.*";
            // nullable antaa muuttujaan vaihtoehdon null
            Nullable<bool> result = dlg.ShowDialog();
            if(result == true)
            {
                fileBox.Text = dlg.FileName;
            }
        }
    }
}
