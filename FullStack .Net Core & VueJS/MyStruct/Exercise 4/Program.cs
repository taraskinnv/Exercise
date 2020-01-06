using System;

namespace Exercise_4
{

    /*Задание 4
Реализуйте программу, которая будет принимать от пользователя дату его рождения и выводить количество
дней до его следующего дня рождения.*/
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите день вашего рождения(число):");
            Int32 day = Int32.Parse(Console.ReadLine());
            Console.Write("Введите месяц вашего рождения(число):");
            Int32 mounth = Int32.Parse(Console.ReadLine());
            DateTime nowDateTime = DateTime.Now;
            DateTime birthday = new DateTime(nowDateTime.Year, mounth, day);
            if (nowDateTime > birthday)
            {
                birthday = new DateTime(nowDateTime.Year + 1, mounth, day);
            }

            TimeSpan interval = birthday - nowDateTime;
            Console.WriteLine($"До вашего дня рождения {interval.Days}");
        }
    }
}
