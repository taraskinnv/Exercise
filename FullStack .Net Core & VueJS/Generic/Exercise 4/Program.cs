using Exercise_2;
using System;

namespace Exercise_4
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

            Int32[] arr = list.GetArray();
            foreach (var i in arr)
            {
                Console.WriteLine(i);
            }
        }
    }
}
