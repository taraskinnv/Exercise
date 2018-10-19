using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zadanie_test
{
    public partial class Form2 : Form
    {
        Form1 f1;
        List<Document> doc;
        int number;
        public Form2(List<Document> l, int number)
        {
            InitializeComponent();
            f1 = form1;
            doc = l;
            this.number = number;
        }

        

        private void Form2_Load(object sender, EventArgs e)
        {
            doc[number].
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
