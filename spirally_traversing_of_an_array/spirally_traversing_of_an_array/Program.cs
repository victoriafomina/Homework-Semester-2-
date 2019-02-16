using System;

namespace TraversingOfAnArray
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class Task
    {
        public static void UserInterface()
        {
            Console.WriteLine("Input size of an array");
            int size = int.Parse(Console.ReadLine());
            int[,] array = new int[size, size];
            Console.WriteLine($"Input {size * size} elements");
            for (var i = 0; i < size; ++i)
            {
                for (var j = 0; j < size; ++j)
                {
                    array[i, j] = int.Parse(Console.ReadLine());
                }
            }
        }

        static void Traversing(int[,] array)
        {
            int count = 2;
            int x = array.GetLength(0) + 1;
            int y = array.GetLength(0);
            while (true)
            {
                int current = 0;
                while (current < count)
                {
                    Console.WriteLine($"array[x - 1, y]");
                    --x;
                    ++current;
                }
                current = 0;
                while (current < count - 1)
                {
                    Console.WriteLine($"array[,]");
                    ++y;
                    ++current;
                }
            }
         
        }
    }
}
