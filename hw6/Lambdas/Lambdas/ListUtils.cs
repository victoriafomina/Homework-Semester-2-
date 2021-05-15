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
        public static List<T1> Map<T, T1>(List<T> list, Func<T, T1> modification)
        {
            var newList = new List<T1>();

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
        public static T1 Fold<T, T1>(List<T> list, T1 accumulatedValue, Func<T1, T, T1> counterOfAccumulateValue)
        {
            T1 currentAccumulatedValue = accumulatedValue;

            foreach (var element in list)
            {
                currentAccumulatedValue = counterOfAccumulateValue(currentAccumulatedValue, element);
            }

            return currentAccumulatedValue;
        }
    }
}
