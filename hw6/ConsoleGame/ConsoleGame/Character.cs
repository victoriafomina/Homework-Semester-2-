using System;

namespace ConsoleGame
{
    /// <summary>
    /// Represents a smiley that moves on the map.
    /// </summary>
    public class Smiley
    {
        /// <summary>
        /// Initializes an object of the class Smiley.
        /// </summary>
        public Smiley(int startingTop, int staringLeft)
        {
            TopPosition = startingTop;
            LeftPosition = staringLeft;
        }

        /// <summary>
        /// Returns top position.
        /// </summary>
        public int TopPosition { get; private set; }

        /// <summary>
        /// Returns left position.
        /// </summary>
        public int LeftPosition { get; private set; }


    }
}
