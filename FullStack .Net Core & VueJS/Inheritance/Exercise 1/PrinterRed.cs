using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_1
{
    class PrinterRed : Printer
    {
        public new void Print(string value)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{value}");
            Console.ResetColor();
        }

        public override void PrintVirtual(string value)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{value}");
            Console.ResetColor();
        }
    }
}
