using Newtonsoft.Json.Linq;
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

namespace Dandi
{
    /// <summary>
    /// Interaction logic for Schedule.xaml
    /// </summary>
    public partial class Schedule : UserControl
    {
        public Schedule()
        {
            InitializeComponent();
            this.DataContext = App.personalscheudle;
            this.DataContext = App.publicschedule;
        }

        public static void ScheduleLoad()
        {
#pragma warning disable IDE0059 // Unnecessary assignment of a value
            var client = new RestClient("http://10.80.162.124:5000");
#pragma warning restore IDE0059 // Unnecessary assignment of a value

#pragma warning disable IDE0059 // Unnecessary assignment of a value
            var request = new RestRequest("/channel-event", Method.GET);
#pragma warning restore IDE0059 // Unnecessary assignment of a value

#pragma warning disable IDE0059 // Unnecessary assignment of a value
            var json = new JObject();
#pragma warning restore IDE0059 // Unnecessary assignment of a value

            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", json, ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);

            var content = response.Content;

#pragma warning disable IDE0059 // Unnecessary assignment of a value
            var json2 = JObject.Parse(content);
#pragma warning restore IDE0059 // Unnecessary assignment of a value

            // Console.WriteLine(json2);
        }
    }
}
