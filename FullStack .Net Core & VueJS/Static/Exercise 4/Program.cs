using System;

namespace Exercise_4
{
    class Program
    {
        static void Main(string[] args)
        {
            String s = "Hello World!";

            Console.WriteLine(s.MySubstring(6, 6));

            Console.WriteLine(s.MyIndexOf("!"));
            Console.WriteLine(s.MyIndexOf("Wo"));

            Console.WriteLine(s.MyReplace("Hello", "Hi"));
            Console.WriteLine(s.MyReplace("!", "..."));
        }
    }

    public static class MyClassExtension
    {
        public static String MySubstring(this String value, Int32 startIndex, Int32 length)
        {
            if (startIndex < 0 && startIndex >= value.Length && length > value.Length && length < 0 && (length + startIndex) <= value.Length)
            {
                throw new Exception();
            }
            String result = "";
            for (int i = startIndex; i < startIndex + length; i++)
            {
                result += value[i];
            }

            return result;
        }

        public static Int32 MyIndexOf(this String str, string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException();
            }

            for (int i = 0; i <= str.Length - value.Length; i++)
            {
                if (str[i] == value[0])
                {
                    if (str.MySubstring(i, value.Length) == value)
                    {
                        return i;
                    }
                }
            }

            return -1;
        }

        public static String MyReplace(this String str, String oldValue, String newValue)
        {
            if (oldValue == null)
            {
                throw new ArgumentNullException();
            }

            if (oldValue == "")
            {
                throw new ArgumentException();
            }

            String s = str;


            while (s.MyIndexOf(oldValue) != -1)
            {
                string result = "";
                Int32 pos = s.IndexOf(oldValue);

                for (int i = 0; i < pos; i++)
                {
                    result += s[i];
                }

                result += newValue;
                for (int i = pos + oldValue.Length; i < s.Length; i++)
                {
                    result += s[i];
                }

                s = result;
            }

            return s;
        }



    }

}
