using System;
namespace ConsoleApp1 {
    interface Ejample
    {
        void first();
    }

    interface NewEjample
    {
        void second();
    }

    class Fish : Ejample, NewEjample
    {
        public void first()
        {
            Console.WriteLine("first method");
        }
        public void second()
        {
            Console.WriteLine("second method");
        }
    }
}


