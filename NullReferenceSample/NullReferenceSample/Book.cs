using System;
using System.Collections.Generic;
using System.Text;

namespace NullReferenceSample
{
    public class Book
    {
        public Book(string title)
        {
            Title = title;
            // Init();
            // Title = InitTitle();
        }

        private string InitTitle()
        {
            return string.Empty;
        }
        public string Title { get; set; }
        public string? Publisher { get; set; }


    }
}
