using System;

namespace Exercise_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book();
            Console.Write("Title: ");
            book._title.title = Console.ReadLine();
            Console.Write("Author: ");
            book._author.author = Console.ReadLine();
            Console.Write("Content: ");
            book._content.content = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Book:");
            book._title.Show();
            book._author.Show();
            book._content.Show();
        }
    }
}
