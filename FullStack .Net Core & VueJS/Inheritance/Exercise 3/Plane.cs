using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_3
{
    class Plane : Vehicle
    {
        private Double height;
        private Int32 amountPassengers;

        public double Height
        {
            get { return height; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }
                height = value;
            }
        }

        public int AmountPassengers
        {
            get { return amountPassengers; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }
                amountPassengers = value;
            }
        }




        public Plane(String name, double price, double speed, DateTime year, Double coordinateX, Double coordinateY, Double height, Int32 amountPassengers) : base(name, price, speed, year, coordinateX, coordinateY)
        {
            Height = height;
            AmountPassengers = amountPassengers;
        }

        public override void Print()
        {
            Console.WriteLine($"{GetType().Name} \nName {Name} \nPrice {Price}$ \nSpeed {Speed}km/h \nYear {Year.Year} \ncoordinates({CoordinateX}, {CoordinateY}) \nHeight {Height}m \nAmountPassengers {AmountPassengers} people");
        }
    }
}
