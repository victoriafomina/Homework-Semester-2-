using System;

namespace Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.UserInterface();
        }
    }

    class Task
    {
        public static void UserInterface()
        {
            Console.WriteLine("Input size of an array");
            int size = int.Parse(Console.ReadLine());
            Console.WriteLine($"Input {size} elements of an array");
            int[] array = new int[size];
            for (var i = 0; i < size; ++i)
            {
                array[i] = int.Parse(Console.ReadLine());
            }
            Sort(array);
            for (var i = 0; i < size; ++i)
            {
                Console.WriteLine($"{array[i]} ");
            }
            Console.WriteLine("\n");
        }

        static void Sort(int[] array)
        {
            int j = 0;
            int step = array.Length / 2;
            while (step > 0)
            {
                for (int i = 0; i < array.Length - step; ++i)
                {
                    j = i;
                    while (j >= 0 && array[j] > array[j + step])
                    {
                        int temp = array[j];
                        array[j] = array[j + step];
                        array[j + step] = temp;
                        j -= step;
                    }
                }
                step = step / 2;
            }
        }
    }
}
