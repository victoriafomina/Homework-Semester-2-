using System;
using System.Collections.Generic;

namespace FinalTest
{
    public class ListApplication
    {
        private SortedSet set;

        /// <summary>
        /// Initializes an object of the class ListApplication.
        /// </summary>
        public ListApplication(string[] array)
        {
            if (array == null)
            {
                throw new NullReferenceException("Array is equal to null!\n");
            }

            if (array.Length == 0)
            {
                throw new InvalidOperationException("Array is empty!\n");
            }

            List<char> list;

            set = new SortedSet();

            bool flagNotEmptyList = false;

            for (int i = 0; i < array.Length; ++i)
            {
                list = new List<char>();
                for (int j = 0; j < array[i].Length; ++j)
                {
                    if ((array[i])[j] == ' ')
                    {
                        if (flagNotEmptyList)
                        {
                            set.Add(list);
                        }
                        flagNotEmptyList = false;
                    }
                    else
                    {
                        if (!flagNotEmptyList)
                        {
                            list = new List<char>();
                        }
                        list.Add((array[i])[j]);
                        flagNotEmptyList = true;
                        if (j == array[i].Length - 1)
                        {
                            set.Add(list);
                            flagNotEmptyList = false;
                        }
                    }
                }
            }
        }

        public override string ToString()
        {
            return set.ToString();
        }

        /// <summary>
        /// Starts executing the application.
        /// </summary>
        public void Run()
        {
            Console.WriteLine(ToString());
        }
    }
}
