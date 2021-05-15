using System;

namespace ConsoleGame
{
    /// <summary>
    /// Reacts on user's actions.
    /// </summary>
    public class EventLoop
    {
        public event EventHandler<EventArgs> LeftPressed;
        public event EventHandler<EventArgs> RightPressed;
        public event EventHandler<EventArgs> UpPressed;
        public event EventHandler<EventArgs> DownPressed;

        /// <summary>
        /// Waits for user's actions.
        /// </summary>
        public void Run()
        {
            while (true)
            {
                var keyPressed = Console.ReadKey(true);

                switch (keyPressed.Key)
                {
                    case ConsoleKey.LeftArrow:
                        LeftPressed?.Invoke(this, EventArgs.Empty);
                        break;
                    case ConsoleKey.RightArrow:
                        RightPressed?.Invoke(this, EventArgs.Empty);
                        break;
                    case ConsoleKey.UpArrow:
                        UpPressed?.Invoke(this, EventArgs.Empty);
                        break;
                    case ConsoleKey.DownArrow:
                        DownPressed?.Invoke(this, EventArgs.Empty);
                        break;
                }
            }
        }
    }
}
