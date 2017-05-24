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

namespace KDZVERSH
{
    /// <summary>
    /// Логика взаимодействия для Addinggame.xaml
    /// </summary>
    public partial class Addinggame : Page
    {
        public Addinggame()
        {
            InitializeComponent();
            comboBox_age.ItemsSource = new List<string> {"3+", "6+", "12+", "16+", "18+"};
            comboBox_genres.ItemsSource = new List<string> { "Action", "Arcade", "Puzzle", "Strategy", "Racing", "Quest", "RPG", "Adventure" };
            comboBox_placeholder.ItemsSource = Staticheskyu.Collection.Keys;
        }

        private void addgame_Click(object sender, RoutedEventArgs e)
        {
            if ((comboBox_genres.SelectedIndex == -1) || (comboBox_age.SelectedIndex == -1) || textBox.Text == "" || comboBox_placeholder.SelectedIndex == -1)
            {
                labelError.Content = "Input error";
            } else
            {
                if (Staticheskyu.dictionary.ContainsKey(textBox.Text) || (Staticheskyu.Collection[comboBox_placeholder.Text].Games.Count == Staticheskyu.Collection[comboBox_placeholder.Text].Amount))
                {
                    labelError.Content = "Name is already exist or collection is full";
                }
            else
                {
                    logger.Instance.Log("Была добавлена игра.");
                    // Staticheskyu.Vyvod.Add(new Game(textBox.Text, (string)comboBox_genres.SelectedValue, (string)comboBox_age.SelectedValue));
                    Staticheskyu.dictionary.Add(textBox.Text, comboBox_placeholder.Text);
                    Staticheskyu.Collection[comboBox_placeholder.Text].Games.Add(textBox.Text, new Game(textBox.Text, comboBox_genres.Text, comboBox_age.Text));
                    NavigationService nav;
                    Page1 CP = new Page1 ();
                    nav = NavigationService.GetNavigationService(this);
                    nav.Navigate(CP);
                }
            }
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Staticheskyu.Save();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav;
            Page1 CP = new Page1();
            nav = NavigationService.GetNavigationService(this);
            nav.Navigate(CP);
        }

        private void BackButton_MouseEnter(object sender, MouseEventArgs e)
        {
            BackButton.Content = "GO!";
        }

        private void BackButton_MouseLeave(object sender, MouseEventArgs e)
        {
            BackButton.Content = "Back";
        }
    }
}
