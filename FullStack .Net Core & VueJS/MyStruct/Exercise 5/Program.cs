using System;

namespace Exercise_5
{
    public enum Color
    {
        Red,
        Green,
        Blue
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выбирите цвет текста:");
            Console.WriteLine("0 - Red");
            Console.WriteLine("1 - Green");
            Console.WriteLine("2 - Blue");
            Color color = (Color) Int32.Parse(Console.ReadLine());

            Console.Write("Введите текст: ");
            String text = Console.ReadLine();
            MyClass.Print(text, (int)color);
        }
    }
}
