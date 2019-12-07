using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_4
{
    class Point
    {
        private Int32 x;
        private Int32 y;
        private String myStr;

        public int X
        {
            get { return x; }
        }

        public int Y
        {
            get { return y; }
        }

        public string MyStr
        {
            get { return myStr; }
        }

        public Point(Int32 x, Int32 y, String myStr)
        {
            this.x = x;
            this.y = y;
            this.myStr = myStr;
        }

    }
}
