using System;

namespace TraversingOfMatrix
{
    class Task
    {
        public static void UserInterface()
        {
            Console.WriteLine("Input dimension of a squared matrix");
            var size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];
            Console.WriteLine($"Input {size * size} elements");
            for (var i = 0; i < size; ++i)
            {
                for (var j = 0; j < size; ++j)
                {
                    matrix[i, j] = int.Parse(Console.ReadLine());
                }
            }
            Traversing(matrix);
        }

        static void Traversing(int[,] matrix)
        {
            var size = matrix.GetLength(0);
            Console.WriteLine($"{matrix[size / 2, size / 2]}");
            if (size > 1)
            {
                TraversingRecursion(matrix, 3, size / 2 - 1, size / 2);
            }
        }

        static void TraversingRecursion(int[,] matrix, int dimension, int startRow, int startColumn)
        {
            if (dimension > matrix.GetLength(0))
            {
                return;
            }
            for (var column = startColumn; startColumn <= startColumn + dimension - 2; ++column)
            {
                Console.WriteLine($"{matrix[startRow, column]}");
            }
            for (var row = startRow + 1; row >= startRow - dimension + 1; --row)
            {
                Console.WriteLine($"{matrix[row, startColumn + 1]}");
            }
            for (var column = startColumn + dimension - 3; column >= startColumn - 1; --column)
            {
                Console.WriteLine($"{matrix[startRow - dimension + 1, column]}");
            }
            for (var row = startRow - dimension + 2; row <= startRow; ++row)
            {
                Console.WriteLine($"{matrix[row, startColumn]}");
            }
            TraversingRecursion(matrix, dimension + 2, startRow + 1, startColumn - 1);
        }
    }
}
