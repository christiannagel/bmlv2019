using System;

using UWPWithWindowsTemplateStudio.ViewModels;

using Windows.UI.Xaml.Controls;

namespace UWPWithWindowsTemplateStudio.Views
{
    public sealed partial class ImageGallery1Page : Page
    {
        public ImageGallery1ViewModel ViewModel { get; } = new ImageGallery1ViewModel();

        public ImageGallery1Page()
        {
            InitializeComponent();
        }
    }
}
