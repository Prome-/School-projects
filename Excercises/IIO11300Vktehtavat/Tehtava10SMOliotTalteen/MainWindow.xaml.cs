using JAMK.IT.IIO11300;
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

namespace Tehtava10SMOliotTalteen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Team> teams;
        List<Player> players;

        public MainWindow()
        {
            InitializeComponent();
            InitMyStuff();
        }

        private void InitMyStuff()
        {
            try
            {
                teams = JAMK.IT.IIO11300.Liiga.GetTeams();
                 foreach(Team team in teams)
                 {
                     cbTeam.Items.Add(team.Name);
                 }

                //cbTeam.ItemsSource = teams;
                players = JAMK.IT.IIO11300.Liiga.GetPlayers();

                ApplyChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ApplyChanges()
        {
            try
            {
                /*  foreach (Player player in players)
                  {
                      MessageBox.Show(player.FirstName + " " + player.LastName + ", " + player.Team + ", " + player.Transfer);
                  }*/
                // spListContainer.DataContext = players;
                spListContainer.DataContext = null;
                spListContainer.DataContext = players;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lbPlayers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                spDataFields.DataContext = lbPlayers.SelectedItem;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCreatePlayer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                players.Add(new Player(txtFname.Text, txtLname.Text, cbTeam.Text, Convert.ToInt32(txtTransfer.Text)));

                ApplyChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeletePlayer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                players.RemoveAt(lbPlayers.SelectedIndex);
                ApplyChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdateDB_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Liiga.UpdatePlayers(players);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdatePlayer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                players[lbPlayers.SelectedIndex] = new Player(txtFname.Text, txtLname.Text, cbTeam.Text, Convert.ToInt32(txtTransfer.Text));

                ApplyChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
