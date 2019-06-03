using System;

namespace NullReferenceSample
{
    class Program
    {
        static void Main(string[] args)
        {
            string? s = null;
            Console.WriteLine(s);

            var book = new Book("Professional C# 8");
            string title = book.Title;

            // string publisher = book.Publisher;

            if (book.Publisher != null)
            {
                string pub = book.Publisher.ToUpper();
            }

            string pub2 = book.Publisher!; // null forgiving operator

            string pub1 = book.Publisher?.ToUpper() ?? string.Empty;

            string s1 = book.ToString();

            var legacy = new LegacyBook();
            string oldTitle = legacy.Title;

            // Console.WriteLine(oldTitle.ToUpper());



        }
    }
}
