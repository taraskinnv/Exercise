using System;

namespace Exercise_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Pupil pupil1 = new ExcellentPupil("Nick");
            Pupil pupil2 = new BadPupil("Dima");
            Pupil pupil3 = new GoodPupil("Sveta");
            Pupil pupil4 = new ExcellentPupil("Lena");
            ClassRoom classRoom = new ClassRoom(pupil1, pupil2);
            classRoom.PrintPupil();
        }
    }
}
