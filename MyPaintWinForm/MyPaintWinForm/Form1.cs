﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyPaintWinForm
{
    public partial class Form1 : Form
    {
        int initX;
        int initY;
        int endX;
        int endY;
        Point _center;
        Point _endPoint;
        bool flag = false;
        bool background = false;
        bool b = false;
        bool startPaint = false;
        bool drawPoint = false;
        bool drawline = false;
        bool drawRectangle = false;
        bool drawCircle = false;
        List<datalist> list = new List<datalist>();
        //Pen pen = new Pen(Color.Black, 3);
        Pen pen;
        public Form1()
        {
            InitializeComponent();
        }
        Graphics g;
        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.White;
            g = pictureBox1.CreateGraphics();
            btn_color.BackColor = Color.Black;
            btn_back_color.BackColor = pictureBox1.BackColor;
            textBox2.Text = "6";
            pen = new Pen(btn_color.BackColor, float.Parse(textBox2.Text));
        }
       

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            startPaint = true;
            flag = false;
            initX = e.X;
            initY = e.Y;
            //if (e.Button == MouseButtons.Left && drawCircle)
            //{
                //Запоминаем центр
                _center = new Point(e.X, e.Y);
                //Назначаем нужный метод рисования.
                //pictureBox1.Paint -= PictureBox1_Paint;
                pictureBox1.Paint += OnMovePictureBox_Paint;
            //}
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            startPaint = false;
            endX = e.X;
            endY = e.Y;
            flag = true;
            //_endPoint = new Point(e.X, e.Y);//
            //if (e.Button == MouseButtons.Left && drawCircle)//
            //{//
                //Запоминаем конечную точку радиуса
                _endPoint = new Point(e.X, e.Y);
                //Переназначаем методы рисования
                pictureBox1.Paint -= OnMovePictureBox_Paint;
                //pictureBox1.Paint += PictureBox1_Paint;
                //Обновляем
                pictureBox1.Invalidate();
            //}//
        }
        int radius;
        private void OnMovePictureBox_Paint(object sender, PaintEventArgs e)
        {
            //Перенос начала координат в указанный центр
            e.Graphics.TranslateTransform(_center.X, _center.Y);
            //Вычисляем радиус по теореме Пифагора
            float radius =
                (float)Math.Sqrt(Math.Pow(_endPoint.X - _center.X, 2) + Math.Pow(_endPoint.Y - _center.Y, 2));
            //Используем пунктирное перо красного цвета
            //using (Pen pen = new Pen(Color.Red, 1.5f))
            //{
            //Рисование окружности
            if (drawCircle)
            {
                SolidBrush sb = new SolidBrush(Color.Brown);
                g.FillEllipse(Brushes.Coral, -radius, -radius, radius * 2, radius * 2);
                e.Graphics.DrawEllipse(pen, -radius, -radius, radius * 2, radius * 2);
            }
            if (drawPoint)
            {
                SolidBrush sb = new SolidBrush(Color.Brown);
                g.FillEllipse(Brushes.Coral, -radius, -radius, radius * 2, radius * 2);
                e.Graphics.DrawEllipse(pen, -radius, -radius, radius * 2, radius * 2);
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (startPaint && drawPoint )
            {
                datalist dp = new datalist(datalist.MyElenent.point, pen, initX, initY, e.X, e.Y);
                //g.DrawLine(pen, initX, initY, e.X, e.Y);


                list.Add(dp);
                initX = e.X;
                initY = e.Y;
                textBox1.Text = list.Count.ToString();
                
            }
            else if (drawline && startPaint || drawline)
            {
                pictureBox1.Invalidate();
                if (!flag)
                {
                    g.DrawLine(pen, initX, initY, e.X, e.Y);

                }
                if (flag)
                {

                    datalist dl = new datalist(datalist.MyElenent.line, pen, initX, initY, endX, endY);
                    list.Add(dl);
                    flag = false;
                }
                textBox1.Text = list.Count.ToString();

            }
            if (drawRectangle && startPaint || drawRectangle)
            {
                pictureBox1.Invalidate();
                if (!flag)
                {
                    g.DrawRectangle(new Pen(Color.Bisque, 5), initX, initY, e.X, e.Y);

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
                    
                    datalist dr = new datalist(datalist.MyElenent.rectangle, pen, initX, initY, endX, endY,b,background, new SolidBrush(btn_back_color.BackColor));
                    list.Add(dr);
                    flag = false;
                }
                textBox1.Text = list.Count.ToString();

            }
            if (drawCircle && startPaint || drawCircle)
            {

                if (!flag)
                {
                    //g.DrawEllipse(pen, initX, initY, e.X, e.Y);


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
                    //datalist dr = new datalist(datalist.MyElenent.circle, initX, initY, endX, endY);
                    if (checkBox1.CheckState == CheckState.Checked)
                    {
                        b = true;
                    }
                    else
                    {
                        b = false;
                    }
                    radius = (int)Math.Sqrt(Math.Pow(_endPoint.X - _center.X, 2) + Math.Pow(_endPoint.Y - _center.Y, 2));
                    g.TranslateTransform(_center.X, _center.Y);
                    datalist dr = new datalist(datalist.MyElenent.circle,pen, initX - radius, initY - radius, radius * 2, radius * 2, b, background, new SolidBrush(btn_back_color.BackColor));
                    list.Add(dr);
                    flag = false;
                }
                textBox1.Text = list.Count.ToString();
                pictureBox1.Invalidate();
            }
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            
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
        }

        private void button4_Click(object sender, EventArgs e)
        {
            drawline = false;
            drawPoint = false;
            drawRectangle = true;
            drawCircle = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            drawline = false;
            drawPoint = false;
            drawRectangle = false;
            drawCircle = true;
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
            if (btn_back_color.BackColor == pictureBox1.BackColor)
            {
                checkBox1.CheckState = CheckState.Unchecked;
                MessageBox.Show("измените цвет фона");

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
    }
}
