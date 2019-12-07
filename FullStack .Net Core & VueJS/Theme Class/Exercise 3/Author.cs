using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_3
{
    class Author
    {
        public String author;

        public void Show()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"author = {author}");
            Console.ForegroundColor = default;

        }
    }
}
