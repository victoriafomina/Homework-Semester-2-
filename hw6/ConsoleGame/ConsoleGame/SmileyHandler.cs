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

    }
}
