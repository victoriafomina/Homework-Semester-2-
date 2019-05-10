using System;
using System.Collections.Generic;
using System.Text;

namespace FinalTest
{
    /// <summary>
    /// Compares object of the list class.
    /// </summary>
    public class ListComparer : IComparer<List<char>>
    { 
        /// <summary>
        /// Compares two object of the list class.
        /// </summary>
        /// <returns>Positive number - the first operand is greated. Negative number - the second is greater. Null - they are equal. </returns>
        public int Compare(List<char> list1, List<char> list2)
        {
            if (list1.Count > list2.Count)
            {
                return 1;
            }
            else if (list1.Count < list2.Count)
            {
                return -1;
            }
            return 0;
        }
    }
}
