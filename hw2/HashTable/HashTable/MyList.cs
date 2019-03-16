using System;

namespace HashTable
{
    class MyList : List<int>
    {
        public override bool Exists(int data)
        {
            if (IsEmpty())
            {
                return false;
            }
            var currentNode = head;

        }
    }
}
