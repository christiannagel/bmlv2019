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

namespace XamlIslandSample
{
    /// <summary>
    /// Interaction logic for InkWindow.xaml
    /// </summary>
    public partial class InkWindow : Window
    {
        public InkWindow()
        {
            InitializeComponent();
        }

        private void OnClose(object sender, RoutedEventArgs e)
        {

        }

        private void OnInkLoaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
