using System;

namespace Exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("10+2*(3/2)");
            string res = Calculator.MyExpression("10+2*(3/2)");
            Console.WriteLine(res);

        }
        
    }

    
}
