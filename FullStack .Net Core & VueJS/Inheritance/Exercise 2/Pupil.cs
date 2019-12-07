using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_2
{
    class Pupil
    {
        private String name;
        public Pupil(String name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return name; }
        }

        public virtual void Study()
        {
            Console.WriteLine($"Pupil {Name} study");
        }

        public virtual void Read()
        {
            Console.WriteLine($"Pupil {Name} read");
        }

        public virtual void Write()
        {
            Console.WriteLine($"Pupil {Name} write");
        }

        public virtual void Relax()
        {
            Console.WriteLine($"Pupil {Name} relax");
        }
    }
}
