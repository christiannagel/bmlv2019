using DataBindingSamples.Models;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace DataBindingSamples.Utilities
{
    public class BookTemplateSelector : DataTemplateSelector
    {
        public DataTemplate WroxTemplate { get; set; }
        public DataTemplate DefaultTemplate { get; set; }

        //protected override DataTemplate SelectTemplateCore(object item)
        //{
        //    DataTemplate selectedTemplate = null;
        //    if (item == null) return null;

        //    switch (item)
        //    {
        //        case Book b when b.Publisher == "Wrox Press":
        //            selectedTemplate = WroxTemplate;
        //            break;
        //        default:
        //            selectedTemplate = DefaultTemplate;
        //            break;
        //    }

        //    return selectedTemplate;
        //}

        protected override DataTemplate SelectTemplateCore(object item)
            => item switch
            {
                Book { Publisher: "Wrox Press"} => WroxTemplate,
                Book _ => DefaultTemplate,
                _ => null
            };
    }
}
