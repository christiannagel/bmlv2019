using System;

using Microsoft.Toolkit.Uwp.UI.Animations;

using UWPWithWindowsTemplateStudio.Services;
using UWPWithWindowsTemplateStudio.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace UWPWithWindowsTemplateStudio.Views
{
    public sealed partial class ContentGrid1DetailPage : Page
    {
        public ContentGrid1DetailViewModel ViewModel { get; } = new ContentGrid1DetailViewModel();

        public ContentGrid1DetailPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter is long orderId)
            {
                ViewModel.Initialize(orderId);
            }
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            base.OnNavigatingFrom(e);
            if (e.NavigationMode == NavigationMode.Back)
            {
                NavigationService.Frame.SetListDataItemForNextConnectedAnimation(ViewModel.Item);
            }
        }
    }
}
