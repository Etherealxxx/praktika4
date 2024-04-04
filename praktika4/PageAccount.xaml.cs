using praktika4.SteamDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для SteamEf.xaml
    /// </summary>
    public partial class PageAccount : Page
    {
        accountTableAdapter account = new accountTableAdapter();
        gamesTableAdapter games = new gamesTableAdapter();
        public PageAccount()
        {
            InitializeComponent();
            AccountGrid.ItemsSource = account.GetData();
            combo.ItemsSource = games.GetData();
            combo.DisplayMemberPath = "singleplayer";
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (combo.SelectedItem != null)
            {
                var id = (int)(combo.SelectedItem as DataRowView).Row[0];
                AccountGrid.ItemsSource = account.FilterByGames(id);
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AccountGrid.ItemsSource = account.GetData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AccountGrid.ItemsSource = account.SearchByNick(Search.Text);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }
    }
}
