using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_3
{
    class Car : Vehicle
    {
        private Enum myEnum;
        public enum Type
        {
            sedan,
            combo,
            universal
        }

        public Car(string name, double price, double speed, DateTime year, double coordinateX, double coordinateY, Type type) : base(name, price, speed, year, coordinateX, coordinateY)
        {
            myEnum = type;
        }

        public override void Print()
        {
            Console.WriteLine($"{GetType().Name} \nName {Name} \nPrice {Price}$ \nSpeed {Speed}hm/h \nYear {Year.Year} \ncoordinates({CoordinateX}, {CoordinateY}) \nType {myEnum}");
        }
    }
}
