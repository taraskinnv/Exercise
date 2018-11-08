﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace MyPaintWinForm
{
    public delegate void Progbar();
    public partial class Form1 : Form
    {
        Point MouseLoc = new Point(0, 0);
        Point Start;
        Point Finish;
        Point Start1;
        Point Finish1= new Point(0, 0);
        Point _center;
        Point _endPoint;
        bool DrowP = false;
        bool flag = false;
        bool background = false;
        bool b = false;
        bool startPaint = false;
        bool drawPoint = false;
        bool drawline = false;
        bool drawRectangle = false;
        bool drawCircle = false;
        bool paint = false;
        float radius;
        List<datalist> list = new List<datalist>();
        Pen pen;
        SolidBrush br;
        static Bitmap bitmap;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            StartNew();
        }

        private void StartNew() //параметры по умолчанию
        {
            pictureBox1.BackColor = Color.White;
            btn_backgroung_fon.BackColor = Color.White;
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            br = new SolidBrush(Color.White);
            btn_color.BackColor = Color.Black;
            btn_back_color.BackColor = pictureBox1.BackColor;
            textBox2.Text = "6";
            pen = new Pen(btn_color.BackColor, float.Parse(textBox2.Text));
            checkBox1.CheckState = CheckState.Checked;

            progressBar1.Minimum = 0;
            progressBar1.Maximum = pictureBox1.Height - 1;
            progressBar1.Value = 1;
            progressBar1.Step = 1;

            button2.Click += Button2_Click;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (bBack.Enabled)
            {
                bBack.Enabled = false;
            }
            else
            {
                bBack.Enabled = true;
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            paint = true;
            if (e.Button == MouseButtons.Left && drawCircle)
            {
                startPaint = true;
                flag = false;
                _center = new Point(e.X, e.Y);
                pictureBox1.Paint += OnMovePictureBox_Paint;
            }
            if (e.Button == MouseButtons.Left && drawline)
            {
                Start = new Point(e.X, e.Y);
                startPaint = true;
                flag = false;
                pictureBox1.Paint += OnMovePictureBox_Paint;
            }
            if (e.Button == MouseButtons.Left && drawPoint)
            {
                startPaint = true;
                flag = false;
                _center = new Point(e.X, e.Y);
                DrowP = true;
            }
            if (e.Button == MouseButtons.Left && drawRectangle)
            {
                Start = new Point(e.X, e.Y);
                Start1 = new Point(e.X, e.Y);
                startPaint = true;
                flag = false;
                //Запоминаем центр
                _center = new Point(e.X, e.Y);
                pictureBox1.Paint += OnMovePictureBox_Paint;
            }
        }
         
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            startPaint = false;
            DrowP = false;
            flag = true;
            Finish = new Point(e.X, e.Y);
            //Запоминаем конечную точку радиуса
            _endPoint = new Point(e.X, e.Y);
            //Переназначаем метод рисования
            pictureBox1.Paint -= OnMovePictureBox_Paint;
            pictureBox1.Invalidate();
        }
        
        private void OnMovePictureBox_Paint(object sender, PaintEventArgs e)
        {
            float radius;
            if (drawPoint)
            {
                radius = float.Parse(textBox2.Text)/2;
            }
            else
            {
                radius = (float)Math.Sqrt(Math.Pow(_endPoint.X - _center.X, 2) + Math.Pow(_endPoint.Y - _center.Y, 2));
            }
            if (drawline)
            {
                e.Graphics.DrawLine(pen, Start, Finish1);
            }
            if (drawCircle)
            {
                e.Graphics.TranslateTransform(_center.X, _center.Y);
                e.Graphics.DrawEllipse(pen,  -radius, -radius, radius * 2, radius * 2);
            }
            if (drawPoint)
            {
                e.Graphics.TranslateTransform(_center.X, _center.Y);
                e.Graphics.FillEllipse(new SolidBrush(btn_color.BackColor),_center.X -radius, _center.Y- radius, radius * 2, radius * 2);
            }
            if (drawRectangle)
            {
                if (Start.X > Finish1.X)
                {
                    int a = Start.X;
                    Start1.X = Finish1.X;
                    Finish1.X = a;
                }
                if (Start.Y > Finish1.Y)
                {
                    int a = Start.Y;
                    Start1.Y = Finish1.Y;
                    Finish1.Y = a;
                }
                e.Graphics.DrawRectangle(pen, Start1.X, Start1.Y, Finish1.X - Start1.X, Finish1.Y - Start1.Y);
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e) //при движении мышки
        {
            if (DrowP)
            {
                datalist dp = new datalist(datalist.MyElenent.point, pen, _center.X, _center.Y, e.X, e.Y);
                list.Add(dp);
                _center = e.Location;
                pictureBox1.Invalidate();
            }
            if (drawline && paint)
            {
                if (e.Button == MouseButtons.Left)
                {
                    //Запоминаем конечную точку радиуса
                    Finish1 = e.Location;
                    //Обновляем PictureBox, чтобы вызывать его перерисовку
                    pictureBox1.Invalidate();
                }
                if (!flag)
                {
                    pictureBox1.Invalidate();
                }
                if (flag)
                {
                    datalist dl = new datalist(datalist.MyElenent.line, pen, Start.X, Start.Y, Finish.X, Finish.Y);
                    list.Add(dl);
                    flag = false;
                }
            }
            if (drawRectangle && paint)
            {
                Finish1 = e.Location;
                if (!flag)
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        //Запоминаем конечную точку радиуса
                        _endPoint = new Point(e.X, e.Y);
                        //Обновляем PictureBox, чтобы вызывать его перерисовку
                        pictureBox1.Invalidate();
                    }
                }
                if (flag)
                {
                    if (checkBox1.CheckState == CheckState.Checked)
                    {
                        b = true;
                    }
                    else
                    {
                        b = false;
                    }

                    if (Start.X>Finish.X)
                    {
                        int a = Start.X;
                        Start.X = Finish.X;
                        Finish.X = a;

                    }

                    if (Start.Y > Finish.Y)
                    {
                        int a = Start.Y;
                        Start.Y = Finish.Y;
                        Finish.Y = a;
                    }
                    datalist dr = new datalist(datalist.MyElenent.rectangle, pen, Start.X, Start.Y, Finish.X - Start.X, Finish.Y - Start.Y, b, background, new SolidBrush(btn_back_color.BackColor));
                    list.Add(dr);
                    flag = false;
                }
                pictureBox1.Invalidate();
            }
            if (drawCircle && paint)
            {

                if (!flag)
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        //Запоминаем конечную точку радиуса
                        _endPoint = new Point(e.X, e.Y);
                        //Обновляем PictureBox, чтобы вызывать его перерисовку
                        pictureBox1.Invalidate();
                    }
                }
                if (flag)
                {
                    if (checkBox1.CheckState == CheckState.Checked)
                    {
                        b = true;
                    }
                    else
                    {
                        b = false;
                    }
                    radius = (float)Math.Sqrt(Math.Pow(_endPoint.X - _center.X, 2) + Math.Pow(_endPoint.Y - _center.Y, 2));
                    datalist dr = new datalist(datalist.MyElenent.circle, pen, _center.X - radius, _center.Y - radius, radius * 2, radius * 2, b, background, new SolidBrush(btn_back_color.BackColor));
                    list.Add(dr);
                    flag = false;
                }
                pictureBox1.Invalidate();
            }
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                e.Graphics.FillRectangle(br, 0, 0, pictureBox1.Width, pictureBox1.Height);
            }
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].myElenent== datalist.MyElenent.point)
                {
                    e.Graphics.DrawLine(list[i].MyPen, list[i].StartX, list[i].StartY, list[i].EndX, list[i].EndY);
                }
                else if (list[i].myElenent == datalist.MyElenent.line)
                {
                    e.Graphics.DrawLine(list[i].MyPen, list[i].StartX, list[i].StartY, list[i].EndX, list[i].EndY);
                }
                else if (list[i].myElenent == datalist.MyElenent.rectangle)
                {
                    if (list[i].ColorBackGround == false && list[i].ColorContour == true)
                    {
                        e.Graphics.DrawRectangle(list[i].MyPen, list[i].StartX, list[i].StartY, list[i].EndX, list[i].EndY);
                    }
                    else if (list[i].ColorBackGround == true && list[i].ColorContour == true)
                    {
                        e.Graphics.FillRectangle(list[i].solidBrush, list[i].StartX, list[i].StartY, list[i].EndX, list[i].EndY);
                        e.Graphics.DrawRectangle(list[i].MyPen, list[i].StartX, list[i].StartY, list[i].EndX, list[i].EndY);
                    }
                    else if (list[i].ColorBackGround == true && list[i].ColorContour == false)
                    {
                        e.Graphics.FillRectangle(list[i].solidBrush, list[i].StartX, list[i].StartY, list[i].EndX, list[i].EndY);
                    }
                }
                else if (list[i].myElenent == datalist.MyElenent.circle)
                {
                    if (list[i].ColorBackGround == false && list[i].ColorContour == true)
                    {
                        e.Graphics.DrawEllipse(list[i].MyPen, list[i].StartX, list[i].StartY, list[i].EndX, list[i].EndY);
                    }
                    else if (list[i].ColorBackGround == true && list[i].ColorContour == true)
                    {
                        e.Graphics.FillEllipse(list[i].solidBrush, list[i].StartX, list[i].StartY, list[i].EndX, list[i].EndY);
                        e.Graphics.DrawEllipse(list[i].MyPen, list[i].StartX, list[i].StartY, list[i].EndX, list[i].EndY);
                    }
                    else if (list[i].ColorBackGround == true && list[i].ColorContour == false)
                    {
                        e.Graphics.FillEllipse(list[i].solidBrush, list[i].StartX, list[i].StartY, list[i].EndX, list[i].EndY);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            drawPoint = true;
            drawline = false;
            drawRectangle = false;
            drawCircle = false;
            paint = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ////g.Clear(Color.White);
            //pictureBox1.Paint += PictureBox1_Paint;
            //pictureBox1.Invalidate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            drawline = true;
            drawPoint = false;
            drawRectangle = false;
            drawCircle = false;
            //Button btn = sender as Button;
            //btn.Enabled = false;
            paint = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            drawline = false;
            drawPoint = false;
            drawRectangle = true;
            drawCircle = false;
            paint = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            drawline = false;
            drawPoint = false;
            drawRectangle = false;
            drawCircle = true;
            paint = false;
        }

        private void btn_color_Click(object sender, EventArgs e)
        {
            ColorDialog c = new ColorDialog();
            if (c.ShowDialog() == DialogResult.OK)
            {
                btn_color.BackColor = c.Color;
                pen = new Pen(btn_color.BackColor, float.Parse(textBox2.Text));
            }
        }

        private void comboBox1_TextUpdate(object sender, EventArgs e)
        {
            //ComboBox comboBoxSize = sender as ComboBox;
            //double a = 1;
            //if (!double.TryParse(comboBoxSize.Text,out a))
            //{
            //    comboBoxSize.Text = a.ToString();
            //}
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            pen = new Pen(btn_color.BackColor, float.Parse(textBox2.Text));
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            if (btn_color.BackColor == pictureBox1.BackColor)
            {
                checkBox1.CheckState = CheckState.Unchecked;
                MessageBox.Show("Измените цвет фона");
            }
        }

        private void checkBox2_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox2.CheckState == CheckState.Checked)
            {
                background = true;
            }
            else
            {
                background = false;
            }
        }

        private void btn_back_color_Click(object sender, EventArgs e)
        {
            ColorDialog c = new ColorDialog();
            if (c.ShowDialog() == DialogResult.OK)
            {
                btn_back_color.BackColor = c.Color;
            }
        }
        
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            
            if (open.ShowDialog() == DialogResult.OK)
            {
                bitmap = new Bitmap(open.FileName);
                pictureBox1.Image = bitmap;
                btn_backgroung_fon.Enabled = false;
            }
            
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            if (save.ShowDialog() == DialogResult.OK)
            {
                //if (pictureBox1.Image == null)
                //{
                //    Bitmap myBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                //    Graphics g1 = Graphics.FromImage(myBitmap);
                //    Paint(g1);
                //    myBitmap.Save(save.FileName + ".jpg");
                //}
                //else
                //{
                //    Graphics g1 = Graphics.FromImage(bitmap);
                //    Paint(g1);
                //    bitmap.Save(save.FileName + ".jpg");
                //}

                //bitmap = ClonBitmap();
                //pictureBox1.Image = bitmap;
                //bitmap.Save(save.FileName + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                //ClonBitmap().Save(save.FileName + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }
        private void Paint(Graphics g)
        {
            //if (pictureBox1.Image != bitmap)
            if(pictureBox1.Image == null)
            {
                g.FillRectangle(br, 0, 0, pictureBox1.Width, pictureBox1.Height);
            }
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].myElenent == datalist.MyElenent.point)
                {
                    g.DrawLine(list[i].MyPen, list[i].StartX, list[i].StartY, list[i].EndX, list[i].EndY);
                }
                else if (list[i].myElenent == datalist.MyElenent.line)
                {
                    g.DrawLine(list[i].MyPen, list[i].StartX, list[i].StartY, list[i].EndX, list[i].EndY);
                }
                else if (list[i].myElenent == datalist.MyElenent.rectangle)
                {
                    if (list[i].ColorBackGround == false && list[i].ColorContour == true)
                    {
                        g.DrawRectangle(list[i].MyPen, list[i].StartX, list[i].StartY, list[i].EndX, list[i].EndY);
                    }
                    else if (list[i].ColorBackGround == true && list[i].ColorContour == true)
                    {
                        g.FillRectangle(list[i].solidBrush, list[i].StartX, list[i].StartY, list[i].EndX, list[i].EndY);
                        g.DrawRectangle(list[i].MyPen, list[i].StartX, list[i].StartY, list[i].EndX, list[i].EndY);
                    }
                    else if (list[i].ColorBackGround == true && list[i].ColorContour == false)
                    {
                        g.FillRectangle(list[i].solidBrush, list[i].StartX, list[i].StartY, list[i].EndX, list[i].EndY);
                    }
                }
                else if (list[i].myElenent == datalist.MyElenent.circle)
                {
                    if (list[i].ColorBackGround == false && list[i].ColorContour == true)
                    {
                        g.DrawEllipse(list[i].MyPen, list[i].StartX, list[i].StartY, list[i].EndX, list[i].EndY);
                    }
                    else if (list[i].ColorBackGround == true && list[i].ColorContour == true)
                    {
                        g.FillEllipse(list[i].solidBrush, list[i].StartX, list[i].StartY, list[i].EndX, list[i].EndY);
                        g.DrawEllipse(list[i].MyPen, list[i].StartX, list[i].StartY, list[i].EndX, list[i].EndY);
                    }
                    else if (list[i].ColorBackGround == true && list[i].ColorContour == false)
                    {
                        g.FillEllipse(list[i].solidBrush, list[i].StartX, list[i].StartY, list[i].EndX, list[i].EndY);
                    }
                }
            }
        }
        
        private void ClonBitmap()
        {
            
            Graphics g1 = Graphics.FromImage(bitmap);
            Paint(g1);
            pictureBox1.Image = bitmap;
        }

        Thread MyThread;
        private void button2_Click_1(object sender, EventArgs e)
        {
            ClonBitmap();
            list.Clear();

            pictureBox1.Enabled = false;

            MyThread = new Thread(new ParameterizedThreadStart(this.Invert));
            MyThread.Name = "qwerty";
            MyThread.IsBackground = true;
            MyThread.Start(bitmap);
        }

        public void Invert(object obj)   // инвертирование цветов
        {
            Bitmap bitmap1 = obj as Bitmap;
            Action progMet = progressBar1.PerformStep;
            var temp = (Bitmap)bitmap1.Clone();

            for (int y = 0; y < temp.Height; y++)
            {
                for (int x = 0; x < temp.Width; x++)
                {
                    Color oldColor = temp.GetPixel(x, y);
                    Color newColor = Color.FromArgb(oldColor.A, 255 - oldColor.R, 255 - oldColor.G, 255 - oldColor.B);
                    bitmap1.SetPixel(x, y, newColor);
                }
                //this.Invoke(new Action(() => progressBar1.PerformStep()));
                progMet.Invoke();
                //Invoke((MethodInvoker)delegate { Refresh();});
                
                Refresh();
            }
            pictureBox1.Invoke(new Action(() => pictureBox1.Enabled = true));
        }

        private void btn_backgroung_fon_Click(object sender, EventArgs e)   // смена цвета фона
        {
            ColorDialog c = new ColorDialog();
            if (c.ShowDialog() == DialogResult.OK)
            {
                btn_backgroung_fon.BackColor = c.Color;
                pictureBox1.BackColor = btn_backgroung_fon.BackColor;
                br = new SolidBrush(c.Color);
            }
        }

        private void cleanToolStripMenuItem_Click(object sender, EventArgs e)   // очистка полей полностью
        {
            list.Clear();
            pictureBox1.Image = null;
            StartNew();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            list.RemoveAt(list.Count - 1);
            pictureBox1.Invalidate();
        }
        
    }
}
