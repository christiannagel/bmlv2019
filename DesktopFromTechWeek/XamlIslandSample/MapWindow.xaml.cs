using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Interop = Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT;
using Toolkit = Microsoft.Toolkit.Wpf.UI.Controls;

namespace XamlIslandSample
{
    /// <summary>
    /// Interaction logic for MapWindow.xaml
    /// </summary>
    public partial class MapWindow : Window
    {
        public MapWindow()
        {
            InitializeComponent();
        }

        private async void OnLoadedMap(object sender, RoutedEventArgs e)
        {
            if (sender is Toolkit.MapControl mapControl)
            {
                var point = new Interop.Geopoint(new Interop.BasicGeoposition { Latitude = 48.1438, Longitude = 17.1097 });
                bool result = await mapControl.TrySetViewAsync(point);
            }
        }
    }
}
