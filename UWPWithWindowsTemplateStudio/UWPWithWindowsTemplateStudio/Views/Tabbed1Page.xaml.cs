using System;

using UWPWithWindowsTemplateStudio.ViewModels;

using Windows.UI.Xaml.Controls;

namespace UWPWithWindowsTemplateStudio.Views
{
    public sealed partial class Tabbed1Page : Page
    {
        public Tabbed1ViewModel ViewModel { get; } = new Tabbed1ViewModel();

        public Tabbed1Page()
        {
            InitializeComponent();
        }
    }
}
