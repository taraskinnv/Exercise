using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_2
{
    class Player : IPlayable, IRecodable
    {
        public void Play()
        {
            Console.WriteLine("Play music");
        }

        public void Record()
        {
            Console.WriteLine("Record music");

        }

        void IRecodable.Pause()
        {
            Console.WriteLine("Pause record music");
        }

        void IRecodable.Stop()
        {
            Console.WriteLine("Stop record music");

        }

        void IPlayable.Pause()
        {
            Console.WriteLine("Pause play music");
        }

        void IPlayable.Stop()
        {
            Console.WriteLine("Stop play music");
        }
    }
}
