using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_RPG_Game
{
    class Utils
    {
        public static void print_coord(string text, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(text);
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
