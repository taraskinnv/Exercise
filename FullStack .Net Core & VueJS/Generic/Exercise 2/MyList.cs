using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_2
{
    public class MyList<T>
    {
        private T[] mas;

        public void Add(T item)
        {
            mas = Copy(mas);
            mas[mas.Length - 1] = item;
        }

        public T this[int index]
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

        private T[] Copy(T[] arr)
        {
            T[] temp;
            if (arr == null)
            {
                return temp = new T[1];
            }
            else
            {
                temp = new T[arr.Length + 1];
                for (int i = 0; i < arr.Length; i++)
                {
                    temp[i] = arr[i];
                }

                return temp;
            }
        }
    }
}
