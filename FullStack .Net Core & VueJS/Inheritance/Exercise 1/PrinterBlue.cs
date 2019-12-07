using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_1
{
    class PrinterBlue : Printer
    {
        public new void Print(string value)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{value}");
            Console.ResetColor();
        }

        public override void PrintVirtual(string value)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{value}");
            Console.ResetColor();
        }
    }
}
