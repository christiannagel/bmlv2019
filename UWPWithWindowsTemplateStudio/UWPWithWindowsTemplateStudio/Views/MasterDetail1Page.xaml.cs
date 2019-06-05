using System;

using UWPWithWindowsTemplateStudio.ViewModels;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UWPWithWindowsTemplateStudio.Views
{
    public sealed partial class MasterDetail1Page : Page
    {
        public MasterDetail1ViewModel ViewModel { get; } = new MasterDetail1ViewModel();

        public MasterDetail1Page()
        {
            InitializeComponent();
            Loaded += MasterDetail1Page_Loaded;
        }

        private async void MasterDetail1Page_Loaded(object sender, RoutedEventArgs e)
        {
            await ViewModel.LoadDataAsync(MasterDetailsViewControl.ViewState);
        }
    }
}
