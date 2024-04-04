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
    /// Логика взаимодействия для FriendsEfPage.xaml
    /// </summary>
    public partial class FriendsEfPage : Page
    {
        SteamEntities friends = new SteamEntities();

        public FriendsEfPage()
        {
            InitializeComponent();
            FriendsGrid.ItemsSource = friends.friends.ToList();
            combo.ItemsSource = friends.friends.ToList();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (combo.SelectedItem != null)
            {
                var selected = combo.SelectedItem as friends;
                FriendsGrid.ItemsSource = friends.friends.ToList().Where(friends => friends.nickname == selected.nickname).ToList();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FriendsGrid.ItemsSource = friends.friends.ToList().Where(friend => friend.nickname.Contains(Search.Text));

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FriendsGrid.ItemsSource = friends.friends.ToList();

        }
    }
}
