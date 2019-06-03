using System;
using System.Collections.Generic;

namespace IndexesAndRanges
{
    ref struct MyStruct
    {
        public int A;
    }

    class Program
    {
        static void Main(string[] args)
        {
            // SpanSample();
            RangeSampleWithArray();
            // RangeSampleWithString();
        }

        private static void RangeSampleWithString()
        {
            string s = "the quick brown fox jumped over the lazy dogs";
            string s2 = s.Substring(s.Length - 4);
            Console.WriteLine(s2);

            // hat operator
            var index = ^4;  // from the end
            string s3 = s[0..^1]; // from start to end
            string s4 = s[..];
            string s5 = s[^4..];

            Index index1 = ^3;
            Range range = 3..5;

        }

        private static void RangeSampleWithArray()
        {
            var data = (new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }).AsSpan();
            var data2 = data[3..5];
            data2[0] = 42;
        }

        private static void SpanSample()
        {
            int x = 42;
            object o = x; // boxing
            Foo(x);

            var ms = new MyStruct();
            ms.A = 42;
            // ms.ToString();

            int[] data = { 1, 2, 3, 4, 5, 6, 7, 8 };
            var span1 = data.AsSpan();
            var span2 = span1.Slice(2, 3);
            span2[0] = 42;

        }

        static void Foo(object o)
        {

        }
    }
}
