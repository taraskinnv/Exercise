using System;

namespace Exercise_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("side1 = ");
            double side1 = Double.Parse(Console.ReadLine());
            Console.Write("side2 = ");
            double side2 = Double.Parse(Console.ReadLine());

            Rectangle rectangle = new Rectangle(side1, side2);

            Console.WriteLine($"Area = {rectangle.Area}, Perimeter = {rectangle.Perimeter}");


        }
    }
}
