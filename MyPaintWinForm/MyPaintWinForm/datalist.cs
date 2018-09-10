using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPaintWinForm
{
    public class datalist
    {
        public enum MyElenent
        {
            point,
            line,
            rectangle,
            circle
        }
        public float StartX { get; set; }
        public float StartY { get; set; }
        public float EndX { get; set; }
        public float EndY { get; set; }
        public float SizePen { get; set; }
        public Pen MyPen { get; set; }
        public MyElenent myElenent { get; set; }
        public SolidBrush solidBrush { get; set; }
        public bool ColorContour { get; set; }
        public bool ColorBackGround { get; set; }
        public datalist(datalist.MyElenent el,Pen pen, float startX, float startY, float endX, float endY,bool colorContour = true, bool colorBackGround = false, SolidBrush solid = null)
        {
            switch (el)
            {
                case MyElenent.point:
                    MyPen = pen;
                    StartX = startX;
                    StartY = startY;
                    EndX = endX;
                    EndY = endY;
                    myElenent = el;
                    solidBrush = solid;
                    ColorBackGround = colorBackGround;
                    break;
                case MyElenent.line:
                    MyPen = pen;
                    StartX = startX;
                    StartY = startY;
                    EndX = endX;
                    EndY = endY;
                    myElenent = el;
                    break;
                case MyElenent.rectangle:
                    MyPen = pen;
                    StartX = startX;
                    StartY = startY;
                    EndX = endX;
                    EndY = endY;
                    myElenent = el;
                    solidBrush = solid;
                    ColorContour = colorContour;
                    ColorBackGround = colorBackGround;
                    break;
                case MyElenent.circle:
                    MyPen = pen;
                    StartX = startX;
                    StartY = startY;
                    EndX = endX;
                    EndY = endY;
                    myElenent = el;
                    solidBrush = solid;
                    ColorContour = colorContour;
                    ColorBackGround = colorBackGround;
                    break;
                default:
                    break;
            }
        }
    }
}
