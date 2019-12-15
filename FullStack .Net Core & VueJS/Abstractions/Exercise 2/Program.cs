using System;

namespace Exercise_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            player.Play();
            player.Record();
            ((IPlayable)player).Pause();
            ((IRecodable)player).Pause();
            ((IPlayable)player).Stop();
            ((IRecodable)player).Stop();

        }
    }
}
