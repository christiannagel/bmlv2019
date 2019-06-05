using Microsoft.Toolkit.Wpf.UI.XamlHost;
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
using UWPControls = Windows.UI.Xaml.Controls;

namespace XamlIslandSample
{
    /// <summary>
    /// Interaction logic for XamlHostWindow.xaml
    /// </summary>
    public partial class XamlHostWindow : Window
    {
        public XamlHostWindow()
        {
            InitializeComponent();
        }

        private void OnHostChildChanged(object sender, EventArgs e)
        {
            if (sender is WindowsXamlHost host && host.Child is UWPControls.Button button)
            {
                button.Content = "My UWP Button";

                button.Click += (sender1, e1) =>
                {
                    MessageBox.Show("UWP button clicked");
                };
            }
        }
    }
}
