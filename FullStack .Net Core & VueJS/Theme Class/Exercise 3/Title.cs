using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_3
{
    class Title
    {
        public String title;

        public void Show()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"title = {title} ");
            Console.ForegroundColor = default;

        }



    }
}
