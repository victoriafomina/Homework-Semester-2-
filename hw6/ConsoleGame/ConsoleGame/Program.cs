namespace ConsoleGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var eventLoop = new EventLoop();
            var smileyHandler = new SmileyHandler("map.txt");

            eventLoop.LeftPressed += smileyHandler.LeftMovement;
            eventLoop.RightPressed += smileyHandler.RightMovement;
            eventLoop.UpPressed += smileyHandler.UpMovement;
            eventLoop.DownPressed += smileyHandler.DownMovement;

            eventLoop.Run();
        }
    }
}
