using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2_picture
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Button[] mas;
        PictureBox[] mas1;
        Random r;
        static int count;
        static string str;
        private void Form1_Load(object sender, EventArgs e)
        {
            Vid();

        }
        private void Vid()
        {
            mas = new Button[16];
            mas1 = new PictureBox[16];
            int z = 0;
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    //mas[z] = new Button();
                    //mas[z].Size = new Size(100, 100);
                    //mas[z].Location = new Point((this.Height/2) * i, (this.Width/2) * j);
                    //mas[z].Click += C_Click;

                    mas1[z] = new PictureBox();
                    mas1[z].Size = new Size(100, 100);
                    mas1[z].Location = new Point((this.Height / 2) * i, (this.Width / 2) * j);
                    mas1[z].Click += C_Click;
                    //mas[z].Image = Image.FromFile("C:/Users/taraskinnv/Downloads/сбоку с тенью.png");

                    //mas[z].SizeMode = PictureBoxSizeMode.Zoom;
                    //mas[z].Click += new EventHandler(mas[z],m);
                    //mas[z].MouseUp += new MouseEventHandler(mas[z] );

                    //this.Controls.Add(mas[z]);
                    this.Controls.Add(mas1[z]);
                    z++;

                }
            }
            r = new Random();
            for (int i = 0; i < 4; i++)
            {
                if (i%2 == 0)
                {
                    //mas1[i].Image = Image.FromFile("C:/Users/taraskinnv/Downloads/1.png");
                    mas1[i].Visible = true;
                    mas1[i].BackColor = Color.Aqua;
                    mas1[i].Image = null;
                  //mas[i].BackgroundImage = Image.FromFile("C:/Users/taraskinnv/Downloads/сбоку с тенью.png");
                  //mas[i].

                  mas1[i].Tag = "C:/Users/taraskinnv/Downloads/1.png";
                }
                else
                {
                    //mas1[i].Image = Image.FromFile("C:/Users/taraskinnv/Downloads/11lab.png");
                    mas1[i].Visible = true;
                    mas1[i].Tag = "C:/Users/taraskinnv/Downloads/11lab.png";
                }
            }
            count = 0;
        }

        private void C_Click(object sender, EventArgs e)
        {

            count++;
            //if (count>2)
            //{

            //}
            //Button btn = (Button)sender;
            //btn.Visible = false;
            PictureBox b = (PictureBox)sender;
            b.BackColor = Color.Empty;
            b.Image = Image.FromFile(b.Tag.ToString());

            if (b.Tag.ToString() == str)
            {
                b.Image = Image.FromFile("C:/Users/taraskinnv/Downloads/сбоку с тенью.png");
            }
            else
            {
                b.Image = Image.FromFile("C:/Users/taraskinnv/Downloads/IMG_5835.png");
            }
            count++;
        }
    }
}
