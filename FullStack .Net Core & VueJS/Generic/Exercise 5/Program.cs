using System;
using System.Collections;
using System.Collections.Generic;

namespace Exercise_5
{
    class Program
    {
        static void Main(string[] args)
        {
            CarCollection<Car> collection = new CarCollection<Car>();
            collection.Add("Audi", 2015);
            collection.Add("BMW", 2020);
            collection.Add("VW", 1998);
            collection.Add("Lada", 1980);

            Car car = collection[0];
            Console.WriteLine($"car name = {car.NameCar} age = {car.AgeCar}");
            Console.WriteLine($"Count = {collection.Count}");

        }
    }
}
