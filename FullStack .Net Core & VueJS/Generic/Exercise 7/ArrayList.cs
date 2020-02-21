using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_7
{
    public class ArrayList
    {
        private Object[] mas;

        public void Add(Object item)
        {
            mas = Copy(mas);
            mas[mas.Length - 1] = item;
        }

        public Object this[int index]
        {
            get { return mas[index]; }
            set { mas[index] = value; }
        }

        public Int32 Count
        {
            get
            {
                if (mas == null)
                {
                    return 0;
                }
                return mas.Length;
            }
        }

        private Object[] Copy(Object[] arr)
        {
            Object[] temp;
            if (arr == null)
            {
                return temp = new Object[1];
            }
            else
            {
                temp = new Object[arr.Length + 1];
                for (int i = 0; i < arr.Length; i++)
                {
                    temp[i] = arr[i];
                }

                return temp;
            }
        }
    }
}
