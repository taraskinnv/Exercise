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
        
        public Form1()
        {
            InitializeComponent();
            Params();
        }

        private void Params()       // начальные параметры
        {
            comboBox1.SelectedIndex = 0;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.SelectedIndex = 1;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            textBox2.ReadOnly = true;
        }
        
        private void Сonverting() // func conversion
        {
            if (comboBox1.SelectedItem!=comboBox2.SelectedItem)
            {
                if (comboBox1.Text != "UAH")
                {
                    double[] d1 = UAH(comboBox1.Text);
                    if (comboBox2.Text == "UAH")
                    {

                        textBox2.Text = (Double.Parse(textBox1.Text) * d1[0]).ToString();
                    }
                    else
                    {
                        double[] d = UAH(comboBox2.Text);
                        textBox2.Text = ((Double.Parse(textBox1.Text) * d1[0]) / d[1]).ToString();
                    }
                }
                else
                {
                    double[] d = UAH(comboBox2.Text);
                    textBox2.Text = (Double.Parse(textBox1.Text) / d[1]).ToString();
                }
            }
            else
            {
                MessageBox.Show("Введите разные валюты!!!");
            }
        }

        private string PB()     //получение строки с валютами JSON
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

        private string[] GetV()     // разбитие на строки 
        {
            string[] stringSeparators = new string[] { "}," };
            return PB().Split(stringSeparators, StringSplitOptions.None);
        }

        private double[] UAH(string Valut)      //получение buy sale валюты
        {
            string[] valyt = GetV();
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

        
        private double ConvetrToDouble(string number)   //своя конвертация в ToDouble
        {
            string[] s = number.Split('.');
            string sd = s[0] +','+ s[1];
            return Double.Parse(sd);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Сonverting();
        }
    }
}
