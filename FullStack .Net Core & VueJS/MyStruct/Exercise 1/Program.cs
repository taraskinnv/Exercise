using System;

namespace Exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Notebook notebook = new Notebook("iPhone 11 Pro - 64GB", "Apple", 1259.99);
            notebook.Show();
        }
    }

    struct Notebook
    {
        private String model;
        private String manufacturer;
        private Double price;

        public Notebook(String model, String manufacturer, Double price)
        {
            this.model = model;
            this.manufacturer = manufacturer;
            this.price = price;
        }

        public void Show()
        {
            Console.WriteLine($"Manufacturer: {this.manufacturer}, Model: {this.model}, Price: {this.price}$;");
        }
    }
}
