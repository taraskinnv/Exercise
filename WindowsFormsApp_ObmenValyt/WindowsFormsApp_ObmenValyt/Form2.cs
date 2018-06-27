using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_ObmenValyt
{
    public partial class Form2 : Form
    {
        Form1 f1;
        public Form2(Form1 f)
        {
            InitializeComponent();
            f1 = f;
        }


        
        private void button1_Click(object sender, EventArgs e)      //нажатие на кнопку
        {
            //if (Regex_mail(textBox1.Text) == textBox1.Text)
            if(IsValid(textBox1.Text))
            {
                f1.Visible = true;
                f1.label5.Text = textBox1.Text;
                this.Visible = false;
            }
            else
            {
                MessageBox.Show("Введите корректный Email");
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)   //оброботчик закрытия формы
        {
            if(e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                f1.Visible = true;
                this.Visible = false;
            }
        }

        //private string Regex_mail(string mail)
        //{
        //    Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");//(@"[]\w\.*\w*@\w*\.\w*");
        //    Match match = regex.Match(mail);
        //    if (match.Success)
        //    {
        //        return mail;
        //    }
        //    else
        //    {
        //        return "";
        //    }
        //}

        public bool IsValid(string emailaddress)        //Проверка правильности введения 
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
