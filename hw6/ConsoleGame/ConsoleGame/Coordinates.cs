using System;

namespace ConsoleGame
{
    /// <summary>
    /// Represents the class that lets keep coordinates in two-dimensional space.
    /// </summary>
    public class Coordinates
    {
        /// <summary>
        /// Initializes an object of the class coordinates.
        /// </summary>
        public Coordinates(int top, int left)
        {
            this.Top = top;
            this.Left = left;
        }

        /// <summary>
        /// Returns coordinate that changes when moving up/down happens.
        /// </summary>
        public int Top { get; set; }

        /// <summary>
        /// Returns coordinate that changes when moving left/right happens.
        /// </summary>
        public int Left { get; set; }
    }
}
