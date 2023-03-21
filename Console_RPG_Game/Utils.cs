using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_RPG_Game
{
    enum Color
    {
        White,
        Red,
        Blue,
        Yellow,
        Green,
        Pink,
        Grey,
        Black
    }
    
    class Utils
    {
        public static void print_coord(string text, int x, int y, Color color = Color.White)
        {
            switch (color)
            {
                case Color.White:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case Color.Red:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case Color.Blue:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case Color.Yellow:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case Color.Green:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case Color.Pink:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                case Color.Black:
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                case Color.Grey:
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;

            }
            Console.SetCursorPosition(x, y);
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void print(string textToEnter)
        {
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (textToEnter.Length / 2)) + "}", textToEnter));
        }

        public static char GetInput()
        {
            var key = Console.ReadKey();
            char kchar = key.KeyChar;
            
            while (!Char.IsNumber(kchar))
            {
                Console.WriteLine(" Wrong input.\n Choose option: ");
                key = Console.ReadKey();
                kchar = key.KeyChar;
            }
            //int num = Convert.ToInt32(kchar);
            //while (num < 0 || num > options)
            //{
            //    Console.WriteLine(" Wrong input.\n Choose option: ");
            //    num = Convert.ToInt32(Console.ReadLine());
            //}
            return kchar;
        }
        
    }
}
