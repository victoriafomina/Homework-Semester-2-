using System;
using System.Collections.Generic;

namespace FinalTest
{
    /// <summary>
    /// Implements sorted set container.
    /// </summary>
    public class SortedSet
    {
        private List<List<char>> set;

        /// <summary>
        /// Initializes an object of sorted set.
        /// </summary>
        public SortedSet()
        {
            set = new List<List<char>>();
        }
        
        /// <summary>
        /// Adds an element to the sorted set.
        /// </summary>
        public void Add(List<char> list)
        {
            set.Insert(set.Count, list);
            Sort();
        }

        private void Sort()
        {
            if (set.Count == 0)
            {
                throw new InvalidOperationException("Set is empty!\n");
            }

            ListComparer comp = new ListComparer();

            for (int i = 0; i < set.Count - 1; ++i)
            {
                for (int j = 0; j < set.Count - i - 1; ++j)
                {
                    if (comp.Compare(set[j], set[j + 1]) > 0)
                    {
                        List<char> temp = set[j];
                        set[j] = set[j + 1];
                        set[j + 1] = temp;
                    }

                }
            }
        }

        /// <summary>
        /// Converts sorted set to a string.
        /// </summary>
        /// <returns>Sorted set converted to string.</returns>
        public override string ToString()
        {
            string output = "";
            for (int i = 0; i < set.Count; ++i)
            {
                for (int j = 0; j < set[i].Count; ++j)
                {
                    output += (set[i])[j];
                }
                output += " ";
            }
            return output;
        }
    }
}
