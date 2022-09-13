using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
using Azure.Core;
using Glimpse.AspNet.Model;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public class CoinsAPI {
        static async Task Main(string[] args)
        {
            using(System.Net.Http.HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.exchangeratesapi.io/v1/");
                HttpResponseMessage response = client.GetAsync("serverlist.php").Result;
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    var obj = System.Text.Json.JsonSerializer.Deserialize<ServerModel>(result);
                }
                lvwServer.ItemsSource = obj.servers; //accessing saved api data
                lvwServer.DisplayMemberPath = "dns";
            }
        }
    
}
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
