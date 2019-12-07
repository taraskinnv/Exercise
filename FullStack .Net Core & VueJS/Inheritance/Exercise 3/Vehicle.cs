using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_3
{
    public class Vehicle
    {
        private String name;
        private Double price;
        private Double speed;
        private DateTime year;
        private Double coordinateX;
        private Double coordinateY;

        public double Price
        {
            get { return price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }
                price = value;
            }
        }

        public double Speed
        {
            get { return speed; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }
                speed = value;
            }
        }

        public DateTime Year
        {
            get { return year; }
            private set
            {
                if (value > DateTime.Now)
                {
                    throw new ArgumentException();
                }
                year = value;
            }
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (value.Length < 0)
                {
                    throw new ArgumentException();
                }
                name = value;
            }
        }

        public double CoordinateX
        {
            get { return coordinateX; }
            set
            {
                coordinateX = value;
            }
        }

        public double CoordinateY
        {
            get { return coordinateY; }
            set
            {

                coordinateY = value;
            }
        }
        public Vehicle(String name, Double price, Double speed, DateTime year, Double coordinateX, Double coordinateY)
        {
            Name = name;
            Price = price;
            Speed = speed;
            Year = year;
            CoordinateX = coordinateX;
            CoordinateY = coordinateY;
        }

        public virtual void Print()
        {
            Console.WriteLine($"{GetType().Name} \nName {Name} \nPrice {Price}$ \nSpeed {Speed}hm/h \nYear {Year.Year} \ncoordinates({CoordinateX}, {CoordinateY})");
        }
    }
}
