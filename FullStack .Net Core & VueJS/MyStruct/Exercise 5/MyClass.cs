using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_5
{
    public static class MyClass
    {
        public static void Print(string stroka, int color)
        {
            if (color == (int)Color.Red)
            {
                Console.ForegroundColor = ConsoleColor.Red;

            }
            else if (color == (int)Color.Blue)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            else if(color == (int)Color.Green)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            Console.WriteLine(stroka);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
