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
    /// Логика взаимодействия для Edit.xaml
    /// </summary>
    public partial class Edit : Page
    {
        public Edit()
        {
            InitializeComponent();
            TxbName.Text = Appdata.name;
            TxbPrice.Text = Appdata.price.ToString();
            TxbAmount.Text = Appdata.amount;
            TxbType.Text = Appdata.type;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            Request.PutProduct(Appdata.idProduct,TxbName.Text,TxbAmount.Text, TxbType.Text, double.Parse(TxbPrice.Text));
            Appdata.frame.Navigate(new Product());
        }
    }
}
