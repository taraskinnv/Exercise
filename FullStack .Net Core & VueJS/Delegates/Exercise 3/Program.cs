using System;

namespace Exercise_3
{
    delegate Int32 GetIntRandomDelegate();

    delegate Double MyDelegate(GetIntRandomDelegate[] arrayDelegates);
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            GetIntRandomDelegate getIntRandomDelegate = () => random.Next(-100, 100);

            GetIntRandomDelegate[] delegates = new[]
            {
                getIntRandomDelegate,
                getIntRandomDelegate,
                getIntRandomDelegate,
                getIntRandomDelegate
            };

            MyDelegate myDelegate = delegate(GetIntRandomDelegate[] arrayDelegates)
            {
                if (arrayDelegates == null)
                {
                    throw new NullReferenceException();
                }
                Double count = 0;
                for (int i = 0; i < arrayDelegates.Length; i++)
                {
                    count += arrayDelegates[i].Invoke();
                    Console.WriteLine(count);
                }

                return count / arrayDelegates.Length;
            };

            Console.WriteLine($"Среднее арифметическое возвращаемых значений = { myDelegate.Invoke(delegates)}");
        }
    }
}
