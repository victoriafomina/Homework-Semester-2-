namespace HashTableGMO
{
    public class Hashing : IHashing
    {
        public int HashFunction(int value)
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
