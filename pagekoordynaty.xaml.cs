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
using Windows.Devices.Geolocation;
using System.Globalization;

//Szablon elementu Pusta strona jest udokumentowany na stronie https://go.microsoft.com/fwlink/?LinkId=234238

namespace map
{
    /// <summary>
    /// Pusta strona, która może być używana samodzielnie lub do której można nawigować wewnątrz ramki.
    /// </summary>
    public sealed partial class pagekoordynaty : Page
    {
        double destheight, destwidth;
        string link = "http://dev.virtualearth.net/REST/v1/Locations?q=";
        string city="";
        string key = "&key=Yourkey";
        Geopoint ct1;
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
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(json);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();

                        var data = JObject.Parse(content);

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
                                            string sub1 = coordinates[0].ToString();
                                            string pomsub1 = sub1.Replace(",", ".");
                                            string sub2 = coordinates[1].ToString();
                                            string pomsub2= sub2.Replace(",", ".");
                                            double lt1 = double.Parse(pomsub1, CultureInfo.InvariantCulture);
                                            double lg1 = double.Parse(pomsub2, CultureInfo.InvariantCulture);
                                            ct1 = new Geopoint(new BasicGeoposition()
                                            {
                                                Latitude = lt1,
                                                Longitude = lg1
                                            });
                                            geograficzna.Text = "Długość geograficzna: " + pomsub1+" \nSzerokość geograficzna: " + pomsub2;
                                            destheight = lt1;
                                            destwidth = lg1;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void btnpow_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage), new Tuple<double, double>(destheight, destwidth));
            Frame.BackStack.Clear();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            string[] parts = e.Parameter.ToString().Split(' ');
            if (parts.Length == 2)
            {
                int sub1= parts[0].IndexOf(",");
                string sub11 = parts[0].Substring(1, sub1);
                string sub12 = parts[0].Substring(sub1+1);
                int lensub12 = sub12.Length-1;
                sub12=sub12.Substring(0, lensub12);
                double licz1=double.Parse(sub11)+((double.Parse(sub12))/(10*lensub12));

                int sub2 = parts[1].IndexOf(",");
                string sub21 = parts[1].Substring(0, sub2);
                string sub22 = parts[1].Substring(sub2);
                int len22=sub22.Length-1;
                sub22=sub22.Substring(0, len22);
                double licz2 = double.Parse(sub21) + ((double.Parse(sub22)) / (10 * len22));

                boxlocation.Text = sub11+sub12+" " + sub21+sub22 /*licz1.ToString()*/;
                if (double.TryParse(parts[0], out destheight) && double.TryParse(parts[1], out destwidth))
                {
                    boxdestination.Text = destheight.ToString() + " " + destwidth.ToString();
                }
            }

        }
    }
}
