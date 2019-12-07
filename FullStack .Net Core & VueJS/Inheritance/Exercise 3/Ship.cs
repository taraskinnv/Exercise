using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_3
{
    class Ship : Vehicle
    {
        private Int32 amountPassengers;
        private String portRegistry;
        public Ship(string name, double price, double speed, DateTime year, double coordinateX, double coordinateY, Int32 amountPassengers, String portRegistry) : base(name, price, speed, year, coordinateX, coordinateY)
        {
            AmountPassengers = amountPassengers;
            PortRegistry = portRegistry;
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

        public string PortRegistry
        {
            get { return portRegistry; }
            private set
            {
                if (value.Length <= 0)
                {
                    throw new ArgumentException();
                }
                portRegistry = value;
            }
        }
        public override void Print()
        {
            Console.WriteLine($"{GetType().Name} \nName {Name} \nPrice {Price}$ \nSpeed {Speed}km/h \nYear {Year.Year} \ncoordinates({CoordinateX}, {CoordinateY}) \nAmountPassengers {AmountPassengers} people \nPortRegistry {PortRegistry}");
        }
    }
}
