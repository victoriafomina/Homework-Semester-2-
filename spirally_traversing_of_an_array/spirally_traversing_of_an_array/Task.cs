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
            int count = 1;
            for (var i = 0; i < size; ++i)
            {
                for (var j = 0; j < size; ++j)
                {
                    matrix[i, j] = count;
                    Console.Write($"{matrix[i, j]} ");
                    ++count;
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Traversing(matrix);
        }

        private static void Traversing(int[,] matrix)
        {
            var size = matrix.GetLength(0);
            Console.Write($"{matrix[size / 2, size / 2]} ");
            if (size > 1)
            {
                TraversingRecursion(matrix, 3, size / 2 + 1, size / 2);
            }
        }
    
        private static void TraversingRecursion(int[,] matrix, int dimension, int startRow, int startColumn)
        {
            if (dimension > matrix.GetLength(0))
            {
                return;
            }
            // нижняя строка
            for (var column = startColumn; column <= startColumn + dimension - 2; ++column)
            {
                Console.Write($"{matrix[startRow, column]} ");
            }
            // правый столбец
            for (var row = startRow - 1; row >= startRow - dimension + 1; --row)
            {
                Console.Write($"{matrix[row, startColumn + dimension - 2]} ");
            }
            // верхняя строка
            for (var column = startColumn + dimension - 3; column >= startColumn - 1; --column)
            {
                Console.Write($"{matrix[startRow - dimension + 1, column]} ");
            }
            // левый столбец
            for (int row = startRow - dimension + 2; row <= startRow; ++row)
            {
                Console.Write($"{matrix[row, startColumn - 1]} ");
            }
            TraversingRecursion(matrix, dimension + 2, startRow + 1, startColumn - 1);
        }
    }
}
