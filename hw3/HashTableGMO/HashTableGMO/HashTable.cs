using System;

namespace HashTableGMO
{
    /// <summary>
    /// Implements interface of hash table.
    /// </summary>
    public class HashTable
    {
        private static int size;
        private static List<int>[] bucket;
        IHashing hashing;

        /// <summary>
        /// Initializes an object of the hash table class.
        /// </summary>
        public HashTable(IHashing hashing)
        {
            this.hashing = hashing;
            size = 100;
            bucket = new List<int>[size];
            for (int i = 0; i < 100; ++i)
            {
                bucket[i] = new List<int>();
            }
        }

        /// <summary>
        /// Adds a value to the hash table.
        /// </summary>
        /// <param name="value">Value to add.</param>
        public void AddValue(int value)
        {
            int hash = Math.Abs(hashing.HashFunction(value)) % size;
            bucket[hash].PushToPosition(0, value);
        }

        /// <summary>
        /// Deletes value from the hash table.
        /// </summary>
        /// <param name="value">Value to delete.</param>
        public void DeleteValue(int value)
        {
            int hash = Math.Abs(hashing.HashFunction(value)) % size;
            int position = bucket[hash].GetPositionByValue(value);
            if (position < 0)
            {
                throw new InvalidOperationException($"Argument with the value does " +
                        "not exist {value} value\n");
            }
            bucket[hash].PopFromPosition(position);
        }

        /// <summary>
        /// Checks if the element with the value exists.
        /// </summary>
        /// <param name="value">Value to check if exists in tab.</param>
        /// <returns></returns>
        public bool Exists(int value)
        {
            int hash = Math.Abs(hashing.HashFunction(value)) % size;
            return bucket[hash].Exists(value);
        }
    }
}
