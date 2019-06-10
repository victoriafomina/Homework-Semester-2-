using System;

namespace UniqueList
{
    /// <summary>
    /// UniqueList is a linear container of data elemenents.
    /// UniqueList does not contain duplicate elements.
    /// </summary>
    public class UniqueList : List<int>
    {
        private List<int> list;

        /// <summary>
        /// Creates an object of the UniqueList class.
        /// </summary>
        public UniqueList()
        {
            list = new List<int>();
        }

        /// <summary>
        /// Pushes an element into position.
        /// </summary>
        /// <param name="position">Index by which element is going to be add.</param>
        /// <param name="data">Element to add.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when position is invalid.</exception>
        public override void PushToPosition(int position, int data)
        {
            if (Exists(data))
            {
                throw new DuplicateElementException($"Element with the data {data} is already in the list\n");
            }
            base.PushToPosition(position, data);
        }

        public override void Pop(int data)
        {
            if (!Exists(data))
            {
                throw new ElementDoesNotExistException($"Element with the data {data} does not exist " +
                        $"in the list\n");
            }
            base.Pop(data);
        }
    }
}
