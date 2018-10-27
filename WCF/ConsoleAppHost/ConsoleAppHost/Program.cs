using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppHost
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Хост";
            Uri address = new Uri("http://localhost:8733/ConsoleAppHost/IContract");
            BasicHttpBinding binding = new BasicHttpBinding();
            Type contract = typeof(IContract);
            ServiceHost host = new ServiceHost(typeof(Service));
            host.AddServiceEndpoint(contract, binding, address);
            host.Open();
            Console.WriteLine("Хост готов к приему");
            Console.ReadLine();
            host.Close();
            Console.WriteLine("Хост завершил работу");
            Console.ReadKey();
        }
    }
}
