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
using RestSharp;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Konti.Pages
{
    /// <summary>
    /// Логика взаимодействия для SingIn.xaml
    /// </summary>
    public partial class SingIn : Page
    {
        public SingIn()
        {
            InitializeComponent();
        }

        private void BtnSing_Click(object sender, RoutedEventArgs e)
        {
            var client = new RestClient();
            var request = new RestRequest("http://localhost:5240/api/UserAuthorizations/auth", Method.Post);
            var body = new UserAuth {
                idUser = 0,
                login = TxbLogin.Text,
                password= TxbPassword.Text,
            };
            var send = JsonConvert.SerializeObject(body);
            request.AddBody(send);
            RestResponse response = client.Execute(request);
            if (response.IsSuccessStatusCode)
            {
                Appdata.frame.Navigate(new MainPage());
            }
            else
            {
                MessageBox.Show("Такого пользователя не существует, зарегестрируйтесь");
            }
        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            Appdata.frame.Navigate(new Registr());
        }
    }
}
