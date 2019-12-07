using System;

namespace exercise_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Converter converter = new Converter(23.8770, 23.8770, 0.37417);
            string number;
            Double summa;
            do
            {
                
            
            Console.WriteLine("1 - Перевести из USD в UAH");
            Console.WriteLine("2 - Перевести из EUR в UAH");
            Console.WriteLine("3 - Перевести из RUB в UAH");
            Console.WriteLine("4 - Перевести из UAH в USD");
            Console.WriteLine("5 - Перевести из UAH в EUR");
            Console.WriteLine("6 - Перевести из UAH в RUB");

            Console.WriteLine();
            Console.Write("Введите значение для конвертации: ");
            number = Console.ReadLine();
            
                switch (number)
                {
                    case "1":

                        Console.Write("Введите конвертируемую сумму: ");
                        summa = Double.Parse(Console.ReadLine());
                        Console.WriteLine($"Вы получите {converter.ConvertUsdUah(summa)} uah");
                        break;
                    case "2":

                        Console.Write("Введите конвертируемую сумму: ");
                        summa = Double.Parse(Console.ReadLine());
                        Console.WriteLine($"Вы получите {converter.ConvertEurUah(summa)} uah");
                        break;
                    case "3":

                        Console.Write("Введите конвертируемую сумму: ");
                        summa = Double.Parse(Console.ReadLine());
                        Console.WriteLine($"Вы получите {converter.ConvertRubUah(summa)} uah");
                        break;
                    case "4":

                        Console.Write("Введите конвертируемую сумму: ");
                        summa = Double.Parse(Console.ReadLine());
                        Console.WriteLine($"Вы получите {converter.ConvertUanUsd(summa)} usd");
                        break;
                    case "5":

                        Console.Write("Введите конвертируемую сумму: ");
                        summa = Double.Parse(Console.ReadLine());
                        Console.WriteLine($"Вы получите {converter.ConvertUahEur(summa)} eur");
                        break;
                    case "6":

                        Console.Write("Введите конвертируемую сумму: ");
                        summa = Double.Parse(Console.ReadLine());
                        Console.WriteLine($"Вы получите {converter.ConvertUahRub(summa)} rub");
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            } while (true);
        }
    }
}
