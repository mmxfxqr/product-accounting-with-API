using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Konti.Models
{
    public static class Appdata
    {
        public static Frame frame = new Frame();
        public static int idProduct { get; set; }
        public static string name { get; set; }
        public static string amount { get; set; }
        public static double price { get; set; }
        public static string type { get; set; }
    }

}
