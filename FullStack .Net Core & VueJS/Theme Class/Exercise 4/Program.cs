using System;

namespace Exercise_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Point p1 = new Point(1, 1, "triangle");
            Point p2 = new Point(2, 2, "triangle");
            Point p3 = new Point(3, 3, "triangle");
            Figure figure = new Figure(p1, p2, p3);

            Console.WriteLine($"Figure is {p1.MyStr}");
            figure.PerimeterCalculator();

        }
    }
}
