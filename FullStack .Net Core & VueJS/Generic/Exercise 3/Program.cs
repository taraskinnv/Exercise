using System;
using System.Collections.Generic;
using System.Threading.Channels;

namespace Exercise_3
{
    class Program
    {
        static void Main(string[] args)
        {

            MyDictionary<string,string> dictionary = new MyDictionary<string, string>();

            Console.WriteLine(dictionary.Count);

            dictionary.Add("qwe","qaz");
            dictionary.Add("qwe1","qaz1");
            dictionary.Add("qwe3","qaz2");

            Console.WriteLine(dictionary["qwe1"]);
            dictionary["qwe1"] = "wsx";
            Console.WriteLine(dictionary["qwe1"]);
            Console.WriteLine(dictionary.Count);
        }
    }
}
