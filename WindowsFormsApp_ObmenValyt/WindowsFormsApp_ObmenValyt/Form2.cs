using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
            f1.Visible = true;
            f1.label5.Text = textBox1.Text;
            this.Visible = false;
           
            
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
    }
}
