using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
using Windows.UI.Xaml.Controls.Maps;
using Windows.Devices.Geolocation;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net.Http;
using Windows.Services.Maps;
using Windows.UI;
using System.Net;

//Szablon elementu Pusta strona jest udokumentowany na stronie https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x415

namespace map
{
    /// <summary>
    /// Pusta strona, która może być używana samodzielnie lub do której można nawigować wewnątrz ramki.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        double yourheight, yourwidth;
        double destheight, destwidth;
        public string a;
        Geolocator geolocator = new Geolocator();
        Geopoint yourlocation;
        public MainPage()
        {
            this.InitializeComponent();
            map.Style = MapStyle.Terrain;
            map.ZoomLevel = 10;
            geolocator.DesiredAccuracyInMeters = 100;

            yourlocalization();

        }
        private async Task yourlocalization()
        {
            try
            {
                Geoposition position = await geolocator.GetGeopositionAsync();
                yourheight = position.Coordinate.Point.Position.Latitude;
                yourwidth = position.Coordinate.Point.Position.Longitude;
                yourlocation = new Geopoint(new BasicGeoposition()
                {
                    Latitude = position.Coordinate.Point.Position.Latitude,
                    Longitude = position.Coordinate.Point.Position.Longitude

                });
                map.Center = yourlocation;
            }
            catch
            {
            }
        }


        public void powieksz()
        {
            map.ZoomLevel++;
        }
        public void oddal()
        {
            map.ZoomLevel--;
        }
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            powieksz();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            oddal();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (map.Style == MapStyle.Terrain)
            {
                map.Style = MapStyle.Aerial;
            }
            else
            {
                map.Style = MapStyle.Terrain;
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(pagekoordynaty), new Tuple<double, double>(yourheight, yourwidth));
            Frame.BackStack.Clear();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string[] parts = e.Parameter.ToString().Split(',');
            if (parts.Length == 2)
            {
                double latitude, longitude;
                if (double.TryParse(parts[0], out latitude) && double.TryParse(parts[1], out longitude))
                {
                    Tuple<double, double> parameters = Tuple.Create(latitude, longitude);
                    // Teraz możesz użyć parametrów
                    destheight = parameters.Item1;
                    destwidth = parameters.Item2;
                    routetopoint();
                }
            }


            

        }
        private async Task routetopoint()
        {

            BasicGeoposition destinationPoint = new BasicGeoposition()
            {
                Latitude = destheight,
                Longitude = destwidth
            };
            Geopoint endPoint = new Geopoint(destinationPoint);
            
            MapRouteFinderResult routeResult = await MapRouteFinder.GetDrivingRouteAsync(yourlocation, endPoint);

            // Rysowanie trasy na mapie
            if (routeResult.Status == MapRouteFinderStatus.Success)
            {
                MapRouteView routeView = new MapRouteView(routeResult.Route);
                routeView.RouteColor = Windows.UI.Colors.Blue;
                map.Routes.Add(routeView);
            }


        }

        
    }


}
