using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppHost
{
    class Service : IContract
    {
        public int NumberGlas(string s) // функция поиска анг. гласных букв
        {
            char[] chars = { 'a', 'e', 'i', 'o', 'u', 'y', 'A', 'E', 'I', 'O', 'U', 'Y' };  // массив глассных букв анг. яз.
            Console.WriteLine("Строка: {0}", s);
            int res = 0;    // посчет найденых совпадений букв
            int i=0;
            while (s.IndexOfAny(chars,i) != -1) // ддя поиска совподений i- с какого индекса искать
            {
                i = s.IndexOfAny(chars, i) +1;  // запоминаем индекс + 1
                res++;
            }
            Console.WriteLine("В строке \"{0}\" анг. гласных букв = {1}", s, res);
            return res; // возвращаем результат
        }

        public int NumberLines(string s) // функция вычисления  слов в предложении
        {
            Console.WriteLine("Строка: {0}", s);    
            string[] result = s.Split(' '); // разделителем слов является пробел
            int count = result.Count<string>();
            Console.WriteLine("В строке \"{0}\" количество слов = {1}", s,count);
            return count;  // Count<string>() подсчитывает колличество строк в [] result 
        }
    }
}
