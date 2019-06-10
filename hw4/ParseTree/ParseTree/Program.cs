using System.IO;
using System;

namespace PrefixParseTree
{
    public class Program
    {
        static void Main(string[] args)
        {
            string prefixExpression = "";

            using (var file = new StreamReader("Expression.txt"))
            {
                prefixExpression = file.ReadLine();
            }

            var prefixCalculator = new ParseTree(prefixExpression);

            Console.WriteLine($"The expression in the file: {prefixExpression}");
            Console.WriteLine($"Calculated: {prefixCalculator.Calculate()}");
            Console.WriteLine($"Printed: {prefixCalculator.ToString()}");
        }
    }
}
