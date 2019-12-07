using System;

namespace Exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Printer printer = new PrinterRed();
            printer.Print("qwerty");
            PrinterRed printerRed = (PrinterRed) printer;
            printerRed.Print("qazwsx");
            Console.WriteLine();
            //--------------------------------------------------
            //или так

            Printer[] printers = new Printer[]
            {
                new Printer(),
                new PrinterBlue(),
                new PrinterRed()
            };

            foreach (Printer print in printers)
            {
                print.PrintVirtual("QWERTY");
            }

        }
    }
}
