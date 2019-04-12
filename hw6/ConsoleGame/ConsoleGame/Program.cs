using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// На базе класса, генерирующего события по нажатию на клавиши управления курсором 
// (EventLoop с пары), реализовать консольное приложение, позволяющее управлять 
// персонажем, перемещающимся по карте. Карта состоит из свободного пространства и 
// стен, и должна грузиться из файла. Приложение должно отображать карту и персонажа 
// (символом @) в окне консоли, и позволять персонажу перемещаться по карте, 
// реагируя на клавиши управления курсором. Будут полезны свойства Console.CursorLeft 
// и Console.CursorTop.

namespace ConsoleGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello");
            Console.Clear();
            int x = Console.CursorLeft;
            int y = Console.CursorTop;
        }
    }
}
