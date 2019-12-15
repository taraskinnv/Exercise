using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_1
{
    class DOCHandler : AbstractHandler
    {
        public override void Open()
        {
            Console.WriteLine("Open DOCHandler");
        }

        public override void Create()
        {
            Console.WriteLine("Create DOCHandler");
        }

        public override void Change()
        {
            Console.WriteLine("Change DOCHandler");
        }

        public override void Save()
        {
            Console.WriteLine("Save DOCHandler");
        }
    }
}
