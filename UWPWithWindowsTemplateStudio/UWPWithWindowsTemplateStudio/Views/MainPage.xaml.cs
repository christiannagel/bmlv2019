using System;

using UWPWithWindowsTemplateStudio.ViewModels;

using Windows.UI.Xaml.Controls;

namespace UWPWithWindowsTemplateStudio.Views
{
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel { get; } = new MainViewModel();

        public MainPage()
        {
            InitializeComponent();
        }
    }
}
