using praktika4.SteamDataSetTableAdapters;
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
    /// Логика взаимодействия для AccountEfPage.xaml
    /// </summary>
    public partial class AccountEfPage : Page
    {
        private SteamEntities account = new SteamEntities();
        public AccountEfPage()
        {
            InitializeComponent();
            AccountGrid.ItemsSource = account.account.ToList();
            combo.ItemsSource = account.games.ToList();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(combo.SelectedItem != null)
            {
                var selected = combo.SelectedItem as games;
                int selectedGamesId = selected.ID_games;
                AccountGrid.ItemsSource = account.account.Where(account => account.ID_games == selectedGamesId).ToList();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AccountGrid.ItemsSource = account.account.ToList().Where(account => account.nick.Contains(Search.Text)); 
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AccountGrid.ItemsSource = account.account.ToList();
        }
    }
}
