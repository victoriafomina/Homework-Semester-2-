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
        /// Pushes an element into position.
        /// </summary>
        /// <param name="position">Index by which element is going to be add.</param>
        /// <param name="data">Element to add.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when position is invalid.</exception>
        /// <exception cref="DuplicateElementException">Thrown when someone tries to add element that is already 
        /// in the list.</exception>
        public override void PushToPosition(int position, int data)
        {
            if (Exists(data))
            {
                throw new DuplicateElementException($"Element with the data {data} is already in the list\n");
            }

            base.PushToPosition(position, data);
        }

        /// <summary>
        /// Changes the value by position.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when position is invalid.</exception>
        /// <exception cref="DuplicateElementException">Thrown when element with the value does exist.</exception>
        public override void ChangeByPosition(int position, int data)
        {
            if (GetValueByPosition(position) != data)
            {
                if (!Exists(data))
                {
                    base.ChangeByPosition(position, data);
                }
                else
                {
                    throw new DuplicateElementException("The element with the current data is already in the list!\n");
                }
            }
        }
    }
}
