using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

using Microsoft.Toolkit.Uwp.UI.Animations;

using UWPWithWindowsTemplateStudio.Core.Models;
using UWPWithWindowsTemplateStudio.Core.Services;
using UWPWithWindowsTemplateStudio.Helpers;
using UWPWithWindowsTemplateStudio.Services;
using UWPWithWindowsTemplateStudio.Views;

namespace UWPWithWindowsTemplateStudio.ViewModels
{
    public class ContentGrid1ViewModel : Observable
    {
        private ICommand _itemClickCommand;

        public ICommand ItemClickCommand => _itemClickCommand ?? (_itemClickCommand = new RelayCommand<SampleOrder>(OnItemClick));

        public ObservableCollection<SampleOrder> Source
        {
            get
            {
                // TODO WTS: Replace this with your actual data
                return SampleDataService.GetContentGridData();
            }
        }

        public ContentGrid1ViewModel()
        {
        }

        private void OnItemClick(SampleOrder clickedItem)
        {
            if (clickedItem != null)
            {
                NavigationService.Frame.SetListDataItemForNextConnectedAnimation(clickedItem);
                NavigationService.Navigate<ContentGrid1DetailPage>(clickedItem.OrderId);
            }
        }
    }
}
