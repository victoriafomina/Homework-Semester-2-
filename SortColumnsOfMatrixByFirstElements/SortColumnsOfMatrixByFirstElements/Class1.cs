using System;

namespace SortColumnsOfMatrixByFirstElements
{
    class Sort
    {
        static void ShellSort(int[] array)
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