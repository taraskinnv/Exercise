using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_1
{
    class XMLHandler:AbstractHandler
    {
        public override void Open()
        {
            Console.WriteLine("Open XMLHandler");
        }

        public override void Create()
        {
            Console.WriteLine("Create XMLHandler");
        }

        public override void Change()
        {
            Console.WriteLine("Change XMLHandler");
        }

        public override void Save()
        {
            Console.WriteLine("Save XMLHandler");
        }
    }
}
