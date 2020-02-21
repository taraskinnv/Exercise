using System;

namespace Exercise_2
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> list = new MyList<int>();
            Console.WriteLine($"Count = {list.Count}");
            list.Add(5);
            list.Add(10);
            list.Add(15);
            list.Add(-5);
            Console.WriteLine($"Count = {list.Count}");
            Console.WriteLine($"3 element = {list[2]}");
        }
    }
}
