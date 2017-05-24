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
using System.Windows.Shapes;

namespace KDZVERSH
{
    /// <summary>
    /// Логика взаимодействия для Frame.xaml
    /// </summary>
    public partial class Frame : Window
    {
        public Frame()
        {
            InitializeComponent();
            FrameName.NavigationService.Navigate(new Uri("mainpage.xaml", UriKind.Relative));
        }
    }
}
