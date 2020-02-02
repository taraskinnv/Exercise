using System;

namespace Exercise_2
{
    /*
     * Задание 2
       Создайте четыре лямбда оператора для выполнения арифметических действий: (Add – сложение, Sub –
       вычитание, Mul – умножение, Div – деление). Каждый лямбда оператор должен принимать два аргумента и
       возвращать результат вычисления. Лямбда оператор деления должен делать проверку деления на ноль.
       Написать программу, которая будет выполнять арифметические действия указанные пользователем.
     */

    delegate Double MyDelegate(Double x, Double y);

    class Program
    {

        static void Main(string[] args)
        {
            MyDelegate Add = (x, y) => x + y;
            MyDelegate Sub = (x, y) => x - y;
            MyDelegate Mul = (x, y) => x * y;
            MyDelegate Div = (x, y) =>
            {
                if (y == 0)
                {
                    throw new DivideByZeroException("Делить на 0 НЕЛЬЗЯ!!!");
                }

                return x / y;
            };



            Console.Write("Введите значение X =");
            Double x = Double.Parse(Console.ReadLine());
            Console.Write("Введите знак операции +-*/ = ");
            String op = Console.ReadLine();
            Console.Write("Введите значение Y = ");
            Double y = Double.Parse(Console.ReadLine());

            switch (op)
            {
                case "+":
                    Console.WriteLine($"{x} + {y} = {Add.Invoke(x, y)}");
                    break;
                case "-":
                    Console.WriteLine($"{x} - {y} = {Sub.Invoke(x, y)}");
                    break;
                case "*":
                    Console.WriteLine($"{x} * {y} = {Mul.Invoke(x, y)}");
                    break;
                case "/":
                    try
                    {
                        Console.WriteLine($"{x} / {y} = {Div.Invoke(x, y)}");
                    }
                    catch (DivideByZeroException e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    break;
            }
        }
    }
}
