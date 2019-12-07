using System;

namespace exercise_8
{
    class Program
    {
        static void Main(string[] args)
        {
           Invoice invoice = new Invoice(1,"costumer", "provider");
           invoice.products.Add(new Product("water", 10, 3));
           invoice.products.Add(new Product("rom", 350, 1));
           invoice.products.Add(new Product("milk", 22, 5));
           Console.WriteLine($"Сумма заказа с НДС {invoice.GetSumWithNDS()} и без НДС {invoice.GetSumWithoutNDS()}");

        }
    }
}
