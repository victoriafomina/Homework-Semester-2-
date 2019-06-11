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

        /// <summary>
        /// Moves the Smiley by one position left.
        /// </summary>
        public void Left() => --LeftPosition;

        /// <summary>
        /// Moves the Smiley by one position right.
        /// </summary>
        public void Right() => ++LeftPosition;

        /// <summary>
        /// Moves the Smiley by one position up.
        /// </summary>
        public void Up() => --TopPosition;

        /// <summary>
        /// Moves the Smiley by one position down.
        /// </summary>
        public void Down() => ++TopPosition;


    }
}
