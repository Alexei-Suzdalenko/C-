using System;


namespace ConsoleApp1 {
    abstract class Animal
    {
        public abstract void animalSound();
        public void sleep()
        {
            Console.WriteLine("Z z z z");
        }
    }

    class Pig : Animal
    {
        public override void animalSound()
        {
            Console.WriteLine("the pig says: wee wee");
        }
    }
}


