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

//Szablon elementu Pusta strona jest udokumentowany na stronie https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x415

namespace map
{
    /// <summary>
    /// Pusta strona, która może być używana samodzielnie lub do której można nawigować wewnątrz ramki.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            map.Style = MapStyle.Terrain;
            BasicGeoposition cityPosition = new BasicGeoposition()
            {
                Latitude = 54.35603333,
                Longitude = 18.64612007
            };
            Geopoint cityCenter = new Geopoint(cityPosition);

            map.Center = cityCenter;
            map.ZoomLevel = 12;
        }


        public void powieksz()
        {
            map.ZoomLevel++;
        }
        public void oddal()
        {
            map.ZoomLevel--;
        }
        public void satelita()
        {

        }
        public void koordynaty() 
        { 

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
            Frame.Navigate(typeof(pagekoordynaty));
            Frame.BackStack.Clear();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            Geopoint city = e.Parameter as Geopoint;
            if (city != null)
            {
                map.Center = city;
            }
        }
        
    }

    
}
