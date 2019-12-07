using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_2
{
    class Rectangle
    {
        private Double side1;
        private Double side2;

        public Double Area
        {
            get { return AreaCalculator(); }
        }

        public Double Perimeter
        {
            get
            {
                return PerimeterCalculator();
            }
        }




        public double Side1
        {
            get { return side1; }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Side1 <= 0");
                }
                side1 = value;
            }
        }

        public double Side2
        {
            get { return side2; }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Side2 <= 0");
                }
                side2 = value;
            }
        }

        public Rectangle(Double side1, Double side2)
        {
            Side1 = side1;
            Side2 = side2;
        }

        private double AreaCalculator()
        {
            return side1 * side2;
        }

        private double PerimeterCalculator()
        {
            return (side1 + side2) * 2;
        }

    }
}
