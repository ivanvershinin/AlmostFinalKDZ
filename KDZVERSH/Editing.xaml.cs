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
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
            textBox_placeholder.IsEnabled = false;
            comboBox_gametoedit.ItemsSource = Staticheskyu.dictionary.Keys;
            comboBox_replacetoanotherplaceholder.ItemsSource = Staticheskyu.Collection.Keys;
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            MainWindow Prosto = new MainWindow();
            Prosto.ShowDialog();
            comboBox_replacetoanotherplaceholder.ItemsSource = null;
            comboBox_replacetoanotherplaceholder.ItemsSource = Staticheskyu.Collection.Keys;
            
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {

            if (comboBox_gametoedit.SelectedIndex == -1)
            {
                labelError.Content = "Choose the game to delete";
            }
            else
            {
                
                string PlaceName = textBox_newplaceholder.Text;
                Staticheskyu.Collection[Staticheskyu.dictionary[comboBox_gametoedit.Text]].Games.Remove(comboBox_gametoedit.Text) ;
                Staticheskyu.dictionary.Remove(comboBox_gametoedit.Text);
                comboBox_gametoedit.ItemsSource = null;
                comboBox_gametoedit.ItemsSource = Staticheskyu.dictionary.Keys;
                textBox_placeholder.Text = "";
                labelError.Content = "Object Deleted";
                //for (int i = 0; i < Staticheskyu.Placeholders.Count; i++)
                //{
                //    if (Staticheskyu.Placeholders[i].Name == PlaceName)
                //    {
                //        for (int g = 0; g < Staticheskyu.Placeholders[i].Games.Count; g++)
                //        {
                //            if (Staticheskyu.Placeholders[i].Games[g].Name == comboBox_gametoedit.Text)
                //            {
                //                Staticheskyu.Placeholders[i].Games.RemoveAt(g);
                //                labelError.Content = "Object Deleted";
                //                goto touchpoint;
                //            }
                //        }
                //        labelError.Content = "Not Found";
                //    }
                //}
                //touchpoint:
                //for (int i = 0; i < Staticheskyu.Vyvod.Count; i++)
                //{
                //    if (Staticheskyu.Vyvod[i].Name == comboBox_gametoedit.Text)
                //        Staticheskyu.Vyvod.RemoveAt(i);
                //}
            }
        }

        private void comboBox_gametoedit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
           if(comboBox_gametoedit.SelectedIndex!=-1) textBox_placeholder.Text = Staticheskyu.dictionary[comboBox_gametoedit.SelectedItem.ToString()];
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (comboBox_gametoedit.SelectedIndex == -1 || comboBox_replacetoanotherplaceholder.SelectedIndex == -1)
                labelError.Content = "Game or Placeholder not chosen";
            else
            if (Staticheskyu.Collection[comboBox_replacetoanotherplaceholder.Text].Games.Count == Staticheskyu.Collection[comboBox_replacetoanotherplaceholder.Text].Amount)
            { labelError.Content = "Chosen Placeholder is full"; }
            else
            {
                Game t = Staticheskyu.Collection[Staticheskyu.dictionary[comboBox_gametoedit.Text]].Games[comboBox_gametoedit.Text];
                
                Staticheskyu.Collection[Staticheskyu.dictionary[comboBox_gametoedit.Text]].Games.Remove(comboBox_gametoedit.Text);
                Staticheskyu.dictionary.Remove(comboBox_gametoedit.Text);
                Staticheskyu.dictionary.Add(comboBox_gametoedit.Text,comboBox_replacetoanotherplaceholder.Text);
                Staticheskyu.Collection[comboBox_replacetoanotherplaceholder.Text].Games.Add(comboBox_gametoedit.Text, t);
                textBox_placeholder.Text = comboBox_replacetoanotherplaceholder.Text;
                comboBox_replacetoanotherplaceholder.SelectedIndex = -1;
                


            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            int size;
            if (int.TryParse(textBox_sizeofnewplaceholder.Text, out size) == false)
            {
                labelError.Content = "Size of a new Placeholder is incorret";

            }
            else
            {
                size = int.Parse(textBox_sizeofnewplaceholder.Text);
                if (Staticheskyu.Collection.ContainsKey(textBox_newplaceholder.Text) == true || size <= 0)
                {
                    labelError.Content = "Name of a new Placeholder already exist or the size is incorrect";
                }
                else
                {
                    Staticheskyu.Collection.Add(textBox_newplaceholder.Text, new Chest(textBox_newplaceholder.Text, int.Parse(textBox_sizeofnewplaceholder.Text)));
                    comboBox_replacetoanotherplaceholder.ItemsSource = null;
                    comboBox_replacetoanotherplaceholder.ItemsSource = Staticheskyu.Collection.Keys;
                    textBox_newplaceholder.Text = "";
                    textBox_sizeofnewplaceholder.Text = "";
                }
            }
        }

        private void textBox_newplaceholder_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void textBox_sizeofnewplaceholder_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }
       
        private void textBox_newplaceholder_GotFocus(object sender, RoutedEventArgs e)
        {
             textBox_newplaceholder.Clear();
        }

        private void textBox_sizeofnewplaceholder_GotFocus(object sender, RoutedEventArgs e)
        {
           textBox_sizeofnewplaceholder.Clear();
        }

        private void textBox_sizeofnewplaceholder_LostFocus(object sender, RoutedEventArgs e)
        {
            if (textBox_sizeofnewplaceholder.Text == "") textBox_sizeofnewplaceholder.Text = "Enter a size of storage";
        }

        private void textBox_newplaceholder_LostFocus(object sender, RoutedEventArgs e)
        {
            if (textBox_newplaceholder.Text == "") textBox_newplaceholder.Text = "Enter Name";
        }

        private void button_Unloaded(object sender, RoutedEventArgs e)
        {
            Staticheskyu.Save();
        }
    }
}
