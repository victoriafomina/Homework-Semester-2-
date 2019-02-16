using System;

namespace SortColumnsOfMatrixByFirstElements
{
    class Task
    {
        public static  void UserInteraface()
        {
            Console.WriteLine("Input number of rows");
            var rows = int.Parse(Console.ReadLine());
            Console.WriteLine("Input number of columns");
            var columns = int.Parse(Console.ReadLine());
            int[,] matrix = new int[rows, columns];
            Console.WriteLine($"Input {rows * columns} elements of matrix");
            for (var i = 0; i < rows; ++i)
            {
                for (var j = 0; j < columns; ++j)
                {
                    matrix[i, j] = int.Parse(Console.ReadLine());
                }
            }
            for (var i = 0; i < rows; ++i)
            {
                for (var j = 0; j < columns; ++j)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
            Sort.ShellSortForMatrix(matrix);
            Console.WriteLine("Result is");
            for (var i = 0; i < rows; ++i)
            {
                for (var j = 0; j < columns; ++j)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
