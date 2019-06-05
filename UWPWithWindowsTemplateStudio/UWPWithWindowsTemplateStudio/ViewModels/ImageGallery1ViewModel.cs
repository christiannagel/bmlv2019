using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

using Microsoft.Toolkit.Uwp.UI.Animations;

using UWPWithWindowsTemplateStudio.Core.Models;
using UWPWithWindowsTemplateStudio.Core.Services;
using UWPWithWindowsTemplateStudio.Helpers;
using UWPWithWindowsTemplateStudio.Services;
using UWPWithWindowsTemplateStudio.Views;

using Windows.UI.Xaml.Controls;

namespace UWPWithWindowsTemplateStudio.ViewModels
{
    public class ImageGallery1ViewModel : Observable
    {
        public const string ImageGallery1SelectedIdKey = "ImageGallery1SelectedIdKey";

        private ObservableCollection<SampleImage> _source;
        private ICommand _itemSelectedCommand;

        public ObservableCollection<SampleImage> Source
        {
            get => _source;
            set => Set(ref _source, value);
        }

        public ICommand ItemSelectedCommand => _itemSelectedCommand ?? (_itemSelectedCommand = new RelayCommand<ItemClickEventArgs>(OnsItemSelected));

        public ImageGallery1ViewModel()
        {
            // TODO WTS: Replace this with your actual data
            Source = SampleDataService.GetGallerySampleData();
        }

        private void OnsItemSelected(ItemClickEventArgs args)
        {
            var selected = args.ClickedItem as SampleImage;
            ImagesNavigationHelper.AddImageId(ImageGallery1SelectedIdKey, selected.ID);
            NavigationService.Frame.SetListDataItemForNextConnectedAnimation(selected);
            NavigationService.Navigate<ImageGallery1DetailPage>(selected.ID);
        }
    }
}
