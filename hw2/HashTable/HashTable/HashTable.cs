using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Написать хеш-таблицу в виде класса с использованием класса-списка из первой задачи.
//Должно быть можно добавлять значение в хеш-таблицу, удалять и проверять на принадлежность

namespace HashTable
{
    public class HashTable
    {
        private static int size = 100;
        private static List<int>[] bucket = new List<int>[size];
                
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
                bucket[hash].PushToPosition(size, value);
            }
        }

        /// <summary>
        /// Deletes value from the hash table.
        /// </summary>
        /// <param name="value"></param>
        public void DeleteValue(int value)
        {

        }

        /// <summary>
        /// Checks if the element with the value exists.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Exists(int value)
        {
            int hash = Math.Abs(HashFunction(value)) % size;
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
