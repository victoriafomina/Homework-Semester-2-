using System;

namespace ConsoleGame
{
    /// <summary>
    /// Handles Smiley's actions.
    /// </summary>
    public class SmileyHandler
    {
        private Map map;
        private Smiley smiley;
        
        /// <summary>
        /// Initializes an object of the SmileyHandler class.
        /// </summary>
        public SmileyHandler(string path)
        {
            map = new Map(path);
            smiley = new Smiley(map.StatringPosition.top, map.StatringPosition.left);

            Console.CursorVisible = false;
            Console.WriteLine("☻ likes to move it, move it!\n☻ likes to move it, move it!\n☻likes to move it!" +
                    "Use arrows to move Smiley!");

            map.Display();
            smiley.Display();
        }

        /// <summary>
        /// Handles the movement to the left.
        /// </summary>
        public void LeftMovement(object sender, EventArgs e)
        {
            if (map[smiley.TopPosition, smiley.LeftPosition - 1] == ' ')
            {
                map.Display(smiley.TopPosition, smiley.LeftPosition);
                smiley.Left();
                smiley.Display();
            }
        }

        /// <summary>
        /// Handles the movement to the right.
        /// </summary>
        public void RightMovement(object sender, EventArgs e)
        {
            if (map[smiley.TopPosition, smiley.LeftPosition - 1] == ' ')
            {
                map.Display(smiley.TopPosition, smiley.LeftPosition);
                smiley.Right();
                smiley.Display();
            }
        }

        /// <summary>
        /// Handles upward movement.
        /// </summary>
        public void UpMovement(object sender, EventArgs e)
        {
            if (map[smiley.TopPosition, smiley.LeftPosition - 1] == ' ')
            {
                map.Display(smiley.TopPosition, smiley.LeftPosition);
                smiley.Up();
                smiley.Display();
            }
        }

        /// <summary>
        /// Handles the downward movement.
        /// </summary>
        public void DownMovement(object sender, EventArgs e)
        {
            if (map[smiley.TopPosition, smiley.LeftPosition - 1] == ' ')
            {
                map.Display(smiley.TopPosition, smiley.LeftPosition);
                smiley.Down();
                smiley.Display();
            }
        }
    }
}
