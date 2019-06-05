using System;

using UWPWithWindowsTemplateStudio.ViewModels;

using Windows.UI.Xaml.Controls;

namespace UWPWithWindowsTemplateStudio.Views
{
    public sealed partial class Chart1Page : Page
    {
        public Chart1ViewModel ViewModel { get; } = new Chart1ViewModel();

        // TODO WTS: Change the chart as appropriate to your app.
        // For help see http://docs.telerik.com/windows-universal/controls/radchart/getting-started
        public Chart1Page()
        {
            InitializeComponent();
        }
    }
}
