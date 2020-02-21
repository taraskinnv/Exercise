using System;

namespace Exercise_7
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList list = new ArrayList();

            list.Add(1);
            list.Add("qwe");
            list.Add(new {name = "Nick", day  = 28});

            Console.WriteLine(list[0]);
            Console.WriteLine(list[1]);
            Console.WriteLine(list[2]);

        }
    }
}
