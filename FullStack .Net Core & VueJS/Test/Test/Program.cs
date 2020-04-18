using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var sw = new Stopwatch();
            sw.Start();

            SumNumber(500);
            SumNumber(320);
            SumNumber(100);
            sw.Stop();
            Console.WriteLine($"Время выполнения синхронного вызова методов {(double)sw.ElapsedMilliseconds } Milliseconds");


            var swasync = new Stopwatch();
            swasync.Start();
            var task = SumNumberAsync();
            task.Wait();
            swasync.Stop();
            Console.WriteLine($"Время выполнения асинхронного вызова методов {(double)swasync.ElapsedMilliseconds } Milliseconds");
        }
        static void SumNumber(Int32 count)
        {
            int res = 0;
            for (int i = 0; i < count; i++)
            {
                res += i;
            }
            //Thread.Sleep(2000); //Задержка чтобы не так быстро 
        }


        static async Task SumNumberAsync()
        {

            Task task1 = Task.Factory.StartNew(() => SumNumber(500));
            Task task2 = Task.Factory.StartNew(() => SumNumber(320));
            Task task3 = Task.Factory.StartNew(() => SumNumber(100));
            await Task.WhenAll(new[] { task1, task2, task3 });
        }
    }
}
