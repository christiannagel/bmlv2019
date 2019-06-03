using System;
using System.Collections.Generic;
using System.Text;

namespace DefaultInterfaceMethods
{
    public class FooClass : IFoo, IBar
    {
        public void Foo() => Console.WriteLine("Foo");
        void IBar.Bar() => Console.WriteLine("FooClass.IBar Bar");

        // public void Bar() => Console.WriteLine("FooClass.Bar");
    }

    public class FooBarClass : IFooBar
    {
       //  public void Bar() => Console.WriteLine("FooBar.Bar");
        public void Foo() => Console.WriteLine("FooBar.Foo");
    }
}
