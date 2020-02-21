using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_3
{
    public class MyDictionary<TKey, TValue>
    {
        private TKey[] keyArr;
        private TValue[] valueArr;

        public void Add(TKey tkey, TValue tvalue)
        {
            if (keyArr != null)
            {
                foreach (TKey key in keyArr)
                {
                    if (key.Equals(tkey))
                    {
                        throw new Exception("Key must be unique!!!");
                    }
                }
            }

            keyArr = Copy(keyArr);
            keyArr[keyArr.Length - 1] = tkey;
            valueArr = Copy(valueArr);
            valueArr[valueArr.Length - 1] = tvalue;
        }

        public TValue this[TKey key]
        {
            get
            {
                for (int i = 0; i < keyArr.Length; i++)
                {
                    if (keyArr[i].Equals(key))
                    {
                        return valueArr[i];
                    }
                }
                throw new Exception("NOT FOUND");
            }
            set
            {
                for (int i = 0; i < keyArr.Length; i++)
                {
                    if (keyArr[i].Equals(key))
                    {
                        valueArr[i] = value;
                        return;
                    }
                }
                throw new Exception("NOT FOUND");
            }
        }

        public Int32 Count
        {
            get
            {
                if (keyArr == null)
                {
                    return 0;
                }
                else
                {
                    return keyArr.Length;
                }
            }
        }

        private T[] Copy<T>(T[] arr)
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
