using praktika4.SteamDataSetTableAdapters;
using System.Data;
using System.Windows;
using System.Windows.Controls;


namespace praktika4
{
    /// <summary>
    /// Логика взаимодействия для GamesPage.xaml
    /// </summary>
    public partial class GamesPage : Page
    {
        gamesTableAdapter games = new gamesTableAdapter();
        public GamesPage()
        {
            InitializeComponent();
            GameGrid.ItemsSource = games.GetData();
            combo.ItemsSource = games.GetData();
            combo.DisplayMemberPath = "singleplayer";
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (combo.SelectedItem != null)
            {
                var singleplayer = (string)(combo.SelectedItem as DataRowView).Row[1];
                GameGrid.ItemsSource = games.FilterBySingleplayer(singleplayer);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GameGrid.ItemsSource = games.SearchBySingleplayer(Search.Text);

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
