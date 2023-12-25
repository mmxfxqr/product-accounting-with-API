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
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Page
    {
        public Add()
        {
            InitializeComponent();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            var client = new RestClient();
            var request = new RestRequest("http://localhost:5240/api/Products", Method.Post);
            var body = new Products
            {
                idProduct = 0,
                name = TxbName.Text,
                price = int.Parse(TxbPrice.Text),
                amount = TxbAmount.Text,
                type = TxbType.Text
                

            };
            var send = JsonConvert.SerializeObject(body);
            request.AddBody(send);
            RestResponse response = client.Execute(request);
            if(response.IsSuccessStatusCode)
            {
                
                Appdata.frame.Navigate(new Product());
            }
        }
    }
}
