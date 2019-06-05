using System;
using System.Collections.ObjectModel;

using UWPWithWindowsTemplateStudio.Core.Models;
using UWPWithWindowsTemplateStudio.Core.Services;
using UWPWithWindowsTemplateStudio.Helpers;

namespace UWPWithWindowsTemplateStudio.ViewModels
{
    public class DataGrid1ViewModel : Observable
    {
        public ObservableCollection<SampleOrder> Source
        {
            get
            {
                // TODO WTS: Replace this with your actual data
                return SampleDataService.GetGridSampleData();
            }
        }
    }
}
