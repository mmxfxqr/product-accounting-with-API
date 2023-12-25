using Konti.Models;
using Newtonsoft.Json;
using RestSharp;
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
    /// Логика взаимодействия для Product.xaml
    /// </summary>
    public partial class Product : Page
    {
        public Product()
        {
            InitializeComponent();

            
            ProductList.ItemsSource = Request.Get();

            
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }


        private void BtnAdd_Click_1(object sender, RoutedEventArgs e)
        {
            Appdata.frame.Navigate(new Add());
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var item = ProductList.SelectedItem as Products;
            Appdata.idProduct = item.idProduct;
            Appdata.price = item.price;
            Appdata.amount = item.amount;
            Appdata.name = item.name;
            Appdata.type = item.type;
            Appdata.frame.Navigate(new Edit());
        }

        private void BtnDeleat_Click(object sender, RoutedEventArgs e)
        {
            var id = ProductList.SelectedItem as Products;
            Request.DeleatProduct(id.idProduct);
            ProductList.ItemsSource = Request.Get();
        }

        private void TxbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            ProductList.ItemsSource = Request.Get().Where(p => p.name.ToLower().Trim().Contains(TxbSearch.Text.ToLower().Trim()));
        }
    }
}
