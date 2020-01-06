using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_6
{
    public enum Post
    {
        Worker = 160,
        Director = 240,
        Engineer = 220
    }
    public static class Accauntant
    {
        public static Boolean AskForBonus(Post worker, int hours)
        {
            if ((int)worker >= hours)
            {
                return true;
            }

            return false;
        }
    }
}
