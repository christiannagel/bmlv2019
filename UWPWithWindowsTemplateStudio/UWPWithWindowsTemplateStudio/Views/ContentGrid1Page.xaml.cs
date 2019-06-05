using System;

using UWPWithWindowsTemplateStudio.ViewModels;

using Windows.UI.Xaml.Controls;

namespace UWPWithWindowsTemplateStudio.Views
{
    public sealed partial class ContentGrid1Page : Page
    {
        public ContentGrid1ViewModel ViewModel { get; } = new ContentGrid1ViewModel();

        public ContentGrid1Page()
        {
            InitializeComponent();
        }
    }
}
