using Microsoft.Toolkit.Wpf.UI.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
using Interop = Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT;
using Toolkit = Microsoft.Toolkit.Wpf.UI.Controls;

namespace XAMLIslandSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
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

        private static int s_badgeNumber;
        private void OnUpdateTile(object sender, RoutedEventArgs e)
        {
            static int GetBadgeNumber() => Interlocked.Increment(ref s_badgeNumber); 

            try
            {
                XmlDocument badgeXml = BadgeUpdateManager.GetTemplateContent(BadgeTemplateType.BadgeNumber);
                XmlNodeList badge = badgeXml.GetElementsByTagName("badge");
                badge[0].Attributes[0].NodeValue = GetBadgeNumber().ToString();
                var notification = new BadgeNotification(badgeXml);
                BadgeUpdateManager.CreateBadgeUpdaterForApplication().Update(notification);
            }
            catch (Exception ex) when (ex.HResult == -2147023728)
            {
                MessageBox.Show("not started with a package?");
            }
        }
    }
}
