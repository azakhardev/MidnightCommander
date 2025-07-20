using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidnightCommander
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Console.WindowHeight = 26;
            Console.WindowWidth = 151;
            Application app = new Application();

            while (true)
            {
                Console.SetCursorPosition(0, 0);
                app.Draw();

                ConsoleKeyInfo key = Console.ReadKey();
                app.HandleKey(key);
            }
        }
    }
}
