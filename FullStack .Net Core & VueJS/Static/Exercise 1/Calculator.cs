using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_1
{
    public static class Calculator
    {
        private static string Method(String str, Int32 pos, Char ch)
        {

            String res1 = "";
            String res2 = "";
            for (int i = pos + 1; i < str.Length; i++)
            {
                if ((str[i] >= '0' && str[i] <= '9') || i == pos + 1)
                {
                    res1 += str[i];
                }
                else
                {
                    break;
                }
            }

            for (int i = pos - 1; i >= 0; i--)
            {
                if ((str[i] >= '0' && str[i] <= '9') || i == 0)
                {
                    res2 += str[i];
                }
                else
                {
                    break;
                }
            }

            String tmp = "";
            for (int i = res2.Length - 1; i >= 0; i--)
            {
                tmp += res2[i];
            }

            res2 = tmp;

            Double x = 0;
            switch (ch)
            {
                case '*':
                    x = Convert.ToDouble(res1) * Convert.ToDouble(res2);
                    break;
                case '+':
                    x = Convert.ToDouble(res1) + Convert.ToDouble(res2);
                    break;
                case '-':
                    x = Convert.ToDouble(res2) - Convert.ToDouble(res1);
                    break;
                case '/':
                    x = Convert.ToDouble(res2) / Convert.ToDouble(res1);
                    break;
            }
            StringBuilder s = new StringBuilder();
            s.Append(res2);
            s.Append(ch);
            s.Append(res1);
            str = str.Replace(s.ToString(), x.ToString());
            str = str.Replace("--", "+");
            return str;
        }

        private static void Change2Chars(ref String str)
        {
            str = str.Replace("--", "+");
            str = str.Replace("-+", "-");
            str = str.Replace("+-", "-");
            str = str.Replace("++", "+");
        }

        private static String MyCalculation(String str)      //вычисление выражения без ()
        {

            while (true)
            {
                char indexMulti = '*';
                char indexDiv = '/';

                Change2Chars(ref str);


                Int32 posMulti = str.IndexOf(indexMulti);
                Int32 posDiv = str.IndexOf(indexDiv);
                if ((posMulti < posDiv && posMulti != -1) || (posDiv == -1 && posMulti != -1))
                {
                    str = Method(str, posMulti, indexMulti);
                }
                else if (posDiv != -1)
                {
                    str = Method(str, posDiv, indexDiv);
                }
                else
                {
                    break;
                }

            }

            Double tempRes;
            while (true && !Double.TryParse(str, out tempRes))
            {
                char indexAdd = '+';
                char indexSub = '-';

                Change2Chars(ref str);


                Int32 posMulti = str.IndexOf(indexAdd);
                Int32 posDiv = str.IndexOf(indexSub);
                if ((posMulti < posDiv && posMulti != -1) || (posDiv == -1 && posMulti != -1))
                {
                    str = Method(str, posMulti, indexAdd);
                }
                else if (posDiv != -1)
                {
                    str = Method(str, posDiv, indexSub);
                }
                else
                {
                    break;
                }

            }

            return str;
        }

        public static String MyExpression(String str)
        {
            while (str.IndexOf(')') != -1)          //вычисление выражения в ()
            {
                Int32 x2 = str.IndexOf(')');
                Int32 x1 = str.LastIndexOf('(', x2);
                String res = str.Substring(x1 + 1, x2 - x1 - 1);
                String rep = str.Substring(x1, x2 - x1 + 1);
                str = str.Replace(rep, MyCalculation(res));
            }

            return MyCalculation(str);
        }
    }
}
