using System;

namespace Exercise_2_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Int32[] array = new[] { 5, 8, 12, 1, -5, 25 };

            PrintArray(array);

            array.MySortArray();

            PrintArray(array);

            array.MySortArray(false);

            PrintArray(array);

            array.MySortArray(true);

            PrintArray(array);
        }


        public static void PrintArray(Int32[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]} ");
            }

            Console.WriteLine();
        }
    }

    public static class MyClassExtation
    {
        public static void MySortArray(this Int32[] masInts)
        {
            Int32 temp;
            for (Int32 i = 0; i < masInts.Length - 1; i++)
            {
                for (Int32 j = i + 1; j < masInts.Length; j++)
                {
                    if (masInts[i] > masInts[j])
                    {
                        temp = masInts[i];
                        masInts[i] = masInts[j];
                        masInts[j] = temp;
                    }
                }
            }
        }

        public static void MySortArray(this Int32[] masInts, bool lowestFirst)
        {
            Int32 temp;
            for (Int32 i = 0; i < masInts.Length - 1; i++)
            {
                for (Int32 j = i + 1; j < masInts.Length; j++)
                {
                    if (lowestFirst)
                    {
                        if (masInts[i] > masInts[j])
                        {
                            temp = masInts[i];
                            masInts[i] = masInts[j];
                            masInts[j] = temp;
                        }
                    }

                    else
                    {
                        if (masInts[i] < masInts[j])
                        {
                            temp = masInts[j];
                            masInts[j] = masInts[i];
                            masInts[i] = temp;
                        }
                    }

                }
            }
        }

    }
}
