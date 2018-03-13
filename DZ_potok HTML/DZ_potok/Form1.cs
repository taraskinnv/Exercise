using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
       
        private void color_text_html(string text, Color color)
        {
            Regex regex = new Regex(@"</?\w*>");
            MatchCollection match = regex.Matches(richTextBox1.Text);
            foreach (var m in match)
            {
                if (m.ToString() == text)
                {
                    int pos = richTextBox1.SelectionStart;
                    int i = richTextBox1.Text.IndexOf(m.ToString());

                    while (i <= richTextBox1.Text.Length - text.Length)
                    {
                        i = richTextBox1.Text.IndexOf(text, i);
                        if (i < 0)
                        {
                            break;
                        }
                        richTextBox1.Select(i, text.Length);
                        richTextBox1.SelectionColor = color;
                        i += text.Length;
                    }
                }
            }
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            color_text_html("<html>", Color.Brown);
            color_text_html("</html>", Color.Brown);
            color_text_html("<title>", Color.Cyan);
            color_text_html("</title>", Color.Cyan);
            color_text_html("<p>", Color.Blue);
            color_text_html("</p>", Color.Blue);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text = new StreamReader(open.FileName).ReadToEnd();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            if (save.ShowDialog() == DialogResult.OK)
            {
                StreamWriter write = new StreamWriter(save.FileName);
                write.WriteLine(richTextBox1.Text);
                write.Flush();
                write.Close();
            }
        }
    }
}
