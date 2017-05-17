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
    /// Логика взаимодействия для Search.xaml
    /// </summary>
    public partial class Search : Page
    {
        string name, genre, age, storage;

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Staticheskyu.Save();
        }

        List<Game> answer = new List<Game>();
        public Search(string Name,  string Age, string Genre, string Storage)
        {
            InitializeComponent();
            name = Name;
            genre = Genre;
            age = Age;
            storage = Storage;
            Show();
        }

        void Show()
        {
            
            foreach(string t in Staticheskyu.dictionary.Keys)
            {
                if(t.Contains(name)||name=="")
                {
                    if ((genre == Staticheskyu.Collection[Staticheskyu.dictionary[t]].Games[t].Genre || genre == "") && (age == Staticheskyu.Collection[Staticheskyu.dictionary[t]].Games[t].Age || age == "") && (Staticheskyu.Collection[Staticheskyu.dictionary[t]].Name == storage || storage == ""))
                        answer.Add(Staticheskyu.Collection[Staticheskyu.dictionary[t]].Games[t]);


                }

            }
            dataGrid.ItemsSource = answer;

        }
    }
}
