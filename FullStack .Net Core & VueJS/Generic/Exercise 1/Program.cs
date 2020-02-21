using System;

namespace Exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {
            MyClass<Test>.FactoryMethod();
            Console.WriteLine();
            MyClass<Test>.FactoryMethod();
        }
    }

    class Test
    {
        public Test()
        {
            Console.WriteLine("Constructor Test");
        }
    }
}
