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
using Microsoft.Win32;

namespace Tehtava4OudotOliot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Player> playerList = new List<Player>();

        public MainWindow()
        {
            InitializeComponent();
            InitializeMyStuff();
        }

        private void btnCreatePlayer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtFirstName.Text != "" && txtLastName.Text != "" && txtTransferCost.Text != "" && TeamSelector.Text != "")
                {
                            // tarkistetaan onko samanniminen pelaaja jo olemassa 
                    if(!(JAMK.IT.IIO11300.Player.checkForSimilarities(playerList, txtFirstName.Text, txtLastName.Text)))
                    {
                        int cost = Int32.Parse(txtTransferCost.Text);
                        Player newPlayer = new Player(txtFirstName.Text, txtLastName.Text, TeamSelector.Text, cost, faceSelector.Text);
                        playerList.Add(newPlayer);
                        ApplyChanges();
                        statusBarText.Text = "Player added to list!";
                    }
                    else
                    {
                        statusBarText.Text = "Player already exists!";
                    }  
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch (Exception ex)
            {
                statusBarText.Text = ex.Message;
                MessageBox.Show(ex.ToString());
            }
        }

        public void InitializeMyStuff()
        {
            TeamSelector.Items.Add("JYP");
            TeamSelector.Items.Add("Tappara");
            TeamSelector.Items.Add("Jokerit");

            faceSelector.Items.Add("Barack");
            faceSelector.Items.Add("Vladimir");
            faceSelector.Items.Add("Kim");
            faceSelector.Items.Add("Daadaa");

            
            ApplyChanges();
            statusBarText.Text = "Window initialized!";
        }

        private void ApplyChanges()
        {
            playerListBox.ItemsSource = null;
            playerListBox.ItemsSource = playerList;
        }

        private void playerListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                foreach (var item in playerList)
                {
                    if (playerListBox.SelectedItem == item)
                    {
                        txtFirstName.Text = item.FirstName;
                        txtLastName.Text = item.LastName;
                        txtTransferCost.Text = item.TransferCost.ToString();

                        switch (item.Team)
                        {
                            case "JYP":
                                TeamSelector.SelectedIndex = 0;
                                break;

                            case "Tappara":
                                TeamSelector.SelectedIndex = 1;
                                break;

                            case "Jokerit":
                                TeamSelector.SelectedIndex = 2;
                                break;
                        }
                            
                        switch (item.Face)
                        {
                            case "Barack":
                                faceSelector.SelectedIndex = 0;
                                break;

                            case "Vladimir":
                                faceSelector.SelectedIndex = 1;
                                break;

                            case "Kim":
                                faceSelector.SelectedIndex = 2;
                                break;

                            case "Daadaa":
                                faceSelector.SelectedIndex = 3;
                                break;
                        }

                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                statusBarText.Text = ex.Message;
            }
        }

        private void btnDeletePlayer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (var item in playerList)
                {
                    if (playerListBox.SelectedItem == item)
                    {
                        playerList.Remove(item);
                        txtFirstName.Text = "";
                        txtLastName.Text = "";
                        txtTransferCost.Text = "";
                        TeamSelector.SelectedIndex = -1;
                        faceSelector.SelectedIndex = -1;
                        break;
                    }
                }
                ApplyChanges();
                statusBarText.Text = "Player deleted!";

            }
            catch (Exception ex)
            {
                statusBarText.Text = ex.Message;
            }
        }

        private void faceSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                switch (faceSelector.SelectedValue.ToString())
                {
                    case "Barack":
                        imageViewer.Source = new BitmapImage(new Uri(@"http://student.labranet.jamk.fi/~H8244/jako/Koodi/stuff/barack.png"));
                        statusBarText.Text = faceSelector.Text;
                        break;

                    case "Vladimir":
                        imageViewer.Source = new BitmapImage(new Uri(@"http://student.labranet.jamk.fi/~H8244/jako/Koodi/stuff/putin.png"));
                        statusBarText.Text = faceSelector.Text;
                        break;

                    case "Kim":
                        imageViewer.Source = new BitmapImage(new Uri(@"http://student.labranet.jamk.fi/~H8244/jako/Koodi/stuff/kimjong.png"));
                        statusBarText.Text = faceSelector.Text;
                        break;

                    case "Daadaa":
                        imageViewer.Source = new BitmapImage(new Uri(@"http://student.labranet.jamk.fi/~H8244/jako/Koodi/stuff/baby.png"));
                        statusBarText.Text = faceSelector.Text;
                        break;
                }
            }
            catch (Exception ex)
            {

                statusBarText.Text = ex.Message;
            }
        }

        private void btnUpdatePlayer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (var item in playerList)
                {
                    if (playerListBox.SelectedItem == item)
                    {
                        item.FirstName = txtFirstName.Text;
                        item.LastName = txtLastName.Text;
                        item.TransferCost = Int32.Parse(txtTransferCost.Text);
                        item.Team = TeamSelector.SelectedItem.ToString();
                        item.Face = faceSelector.SelectedItem.ToString();
                        break;
                    }
                }
                int selIndex = playerListBox.SelectedIndex;
                ApplyChanges();
                playerListBox.SelectedIndex = selIndex;
                statusBarText.Text = "Player updated!";
            }
            catch (Exception ex)
            {

                statusBarText.Text = ex.Message;
            }
        }

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSaveToTxt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.InitialDirectory = "D:\\";
                dialog.Title = "Save to file";
                dialog.Filter = "Text (.txt)|*.txt|XML (.xml)|*.xml";
                dialog.ShowDialog();

                if (dialog.FileName != "")
                {
                    string ext = System.IO.Path.GetExtension(dialog.FileName);

                    // Saves the Image via a FileStream created by the OpenFile method
                    JAMK.IT.IIO11300.Player.saveDataToTxt(playerList, dialog.FileName);
                    statusBarText.Text = dialog.FileName + " saved!";
                }
            }
            catch (Exception ex)
            {
                statusBarText.Text = ex.Message;
            }
        }

        private void loadData_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.ShowDialog();
                if (dialog.FileName != "")
                {
                    
                    if (System.IO.Path.GetExtension(dialog.FileName) == ".txt")
                    {
                        List<Player> newData = JAMK.IT.IIO11300.Player.loadDataFromTxt(dialog.FileName);
                        if (newData.Count != 0)
                        {

                            playerList = newData;
                            statusBarText.Text = "File loaded successfully!";
                            ApplyChanges();
                        }
                        else
                        {
                            statusBarText.Text = "Invalid file!";
                        }
                    }
                    
                    else if (System.IO.Path.GetExtension(dialog.FileName) == ".xml")
                    {
                        List<Player> newData = JAMK.IT.IIO11300.Serialisointi.DeSerialisoiXml(dialog.FileName);
                        if (newData.Count != 0)
                        {
                            playerList = newData;
                            statusBarText.Text = "File loaded successfully!";
                            ApplyChanges();
                        }
                    }
                    else
                    {
                        statusBarText.Text = "Only .xml or .txt is allowed!";
                    }
                    
                    
                }
                else
                {
                    statusBarText.Text = "No file loaded.";
                }
            }
            catch (Exception ex)
            {
                statusBarText.Text = ex.Message;
            }
        }

        private void btnSaveToXML_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.ShowDialog();
                JAMK.IT.IIO11300.Serialisointi.SerialisoiXml(dialog.FileName, playerList);
            }
            catch (Exception ex)
            {
                statusBarText.Text = ex.Message;
            }
        }
    }
}

