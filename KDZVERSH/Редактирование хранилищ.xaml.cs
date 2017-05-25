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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            comboBox.ItemsSource = Staticheskyu.Collection.Keys;
        }

        private void confirm_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.Text == "")
            {
                labelError.Content = "Plaseholder or new name not chosen";
            }
            else
            {
                Staticheskyu.Collection[comboBox.Text].Name=textBox.Text;
                Chest t = Staticheskyu.Collection[comboBox.Text];
                Staticheskyu.Collection.Remove(comboBox.Text);
                Staticheskyu.Collection.Add(t.Name,t);
                foreach(string temp in Staticheskyu.Collection[t.Name].Games.Keys)
                {
                    Staticheskyu.dictionary.Remove(temp);
                    Staticheskyu.dictionary.Add(temp, t.Name);

                }
               
                this.Close();
                logger.Instance.Log("Одно из хранилищ было переименновано.");
            }
            
        }

        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {
            Staticheskyu.Save();
        }
    }
}
