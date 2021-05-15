namespace SortColumnsOfMatrixByFirstElements
{
    class Sort
    {
        public static void ShellSortForMatrix(int[,] array)
        {
            int j = 0;
            int rows = array.GetLength(0);
            var step = rows / 2;
            while (step > 0)
            {
                for (var i = 0; i < rows - step; ++i)
                {
                    j = i;
                    while (j >= 0 && array[0, j] > array[0, j + step])
                    {
                        for (var k = 0; k < rows; ++k)
                        {
                            var temp = array[k, j];
                            array[k, j] = array[k, j + step];
                            array[k, j + step] = temp;
                        }
                        j -= step;
                    }
                }
                step = step / 2;
            }
        }
    }
}