using System;
using System.Collections.Generic;
using System.Text;

namespace DefaultInterfaceMethods
{
    public interface IFoo
    {
        void Foo();
        public virtual void Bar()
        {
            MyBar();
        } 

        private void MyBar()
        {
            Console.WriteLine("IFoo version MyBar");
        }
    }

    public interface IBar
    {
        public virtual void Bar() => Console.WriteLine("IBar.Bar");
    }

    public interface IFooBar : IFoo, IBar
    {

    }
}
