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

namespace praktika4
{
    /// <summary>
    /// Логика взаимодействия для GamesEfPage.xaml
    /// </summary>
    public partial class GamesEfPage : Page
    {
        SteamEntities games = new SteamEntities();
        public GamesEfPage()
        {
            InitializeComponent();
            GameGrid.ItemsSource = games.games.ToList();
            combo.ItemsSource = games.games.ToList();
            
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (combo.SelectedItem != null)
            {
                var selected = combo.SelectedItem as games;
                GameGrid.ItemsSource = games.games.ToList().Where(games => games.singleplayer == selected.singleplayer).ToList();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GameGrid.ItemsSource = games.games.ToList().Where(friend => friend.singleplayer.Contains(Search.Text));

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            GameGrid.ItemsSource = games.games.ToList();
        }
    }
}
