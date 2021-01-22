using System;
using System.Net.Http;
using System.Net;
using System.Threading;

namespace ConsoleApp1 {
   class Animal1
    {
        public void animalSound()
        {
            Console.WriteLine("the animal makes a sound");
        }
    }

    class Pig1: Animal1
    {
        public new void animalSound()
        {
            Console.WriteLine("the pig says: wee wee");
        }
    }

    class Dog1: Animal1
    {
        public new void animalSound()
        {
            Console.WriteLine("the dog says: bow bow");
        }
    }

    class Out{ }
}


