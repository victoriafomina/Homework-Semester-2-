using System;

namespace UniqueList
{
    /// <summary>
    /// UniqueList is a linear container of data elemenents.
    /// UniqueList does not contain duplicate elements.
    /// </summary>
    public class UniqueList : List<int>
    {
        /// <summary>
        /// Creates an object of the UniqueList class.
        /// </summary>
        public UniqueList() : base() { }

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

        /// <summary>
        /// Removes an element with the data "data".
        /// </summary>
        /// <param name="data">Data of the element to pop.</param>
        /// <exception cref="InvalidOperationException">Thrown when element does not found.</exception>S
        public override void Remove(int data)
        {
            if (!Exists(data))
            {
                throw new ElementDoesNotExistException($"Element with the data {data} does not exist " +
                        "in the list\n");
            }

            base.Remove(data);
        }
    }
}
