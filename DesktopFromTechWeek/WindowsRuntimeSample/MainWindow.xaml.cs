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

namespace WindowsRuntimeSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static int s_badgeNumber = 0;
        public static int GetBadgeNumber() => Interlocked.Increment(ref s_badgeNumber);

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnUpdateTile(object sender, RoutedEventArgs e)
        {
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
