using Konti.Pages;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Konti.Models
{
    public class Request
    {
        public static List<Products> Get()
        {
            var client = new RestClient();
            var request = new RestRequest("http://localhost:5240/api/Products", Method.Get);
            var response = client.Execute(request);
            var result = JsonConvert.DeserializeObject<List<Products>>(response.Content);
            return result;
        }
        public static bool DeleatProduct(int id)
        {
            var client = new RestClient();
            var request = new RestRequest($"http://localhost:5240/api/Products/{id}", Method.Delete);
            var response = client.Execute(request);
            return response.IsSuccessStatusCode;
        }
        public static void PutProduct(int id, string name, string amount, string type, double price)
        {
       
            var client = new RestClient();
            var request = new RestRequest($"http://localhost:5240/api/Products/{id}", Method.Put);
            var body = new Products
            {
               idProduct= id,
               name = name,
               amount = amount,
               type = type,
               price = price
            };
            var send = JsonConvert.SerializeObject(body);
            request.AddBody(send);
            RestResponse response = client.Execute(request);
           
        }
    }
}
