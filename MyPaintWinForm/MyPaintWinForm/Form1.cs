using System;
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
        Point MouseLoc = new Point(0, 0);
        Point Start;
        Point Finish;
        Point Start1;
        Point Finish1= new Point(0, 0);
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
            checkBox1.CheckState = CheckState.Checked;
        }
       

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left && drawCircle)
            {
                startPaint = true;
                flag = false;
                initX = e.X;
                initY = e.Y;
                //
                //Запоминаем центр
                _center = new Point(e.X, e.Y);
                //Назначаем нужный метод рисования.
                //pictureBox1.Paint -= PictureBox1_Paint;
                pictureBox1.Paint += OnMovePictureBox_Paint;
            }
            if (e.Button == MouseButtons.Left && drawPoint)
            {
                startPaint = true;
                flag = false;
                initX = e.X;
                initY = e.Y;
                //
                //Запоминаем центр
                //_center = new Point(e.X, e.Y);
                _center = new Point(0, 0);
                //Назначаем нужный метод рисования.
                //pictureBox1.Paint -= PictureBox1_Paint;
                //pictureBox1.Paint += OnMovePictureBox_Paint;
                ////g.TranslateTransform(_center.X, _center.Y);
                //////datalist dp = new datalist(datalist.MyElenent.point, pen, initX, initY, e.X, e.Y,false,true);
                //////g.DrawLine(pen, initX, initY, e.X, e.Y);
                ////float radius = float.Parse(textBox2.Text) / 2;
                ////g.FillEllipse(new SolidBrush(btn_color.BackColor), _center.X - radius, _center.Y - radius, radius * 2, radius * 2);
                //////g.FillEllipse(new SolidBrush(btn_color.BackColor), -float.Parse(textBox2.Text), -float.Parse(textBox2.Text), float.Parse(textBox2.Text) * 2, float.Parse(textBox2.Text) * 2);
                ////datalist dp = new datalist(datalist.MyElenent.point, pen, _center.X - radius, _center.Y - radius, radius * 2, radius * 2, false, background, new SolidBrush(btn_color.BackColor));
                ////list.Add(dp);
                ////textBox1.Text = list.Count.ToString();

                ////pictureBox1.Invalidate();
            }
            if (e.Button == MouseButtons.Left && drawRectangle)
            {
                Start = new Point(e.X, e.Y);
                Start1 = new Point(e.X, e.Y);
                startPaint = true;
                flag = false;
                initX = e.X;
                initY = e.Y;
                //
                //Запоминаем центр
                _center = new Point(e.X, e.Y);
                //Назначаем нужный метод рисования.
                //pictureBox1.Paint -= PictureBox1_Paint;
                pictureBox1.Paint += OnMovePictureBox_Paint;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
                startPaint = false;
                endX = e.X;
                endY = e.Y;
                flag = true;
            Finish  = new Point(e.X, e.Y);
            //_endPoint = new Point(e.X, e.Y);//
            //
            //Запоминаем конечную точку радиуса
            _endPoint = new Point(e.X, e.Y);
                //Переназначаем методы рисования
                pictureBox1.Paint -= OnMovePictureBox_Paint;
                //pictureBox1.Paint += PictureBox1_Paint;
                //Обновляем
                pictureBox1.Invalidate();

        }
        float radius;
        private void OnMovePictureBox_Paint(object sender, PaintEventArgs e)
        {
            //Перенос начала координат в указанный центр
            //e.Graphics.TranslateTransform(_center.X, _center.Y);
            //Вычисляем радиус по теореме Пифагора
            float radius;//
            if (drawPoint)
            {
                //radius = (float)Math.Sqrt(Math.Pow(float.Parse(textBox2.Text) - _center.X, 2) + Math.Pow(float.Parse(textBox2.Text) - _center.Y, 2));
                radius = float.Parse(textBox2.Text)/2;
            }
            else
            {
                radius = (float)Math.Sqrt(Math.Pow(_endPoint.X - _center.X, 2) + Math.Pow(_endPoint.Y - _center.Y, 2));
            }
            //Используем пунктирное перо красного цвета
            //using (Pen pen = new Pen(Color.Red, 1.5f))
            //{
            //Рисование окружности
            if (drawCircle)
            {
                g.FillEllipse(new SolidBrush(btn_color.BackColor), -radius, -radius, radius * 2, radius * 2);
                e.Graphics.DrawEllipse(pen,  -radius, -radius, radius * 2, radius * 2);
            }
            if (drawPoint)
            {
                g.FillEllipse(new SolidBrush(btn_color.BackColor),_center.X -radius, _center.Y- radius, radius * 2, radius * 2);
                //g.FillEllipse(new SolidBrush(btn_color.BackColor), -float.Parse(textBox2.Text)/2, -float.Parse(textBox2.Text)/2, float.Parse(textBox2.Text) * 2, float.Parse(textBox2.Text) * 2);
                //e.Graphics.FillEllipse(new SolidBrush(btn_color.BackColor), -float.Parse(textBox2.Text), -float.Parse(textBox2.Text), float.Parse(textBox2.Text) * 2, float.Parse(textBox2.Text) * 2);
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
                //e.Graphics.FillRectangle(new SolidBrush(btn_color.BackColor), Start1.X, Start1.Y, Finish1.X - Start1.X, Finish1.Y - Start1.Y);
                e.Graphics.DrawRectangle(pen, Start1.X, Start1.Y, Finish1.X - Start1.X, Finish1.Y - Start1.Y);
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            //if (startPaint && drawPoint )
            //{
            if (e.Button == MouseButtons.Left && drawPoint && startPaint)
            {

                _center = e.Location;
                g.TranslateTransform(_center.X, _center.Y);
                //datalist dp = new datalist(datalist.MyElenent.point, pen, initX, initY, e.X, e.Y,false,true);
                //g.DrawLine(pen, initX, initY, e.X, e.Y);
                float radius = float.Parse(textBox2.Text) / 2;
                g.FillEllipse(new SolidBrush(btn_color.BackColor), _center.X - radius, _center.Y - radius, radius * 2, radius * 2);
                //g.FillEllipse(new SolidBrush(btn_color.BackColor), -float.Parse(textBox2.Text), -float.Parse(textBox2.Text), float.Parse(textBox2.Text) * 2, float.Parse(textBox2.Text) * 2);
                datalist dp = new datalist(datalist.MyElenent.point, pen, _center.X - radius, _center.Y - radius, radius * 2, radius * 2, false, background, new SolidBrush(btn_color.BackColor));
                list.Add(dp);
                _center.X = e.X;
                _center.Y = e.Y;
                textBox1.Text = list.Count.ToString();
                pictureBox1.Invalidate();

            }

            ////////////////////////////////////// другой вариант
            //MouseLoc = e.Location;
            //if (e.Button == MouseButtons.Left && drawPoint && startPaint)
            //{
            //    if (_center != e.Location)
            //    {
            //        _center = e.Location;
            //        g.TranslateTransform(e.X, _center.Y);
            //        //datalist dp = new datalist(datalist.MyElenent.point, pen, initX, initY, e.X, e.Y,false,true);
            //        //g.DrawLine(pen, initX, initY, e.X, e.Y);
            //        float radius = float.Parse(textBox2.Text) / 2;
            //        g.FillEllipse(new SolidBrush(btn_color.BackColor), _center.X - radius, _center.Y - radius, radius * 2, radius * 2);
            //        //g.FillEllipse(new SolidBrush(btn_color.BackColor), -float.Parse(textBox2.Text), -float.Parse(textBox2.Text), float.Parse(textBox2.Text) * 2, float.Parse(textBox2.Text) * 2);
            //        datalist dp = new datalist(datalist.MyElenent.point, pen, _center.X - radius, _center.Y - radius, radius * 2, radius * 2, false, background, new SolidBrush(btn_color.BackColor));
            //        list.Add(dp);
            //        textBox1.Text = list.Count.ToString();
            //        pictureBox1.Invalidate();
            //    }
            //}

            //////////////////////////////////////////////////////////////////

            if (drawline && startPaint || drawline)
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
                Finish1 = e.Location;
                ////pictureBox1.Invalidate();
                ////if (!flag)
                ////{
                ////    g.DrawRectangle(new Pen(Color.Bisque, 5), initX, initY, e.X, e.Y);

                ////}
                ////if (flag)
                ////{
                ////    if (checkBox1.CheckState == CheckState.Checked)
                ////    {
                ////        b = true;
                ////    }
                ////    else
                ////    {
                ////        b = false;
                ////    }

                ////    datalist dr = new datalist(datalist.MyElenent.rectangle, pen, initX, initY, endX, endY, b, background, new SolidBrush(btn_back_color.BackColor));
                ////    list.Add(dr);
                ////    flag = false;
                ////}
                ////textBox1.Text = list.Count.ToString();

            
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
                    //datalist dr = new datalist(datalist.MyElenent.circle, initX, initY, endX, endY);
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
                textBox1.Text = list.Count.ToString();
                pictureBox1.Invalidate();

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
                    datalist dr = new datalist(datalist.MyElenent.circle, pen, initX - radius, initY - radius, radius * 2, radius * 2, b, background, new SolidBrush(btn_back_color.BackColor));
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
                    e.Graphics.FillEllipse(list[i].solidBrush, list[i].StartX, list[i].StartY, list[i].EndX, list[i].EndY);
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
            if (btn_color.BackColor == pictureBox1.BackColor)
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
