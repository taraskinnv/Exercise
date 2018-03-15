using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DZ_potok
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.ShowDialog();
            richTextBox1.Text = new StreamReader(open.FileName).ReadToEnd();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.ShowDialog();
            StreamWriter write = new StreamWriter(save.FileName);
            write.WriteLine(richTextBox1.Text);
            write.Flush();
            write.Close();
        }

        private void button2_Click(object sender, EventArgs e)  // 1 Color text  
        {
            ColorDialog color = new ColorDialog();
            color.ShowDialog();
            richTextBox1.SelectionColor = color.Color;
            richTextBox1.Focus();
        }

        private void button3_Click(object sender, EventArgs e)  //Font
        {
            FontDialog font = new FontDialog();
            font.ShowDialog();
            richTextBox1.SelectionFont = font.Font;
            richTextBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)   // 2 Font text
        {

            FontDialog font = new FontDialog();
            font.ShowDialog();
            richTextBox1.SelectionFont = font.Font;
            richTextBox1.Focus();
        }
    }
}
