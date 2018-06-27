using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_ObmenValyt
{
    public partial class Form1 : Form
    {
        Form2 f2;
        public Form1()
        {
            InitializeComponent();
            Params();
            f2 = new Form2(this);
            if (f2.ShowDialog() == DialogResult.OK)
            {
                this.Visible = false;
            }
        }
        

        private void Params()       // начальные параметры
        {
            comboBox1.SelectedIndex = 0;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.SelectedIndex = 1;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            textBox2.ReadOnly = true;
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
            Log();
            Email();
        }

        private void Log()
        {
            string currDir = Environment.CurrentDirectory.ToString() +"\\"+ "Log.txt";
            FileInfo f = new FileInfo(currDir);
            string textFromFile = "";
            if (f.Exists)
            {
                using (FileStream fstream = File.OpenRead(currDir))
                {
                    // преобразуем строку в байты
                    byte[] array = new byte[fstream.Length];
                    // считываем данные
                    fstream.Read(array, 0, array.Length);
                    // декодируем байты в строку
                    textFromFile = Encoding.Default.GetString(array);
                }
            }
            textFromFile += DateTime.Now.ToString() + " : " + comboBox1.Text + " " + comboBox2.Text + " " + textBox1.Text + " " + textBox2.Text + "\n";
            //// запись в файл
            using (FileStream fstream = new FileStream(currDir, FileMode.OpenOrCreate))
            {
                // преобразуем строку в байты
                byte[] array = Encoding.Default.GetBytes(textFromFile);
                // запись массива байтов в файл

                fstream.Write(array, 0, array.Length);
            }
        }

        private void Email()
        {
            // отправитель - устанавливаем адрес и отображаемое в письме имя
            MailAddress from = new MailAddress("qwerty@gmail.com", "Tom");
            // кому отправляем
            MailAddress to = new MailAddress(label5.Text);
            // создаем объект сообщения
            MailMessage m = new MailMessage(from, to);
            // тема письма
            m.Subject = "Обмен валют";
            // текст письма
            m.Body = "Oперация по конвертации прошла успешно "+DateTime.Now.ToString() + " : " + comboBox1.Text + " " + comboBox2.Text + " " + textBox1.Text + " " + textBox2.Text;
            // письмо представляет код html
            m.IsBodyHtml = false;
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient("aspmx.l.google.com", 25);

            // логин и пароль
            smtp.Credentials = new NetworkCredential("Login", "password");
            smtp.EnableSsl = false;
            smtp.Send(m);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            f2.Visible = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TextBox t = sender as TextBox;
            try
            {
                if (t.Text !="" || comboBox1.SelectedItem != comboBox2.SelectedItem)
                {
                    if (comboBox1.SelectedItem != comboBox2.SelectedItem)
                    {
                        if (comboBox1.Text != "UAH")
                        {
                            double[] d1 = UAH(comboBox1.Text);
                            if (comboBox2.Text == "UAH")
                            {
                                textBox2.Text = (Double.Parse(t.Text) * d1[0]).ToString();
                            }
                            else
                            {
                                double[] d = UAH(comboBox2.Text);
                                textBox2.Text = ((Double.Parse(t.Text) * d1[0]) / d[1]).ToString();
                            }
                        }
                        else
                        {
                            double[] d = UAH(comboBox2.Text);
                            textBox2.Text = (Double.Parse(t.Text) / d[1]).ToString();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Введите разные валюты!!!");
                    }
                }
                else
                {
                    textBox2.Text = "";
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex) { }
            }

       
    }
}
