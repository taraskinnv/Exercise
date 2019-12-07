using System;

namespace Exercise_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Vehicle[] vehicles = new Vehicle[]
            {
                new Plane("Boing 747", 100000, 800, new DateTime(2000, 1, 1), 10.5, 111.7, 5000, 300),
                new Ship("Titanic", 180000, 50, new DateTime(1912, 1, 1), 1280.46589, 125877.354, 2000, "Baltimor USA"),
                new Car("BMW", 5000, 240, new DateTime(2010, 1, 1), 25623.5435, 5452545.5656, Car.Type.sedan)

            };
            foreach (var vehicle in vehicles)
            {
                vehicle.Print();
                Console.WriteLine();
            }
        }
    }
}
