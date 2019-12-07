using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_1
{
    class Printer
    {
        public void Print(string value)
        {
            Console.WriteLine($"{value}");
        }

        public virtual void PrintVirtual(string value)
        {
            Console.WriteLine($"{value}");
        }
    }
}
