using System;
using System.Collections.Generic;
using System.Text;

namespace NullReferenceSample
{
#nullable disable

    public class LegacyBook
    {
        public string Title { get; set; }
        public string Publisher { get; set; }
    }

#nullable enable
}
