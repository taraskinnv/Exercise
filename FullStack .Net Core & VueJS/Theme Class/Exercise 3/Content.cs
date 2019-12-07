using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_3
{
    class Content
    {
        public String content;

        public void Show()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"content = {content}");
            Console.ForegroundColor = default;
        }
    }
}
