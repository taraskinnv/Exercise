using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_2
{
    class ExcellentPupil : Pupil
    {
        public ExcellentPupil(string name) : base(name)
        {

        }

        public override void Study()
        {
            Console.WriteLine($"Pupil {Name} study excellent");
        }

        public override void Read()
        {
            Console.WriteLine($"Pupil {Name} read excellent");
        }

        public override void Write()
        {
            Console.WriteLine($"Pupil {Name} write excellent");
        }

        public override void Relax()
        {
            Console.WriteLine($"Pupil {Name} relax excellent");
        }
    }
}
