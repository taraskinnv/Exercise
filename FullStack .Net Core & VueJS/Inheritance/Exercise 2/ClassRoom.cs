using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_2
{
    class ClassRoom
    {
        private readonly Pupil[] _pupils;
        public ClassRoom(Pupil pupil, Pupil pupil1 = null, Pupil pupil2 = null, Pupil pupil3 = null)
        {
            _pupils = new[] { pupil, pupil1, pupil2, pupil3 };
        }

        public void PrintPupil()
        {
            foreach (var pupil in _pupils)
            {
                if (pupil != null)
                {
                    pupil.Study();
                    pupil.Read();
                    pupil.Write();
                    pupil.Relax();
                    Console.WriteLine();
                }
            }
        }
    }
}
