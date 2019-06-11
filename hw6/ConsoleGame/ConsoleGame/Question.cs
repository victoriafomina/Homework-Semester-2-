using System;

namespace ConsoleGame
{
    /// <summary>
    /// Represents a question that moves on the map.
    /// </summary>
    public class Question
    {
        /// <summary>
        /// Initializes an object of the class Question.
        /// </summary>
        public Question(int startingTop, int staringLeft)
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
        /// Moves the Question by one position left.
        /// </summary>
        public void Left() => --LeftPosition;

        /// <summary>
        /// Moves the Question by one position right.
        /// </summary>
        public void Right() => ++LeftPosition;

        /// <summary>
        /// Moves the Question by one position up.
        /// </summary>
        public void Up() => --TopPosition;

        /// <summary>
        /// Moves the Question by one position down.
        /// </summary>
        public void Down() => ++TopPosition;

        /// <summary>
        /// Displays the Question.
        /// </summary>
        public void Display()
        {
            var startingLeft = Console.CursorLeft;
            var startingTop = Console.CursorTop;

            Console.CursorLeft += LeftPosition;
            Console.CursorTop += TopPosition;

            Console.Write('?');

            Console.CursorLeft = startingLeft;
            Console.CursorTop = startingTop;
        }
    }
}
