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
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
            Staticheskyu.download();
           if(Staticheskyu.Collection.Count==0) Staticheskyu.Collection.Add("Basic", new Chest("Basic", 500000));
            comboBox.ItemsSource = new List<string> { "3+", "6+", "12+", "16+", "18+", "" };
            comboBox1.ItemsSource = new List<string> { "Action", "Arcade", "Puzzle", "Strategy", "Racing", "Quest", "RPG", "Adventure", "" };
            comboBox2.ItemsSource = Staticheskyu.Collection.Keys;
           
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav;
            Addinggame CP = new Addinggame();
            nav = NavigationService.GetNavigationService(this);
            nav.Navigate(CP);
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav;
            Page2 CP = new Page2();
            nav = NavigationService.GetNavigationService(this);
            nav.Navigate(CP);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav;
            Search CP = new Search(textBox.Text,comboBox.Text,comboBox1.Text,comboBox2.Text);
            nav = NavigationService.GetNavigationService(this);
            nav.Navigate(CP);
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Staticheskyu.Save();
        }

        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            comboBox2.Text = "";
        }
    }
}
