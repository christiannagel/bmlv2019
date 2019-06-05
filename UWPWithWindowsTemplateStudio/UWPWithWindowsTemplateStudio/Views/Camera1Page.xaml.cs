using UWPWithWindowsTemplateStudio.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace UWPWithWindowsTemplateStudio.Views
{
    public sealed partial class Camera1Page : Page
    {
        public Camera1ViewModel ViewModel { get; } = new Camera1ViewModel();

        public Camera1Page()
        {
            InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            await cameraControl.InitializeCameraAsync();
        }

        protected override async void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            await cameraControl.CleanupCameraAsync();
        }
    }
}
