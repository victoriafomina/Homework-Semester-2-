using System;

namespace HashTable
{
    public class HashTable
    {
        private static int size;
        private static List<int>[] bucket;
        public HashTable()
        {
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
        /// <param name="value"></param>
        public void AddValue(int value)
        {
            int hash = Math.Abs(HashFunction(value)) % size;           
            if (bucket[hash].IsEmpty())
            {
                bucket[hash].PushToPosition(0, value);
            }
            else
            {
                bucket[hash].PushToPosition(bucket[hash].Size, value);
            }
        }

        /// <summary>
        /// Deletes value from the hash table.
        /// </summary>
        /// <param name="value"></param>
        public void DeleteValue(int value)
        {
            int hash = Math.Abs(HashFunction(value)) % size;
            int position = bucket[hash].GetPositionByValue(value);
            if (position < 0)
            {
                throw new InvalidOperationException(string.Format("Argument with the value does " +
                        "not exist ", value, " value\n"));
            }
            bucket[hash].PopFromPosition(position);
        }

        /// <summary>
        /// Checks if the element with the value exists.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Exists(int value)
        {
            int hash = Math.Abs(HashFunction(value)) % size;
            return bucket[hash].Exists(value);
        }

        private int HashFunction(int value)
        {
            int key = value;
            key += ~(key << 16);
            key ^= (key >> 5);
            key += (key << 3);
            key ^= (key >> 13);
            key += ~(key << 9);
            key ^= (key >> 17);
            return key;
        }
    }
}
