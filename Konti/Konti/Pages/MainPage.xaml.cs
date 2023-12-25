using Konti.Models;
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

namespace Konti.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Appdata.frame.Navigate(new Product());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Appdata.frame.Navigate(new Provider());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Appdata.frame.Navigate(new Workers());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Appdata.frame.Navigate(new Supply());
        }

        

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Appdata.frame.Navigate(new Stock());
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Appdata.frame.Navigate(new Users());
        }
    }
}
