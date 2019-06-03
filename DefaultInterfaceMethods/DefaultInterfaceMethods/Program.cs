using System;

namespace DefaultInterfaceMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            IFoo f = new FooClass();
            f.Foo();
            f.Bar();

            FooClass f2 = new FooClass();
            f2.Foo();
        }
    }
}
