using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_4
{
    class Figure
    {
        Point[] masPoints;
        public Figure(Point A, Point B, Point C)
        {
            masPoints = new Point[3];
            masPoints[0] = A;
            masPoints[1] = B;
            masPoints[2] = C;
        }

        public Figure(Point A, Point B, Point C, Point D)
        {
            masPoints = new Point[4];
            masPoints[0] = A;
            masPoints[1] = B;
            masPoints[2] = C;
            masPoints[3] = D;
        }

        public Figure(Point A, Point B, Point C, Point D, Point E)
        {
            masPoints = new Point[5];
            masPoints[0] = A;
            masPoints[1] = B;
            masPoints[2] = C;
            masPoints[3] = D;
            masPoints[4] = E;
        }

        private double LengthSide(Point A, Point B)
        {
            return Math.Sqrt(Math.Pow(B.X - A.X, 2) + Math.Pow(B.Y - A.Y, 2));
        }

        public void PerimeterCalculator()
        {
            double result = 0;
            for (int i = 0; i < masPoints.Length; i++)
            {
                if (i == 0 )
                {
                    result += LengthSide(masPoints[0], masPoints[masPoints.Length - 1]);
                }
                else
                {
                    result += LengthSide(masPoints[i - 1], masPoints[i]);
                }

            }

            Console.WriteLine($"Perimeter = {result}");
        }

    }
}
