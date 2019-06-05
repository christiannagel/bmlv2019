using System;
using System.Linq;
using System.Windows.Input;

using UWPWithWindowsTemplateStudio.Core.Models;
using UWPWithWindowsTemplateStudio.Core.Services;
using UWPWithWindowsTemplateStudio.Helpers;
using UWPWithWindowsTemplateStudio.Services;

namespace UWPWithWindowsTemplateStudio.ViewModels
{
    public class ContentGrid1DetailViewModel : Observable
    {
        private SampleOrder _item;

        public SampleOrder Item
        {
            get { return _item; }
            set { Set(ref _item, value); }
        }

        private ICommand _goBackCommand;

        public ICommand GoBackCommand => _goBackCommand ?? (_goBackCommand = new RelayCommand(OnGoBack));

        public ContentGrid1DetailViewModel()
        {
        }

        public void Initialize(long orderId)
        {
            var data = SampleDataService.GetContentGridData();
            Item = data.First(i => i.OrderId == orderId);
        }

        private void OnGoBack()
        {
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }
    }
}
