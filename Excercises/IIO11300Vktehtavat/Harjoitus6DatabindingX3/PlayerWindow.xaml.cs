using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace Harjoitus6DatabindingX3
{
    /// <summary>
    /// Interaction logic for PlayerWindow.xaml
    /// </summary>
    public partial class PlayerWindow : Window
    {
        ObservableCollection<HockeyPlayer> players;
        int counter;
        public PlayerWindow()
        {
            InitializeComponent();
            InitMyStuff();
        }
        private void InitMyStuff()
        {
            players = Get3TestPlayers();
            dgPlayers.ItemsSource = players;
            counter = 0;
            SetData();
        }
        private void SetData()
        {
            myGrid.DataContext = players[counter];
        }
        private ObservableCollection<HockeyPlayer> Get3TestPlayers()
        {
            ObservableCollection<HockeyPlayer> temp = new ObservableCollection<HockeyPlayer>();
            temp.Add(new HockeyPlayer("Teemu Selänne", "8"));
            temp.Add(new HockeyPlayer("Jarkko Immonen", "28"));
            temp.Add(new HockeyPlayer("Ville Peltonen", "16"));
            return temp;
        }

        private void dgPlayers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if((dgPlayers.SelectedIndex >= 0) && (dgPlayers.SelectedIndex < players.Count))
            {
                counter = dgPlayers.SelectedIndex;
                SetData();
            }
        }
    }
}
