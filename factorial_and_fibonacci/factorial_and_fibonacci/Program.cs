using System;

namespace MyHomework
{
    class Program
    {
        static void Main(string[] args)
        {
            MyTasks.UserInterface();
        }
    }
    class MyTasks
    {
        public static void UserInterface()
        {
            Console.WriteLine("Input number");
            uint number = uint.Parse(Console.ReadLine());
            uint factorial = Utilities.Factorial(number);
            Console.Write($"{number} factorial is {factorial}\n");
            uint fibonacci = Utilities.Fibonacci(number);
            Console.Write($"{number} number in fibonacci series is {fibonacci}\n");
        }
    }
    class Utilities
    {
        public static uint Factorial(uint number)
        {
            if (number <= 1)
            {
                return 1;
            }
            return number * Factorial(number - 1);
        }

        public static uint Fibonacci(uint number)
        {
            if (number <= 2)
            {
                return 1;
            }
            return Fibonacci(number - 1) + Fibonacci(number - 2);
        }
    }
}