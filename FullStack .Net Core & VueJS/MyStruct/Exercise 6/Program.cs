using System;

namespace Exercise_6
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Accauntant.AskForBonus(Post.Worker, 150));
            Console.WriteLine(Accauntant.AskForBonus(Post.Worker, 200));
            Console.WriteLine();
            Console.WriteLine(Accauntant.AskForBonus(Post.Director, 50));
            Console.WriteLine(Accauntant.AskForBonus(Post.Director, 250));
        }
    }
}
