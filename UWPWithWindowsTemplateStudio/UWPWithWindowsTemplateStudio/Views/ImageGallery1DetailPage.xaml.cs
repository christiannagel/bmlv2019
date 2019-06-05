using System;

using Microsoft.Toolkit.Uwp.UI.Animations;

using UWPWithWindowsTemplateStudio.Core.Models;
using UWPWithWindowsTemplateStudio.Helpers;
using UWPWithWindowsTemplateStudio.Services;
using UWPWithWindowsTemplateStudio.ViewModels;

using Windows.System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

namespace UWPWithWindowsTemplateStudio.Views
{
    public sealed partial class ImageGallery1DetailPage : Page
    {
        public ImageGallery1DetailViewModel ViewModel { get; } = new ImageGallery1DetailViewModel();

        public ImageGallery1DetailPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            ViewModel.Initialize(e.Parameter as string, e.NavigationMode);
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            base.OnNavigatingFrom(e);
            if (e.NavigationMode == NavigationMode.Back)
            {
                NavigationService.Frame.SetListDataItemForNextConnectedAnimation(ViewModel.SelectedImage);
                ImagesNavigationHelper.RemoveImageId(ImageGallery1ViewModel.ImageGallery1SelectedIdKey);
            }
        }

        private void OnPageKeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Escape && NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
                e.Handled = true;
            }
        }
    }
}
