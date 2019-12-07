using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_2
{
    class GoodPupil : Pupil
    {
        public GoodPupil(string name) : base(name)
        {
        }

        public override void Study()
        {
            Console.WriteLine($"Pupil {Name} study good");
        }

        public override void Read()
        {
            Console.WriteLine($"Pupil {Name} read good");
        }

        public override void Write()
        {
            Console.WriteLine($"Pupil {Name} write good");
        }

        public override void Relax()
        {
            Console.WriteLine($"Pupil {Name} relax good");
        }
    }
}
