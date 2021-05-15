using System;

namespace HashTableGMO
{
    /// <summary>
    /// Implements interface of hash table.
    /// </summary>
    public class HashTable
    {
        private List<int>[] bucket;
        private IHashing hashing;
        private int count;

        private double LoadFactor => count / bucket.Length;

        private void ReSize()
        {
            var newBucket = new List<int>[2 * bucket.Length];
            foreach (var list in bucket)
            {
                for (int i = 0; i < list.Size; ++i)
                {
                    int hash = Math.Abs(hashing.HashFunction(i)) % newBucket.Length;
                    newBucket[hash].PushToPosition(0, hash);
                }
            }
            bucket = newBucket;
        }

        /// <summary>
        /// Initializes an object of the hash table class.
        /// </summary>
        public HashTable(IHashing hashing)
        {
            this.hashing = hashing;
            count = 0;
            bucket = new List<int>[100];
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
            if (LoadFactor >= 1)
            {
                ReSize();
            }

            int hash = Math.Abs(hashing.HashFunction(value)) % bucket.Length;
            bucket[hash].PushToPosition(0, value);
            ++count;
        }

        /// <summary>
        /// Deletes value from the hash table.
        /// </summary>
        /// <param name="value">Value to delete.</param>
        public void DeleteValue(int value)
        {
            int hash = Math.Abs(hashing.HashFunction(value)) % bucket.Length;
            int position = bucket[hash].GetPositionByValue(value);
            if (position < 0)
            {
                throw new InvalidOperationException($"Argument with the value {value} does " +
                        "not exist\n");
            }
            bucket[hash].PopFromPosition(position);
            --count;
        }

        /// <summary>
        /// Checks if the element with the value exists.
        /// </summary>
        /// <param name="value">Value to check if exists in tab.</param>
        public bool Exists(int value)
        {
            int hash = Math.Abs(hashing.HashFunction(value)) % bucket.Length;
            return bucket[hash].Exists(value);
        }
    }
}
