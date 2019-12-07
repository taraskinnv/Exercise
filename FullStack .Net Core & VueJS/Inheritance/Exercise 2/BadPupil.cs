using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_2
{
    class BadPupil : Pupil
    {
        public BadPupil(string name) : base(name)
        {
        }

        public override void Study()
        {
            Console.WriteLine($"Pupil {Name} study bad");
        }

        public override void Read()
        {
            Console.WriteLine($"Pupil {Name} read bad");
        }

        public override void Write()
        {
            Console.WriteLine($"Pupil {Name} write bad");
        }

        public override void Relax()
        {
            Console.WriteLine($"Pupil {Name} relax bad");
        }
    }
}
