using System;

namespace SortColumnsOfMatrixByFirstElements
{
    class Task
    {
        public static  void UserInteraface()
        {
            Console.WriteLine("Input number of rows");
            int rows = int.Parse(Console.ReadLine());
            Console.WriteLine("Input number of columns");
            int columns = int.Parse(Console.ReadLine());
            int[,] matrix = new int[rows, columns];
            Console.WriteLine($"Input {rows * columns} elements of matrix");
            for (var i = 0; i < rows; ++i)
            {
                for (var j = 0; j < columns; ++j)
                {
                    matrix[i, j] = int.Parse(Console.ReadLine());
                }
            }
        }
    }
}
