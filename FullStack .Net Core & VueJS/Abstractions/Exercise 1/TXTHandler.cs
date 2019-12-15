using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_1
{
    class TXTHandler : AbstractHandler
    {
        public override void Open()
        {
            Console.WriteLine("Open TXTHandler");
        }

        public override void Create()
        {
            Console.WriteLine("Create TXTHandler");

        }

        public override void Change()
        {
            Console.WriteLine("Change TXTHandler");
        }

        public override void Save()
        {
            Console.WriteLine("Save TXTHandler");
        }
    }
}
