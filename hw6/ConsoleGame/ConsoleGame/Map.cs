using System.IO;
using System;

namespace ConsoleGame
{
    /// <summary>
    /// The class represents the map for the game.
    /// </summary>
    public class Map
    {      
        /// <summary>
        /// Initializes an object of the map.
        /// </summary>
        public Map(string path)
        {
            using (var mapOfTheGame = new StreamReader(path))
            {
                int width = 0;
                int height = 0;

                if (!int.TryParse(mapOfTheGame.ReadLine(), out width) || !int.TryParse(mapOfTheGame.ReadLine(), out height))
                {
                    throw new FormatException();
                }

                Width = width;
                Height = height;
                map = new char[height, width];

                FillTheMap(mapOfTheGame);

                if (!mapOfTheGame.EndOfStream)
                {
                    throw new FormatException();
                }
            }

            if (StartingPosition.left < 0 || StartingPosition.top < 0)
            {
                throw new FormatException();
            }
        }
        
        /// <summary>
        /// Fills the map.
        /// </summary>
        private void FillTheMap(StreamReader map)
        {
            for (var i = 0; i < Height; ++i)
            {
                for (var j = 0; j < Width; ++j)
                {
                    var currentCharacter = (char)map.Read();

                    while (currentCharacter == '\n' || currentCharacter == '\r')
                    {
                        currentCharacter = (char)map.Read();
                    }

                    if (currentCharacter == '?')
                    {
                        StartingPosition = (i, j);
                        this.map[i, j] = ' ';
                    }
                    else
                    {
                        this.map[i, j] = currentCharacter;
                    }
                }
            }
        }

        /// <summary>
        /// Position at which the character starts moving.
        /// </summary>
        public (int top, int left) StartingPosition { get; private set; } = (-1, -1);

        /// <summary>
        /// The property that returns the height of the map.
        /// </summary>
        public int Height { get; }

        /// <summary>
        /// The property that returns the width of the map.
        /// </summary>
        public int Width { get; }

        private char[,] map;

        /// <returns>"!" when coordinate is not valid, symbol that is</returns>
        public char this[int top, int left]
        {
            get
            {
                if (top < 0 || top >= Height || left < 0 || left >= Width)
                {
                    return '!';
                }

                return map[top, left];
            }
        }

        /// <summary>
        /// Displays the map.
        /// </summary>
        public void Display()
        {

            var startConsoleLeft = Console.CursorLeft;
            var startConsoleTop = Console.CursorTop;

            for (var i = 0; i < Height; ++i)
            {
                for (var j = 0; j < Width; ++j)
                {
                    Console.Write(map[i, j]);
                }

                Console.WriteLine();
            }

            Console.CursorLeft = startConsoleLeft;
            Console.CursorTop = startConsoleTop;
        }

        /// <summary>
        /// Displays one square of the map.
        /// </summary>
        public void Display(int top, int left)
        {
            var startingLeft = Console.CursorLeft;
            var startingTop = Console.CursorTop;

            Console.CursorLeft += left;
            Console.CursorTop += top;

            Console.Write(map[top, left]);

            Console.CursorLeft = startingLeft;
            Console.CursorTop = startingTop;
        }
    }
}