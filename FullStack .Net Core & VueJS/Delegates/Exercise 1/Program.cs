using System;

namespace Exercise_1
{
    /*
     * Задание 1
       Создайте анонимный метод, который принимает в качестве параметров три целочисленных аргумента и
       возвращает среднее арифметическое этих аргументов.
     */
    class Program
    {
        delegate Double AverageHandler(Int32 one, Int32 two, Int32 three);
        static void Main(string[] args)
        {
            AverageHandler averageHandler = delegate(int one, int two, int three)
            {
                return (Double)(one + two + three) / 3;
            };

            try
            {
                Console.WriteLine(averageHandler.Invoke(1, 2, 3));
                Console.WriteLine(averageHandler.Invoke(2, 3, 3));
                Console.WriteLine(averageHandler.Invoke(0, 0, 0));

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
