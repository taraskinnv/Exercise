using System;
using System.Linq.Expressions;

namespace Exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {
            AbstractHandler[] abstractHandler = new AbstractHandler[]
            {
                new XMLHandler(),
                new TXTHandler(),
                new DOCHandler()
            };

            for (int i = 0; i < abstractHandler.Length; i++)
            {
                abstractHandler[i].Create();
                abstractHandler[i].Open();
                abstractHandler[i].Change();
                abstractHandler[i].Save();
                Console.WriteLine();
            }
        }
    }
}
