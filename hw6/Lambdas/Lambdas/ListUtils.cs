using System;

namespace Lambdas
{
    /// <summary>
    /// Useful utilits for the list.
    /// </summary>
    public static class ListUtils
    {
        /// <summary>
        /// Creates a new list that is modified list-argument. 
        /// </summary>
        public static List<int> Map(List<int> list, Func<int, int> modification)
        {
            var newList = new List<int>();

            foreach (var element in list)
            {
                newList.Add(modification(element));
            }

            return newList;
        }
        
        /// <summary>
        /// Creates a new list that contains elements for which predicate returns true.
        /// </summary>
        public static List<int> Filter(List<int> list, Predicate<int> predicate)
        {
            var newList = new List<int>();

            foreach (var element in list)
            {
                if (predicate(element))
                {
                    newList.Add(element);
                }
            }

            return newList;
        }

        /// <summary>
        /// Calculates new accumulated value using the list and the input accumulated value.
        /// </summary>
        public static int Fold(List<int> list, int accumulatedValue, Func<int, int, int> counterOfAccumulateValue)
        {
            int currentAccumulatedValue = accumulatedValue;

            foreach (var element in list)
            {
                currentAccumulatedValue = counterOfAccumulateValue(currentAccumulatedValue, element);
            }

            return currentAccumulatedValue;
        }
    }
}
