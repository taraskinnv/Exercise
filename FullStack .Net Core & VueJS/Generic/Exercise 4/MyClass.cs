using Exercise_2;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_4
{
    public static class MyClass
    {
        public static T[] GetArray<T>(this MyList<T> list)
        {
            T[] arr = new T[list.Count];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = list[i];
            }
            return arr;
        }
    }
}
