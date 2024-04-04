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

using praktika4.SteamDataSetTableAdapters;


namespace praktika4
{
    /// <summary>
    /// Логика взаимодействия для FriendsPage.xaml
    /// </summary>
    public partial class FriendsPage : Page
    {
        friendsTableAdapter friend = new friendsTableAdapter();

        public FriendsPage()
        {
            InitializeComponent();
            FriendsGrid.ItemsSource = friend.GetData();
            combo.ItemsSource = friend.GetData();
            combo.DisplayMemberPath = "nickname";
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (combo.SelectedItem != null)
            {
                var nickname = (string)(combo.SelectedItem as DataRowView).Row[1];
                FriendsGrid.ItemsSource = friend.FilterByNickname(nickname);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FriendsGrid.ItemsSource = friend.SearchByNickname(Search.Text);

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }
    }
}
