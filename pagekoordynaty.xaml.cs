using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Text;
using System.Runtime.Serialization.Json;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

//Szablon elementu Pusta strona jest udokumentowany na stronie https://go.microsoft.com/fwlink/?LinkId=234238

namespace map
{
    /// <summary>
    /// Pusta strona, która może być używana samodzielnie lub do której można nawigować wewnątrz ramki.
    /// </summary>
    public sealed partial class pagekoordynaty : Page
    {
        
        string link = "http://dev.virtualearth.net/REST/v1/Locations?q=";
        string city="";
        string key = "&key=writeyourkey";
        public pagekoordynaty()
        {
            this.InitializeComponent();
        }

        private async void btnszuk_Click(object sender, RoutedEventArgs e)
        {
            if (boxdestination.Text != null)
            {
                city=boxdestination.Text;
                string json=link+city+key;
                /*using(HttpClient client =new HttpClient())
                {
                    var file = await client.GetAsync(json);
                    var datafromfile = await file.Content.ReadAsStringAsync();
                    var filee=new DataContractJsonSerializer(typeof)
                }*/
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(json);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();

                        // Parsowanie JSON do obiektu JObject
                        var data = JObject.Parse(content);

                        // Pobranie danych z obiektu JObject
                        var resourceSets = data["resourceSets"];
                        if (resourceSets != null && resourceSets.HasValues)
                        {
                            foreach (var resourceSet in resourceSets)
                            {
                                var resources = resourceSet["resources"];
                                if (resources != null && resources.HasValues)
                                {
                                    foreach (var resource in resources)
                                    {
                                        var name = resource["name"];
                                        var point = resource["point"];
                                        var coordinates = point?["coordinates"];

                                        if (name != null && coordinates != null)
                                        {
                                            boxlocation.Text = coordinates[0] +"" +coordinates[1];
                                            /*Console.WriteLine($"Szerokość geograficzna: {coordinates[0]}");
                                            Console.WriteLine($"Długość geograficzna: {coordinates[1]}");*/
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
