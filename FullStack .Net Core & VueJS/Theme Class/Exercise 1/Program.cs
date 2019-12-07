using System;

namespace Exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Address address = new Address();
            address.Index = 49044;
            address.Country = "Ukraine";
            address.City = "Dnipro";
            address.Street = "Shevchenko";
            address.House = 14;
            address.Apartment = 1;

            Console.WriteLine($"Address: Index {address.Index}, Country {address.Country}, City {address.City},Street {address.Street},House {address.House},Apartment {address.Apartment}.");
        }
    }
}
