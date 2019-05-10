using System;
namespace FinalTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Input number of the strings\n");
            int numberOfStr = int.Parse(Console.ReadLine());

            string[] array = new string[numberOfStr];

            string str;

            for (int i = 0; i < numberOfStr; ++i)
            {
                str = Console.ReadLine();
                array[i] = str;
            }
            
            ListApplication app = new ListApplication(array);
            app.Run();
        }
    }
}
