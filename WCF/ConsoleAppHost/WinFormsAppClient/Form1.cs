using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsAppClient
{

    public partial class Form1 : Form
    {
        IContract chanel;
        public Form1()
        {
            InitializeComponent();
            Uri address =
               new Uri("http://localhost:8733/ConsoleAppHost/IContract");
            BasicHttpBinding binding = new BasicHttpBinding();
            EndpointAddress endpoint = new EndpointAddress(address);
            ChannelFactory<IContract> factory =
                new ChannelFactory<IContract>(binding, endpoint);
            chanel = factory.CreateChannel();
        }

        private void CalcString()
        {
            int num = chanel.NumberLines(textBox1.Text);
            MessageBox.Show(string.Format("В предложении:\"{0}\" количество слов = {1}", textBox1.Text, num), "Вычисление количества слов");
        }
        private void CalcGlas()
        {
            int num = chanel.NumberGlas(textBox1.Text);
            MessageBox.Show(string.Format("В предложении:\"{0}\" гласных букв = {1}", textBox1.Text, num), "Вычисление гласных букв");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            CalcString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CalcGlas();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Клиент";
        }
    }
}
