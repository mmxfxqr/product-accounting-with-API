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
    /// Логика взаимодействия для Users.xaml
    /// </summary>
    public partial class Users : Page
    {
        public Users()
        {
            InitializeComponent();
            var client = new RestClient();
            var request = new RestRequest("http://localhost:5240/api/UserAuthorizations", Method.Get);
            var response = client.Execute(request);
            var result = JsonConvert.DeserializeObject<List<UserAuth>>(response.Content);
            ProductList.ItemsSource = result;
        }

        private void TxbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
               
        }
    }
}
