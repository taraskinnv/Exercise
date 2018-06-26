using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_ObmenValyt
{
    public partial class Form1 : Form
    {
        string[] valyt;
        public Form1()
        {
            InitializeComponent();
            valyt = GetV();
            //double[] znach = USD_UAH();
            double[] znach = UAH("RUR");
            //int d = RUR_UAH()[0];
            //string[] wer = RUR_UAH();
        }
        

        private string PB()     //получение строки с валютами
        {
            string str = "";
            try
            {
                WebRequest request = WebRequest.Create("https://api.privatbank.ua/p24api/pubinfo?exchange&json&coursid=11");

                using (var response = request.GetResponse())
                {
                    using (var stream = response.GetResponseStream())
                    {
                        using (var reader = new StreamReader(stream))
                        {
                            return reader.ReadToEnd();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return str;
        }

        private string[] GetV()
        {
            string[] stringSeparators = new string[] { "}," };
            return PB().Split(stringSeparators, StringSplitOptions.None);
        }

        private double[] USD_UAH()
        {
            double[] znach = new double[2];
            znach[0] = ConvetrToDouble(valyt[0].Substring(valyt[0].IndexOf("\"buy\":\"") + "\"buy\":\"".Length, 8));
            znach[1] = ConvetrToDouble(valyt[0].Substring(valyt[0].IndexOf("\"sale\":\"") + "\"sale\":\"".Length, 8));
            return znach;
        }

        private double[] UAH(string Valut)
        {
            int i = -1;
            switch (Valut)
            {
                case "USD":
                    i = 0;
                    break;
                case "EUR":
                    i = 1;
                    break;
                case "RUR":
                    i = 2;
                    break;
            }
            double[] znach = new double[2];
            znach[0] = ConvetrToDouble(valyt[i].Substring(valyt[i].IndexOf("\"buy\":\"") + "\"buy\":\"".Length, valyt[i].IndexOf("\",\"sale") - (valyt[i].IndexOf("\"buy\":\"") + "\"buy\":\"".Length)));
            znach[1] = ConvetrToDouble(valyt[i].Substring(valyt[i].IndexOf("\"sale\":\"") + "\"sale\":\"".Length, valyt[i].LastIndexOf("\"")-(valyt[i].IndexOf("\"sale\":\"") + "\"sale\":\"".Length)));
            return znach;
        }

        private double[] EUR_UAH()
        {
            double[] znach = new double[2];
            znach[0] = ConvetrToDouble(valyt[1].Substring(valyt[1].IndexOf("\"buy\":\"") + "\"buy\":\"".Length, 8));
            znach[1] = ConvetrToDouble(valyt[1].Substring(valyt[1].IndexOf("\"sale\":\"") + "\"sale\":\"".Length, 8));
            return znach;
        }

        private double[] RUR_UAH()
        {
            double[] znach = new double[2];
            znach[0] = ConvetrToDouble(valyt[2].Substring(valyt[2].IndexOf("\"buy\":\"") + "\"buy\":\"".Length, 8));
            znach[1] = ConvetrToDouble(valyt[2].Substring(valyt[2].IndexOf("\"sale\":\"") + "\"sale\":\"".Length, 8));
            return znach;
        }

        //private double[] USD_UAH()
        //{
        //    double[] znach = new double[2];
        //    znach[0] = ConvetrToDouble(valyt[0].Substring(valyt[0].IndexOf("\"buy\":\"") + "\"buy\":\"".Length, 8));
        //    znach[1] = ConvetrToDouble(valyt[0].Substring(valyt[0].IndexOf("\"sale\":\"") + "\"sale\":\"".Length, 8));
        //    return znach;
        //}

        private double ConvetrToDouble(string number)
        {
            string[] s = number.Split('.');
            string sd = s[0] +','+ s[1];
            return Double.Parse(sd);
        }
    }
}
