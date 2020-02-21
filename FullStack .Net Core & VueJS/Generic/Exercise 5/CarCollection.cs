using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_5
{
    public class CarCollection<T> where T : Car, new()
    {
        private List<T> listCars;
        public void Add(string NameCar, Int32 AgeCar)
        {
            if (listCars == null)
            {
                listCars = new List<T>();
                T tmpCar = new T();
                tmpCar.NameCar = NameCar;
                tmpCar.AgeCar = AgeCar;
                listCars.Add(tmpCar);
            }
            else
            {
                T tmpCar = new T();
                tmpCar.NameCar = NameCar;
                tmpCar.AgeCar = AgeCar;
                listCars.Add(tmpCar);
            }
        }

        public T this[Int32 index]
        {
            get { return listCars[index]; }
        }

        public Int32 Count
        {
            get
            {
                return listCars.Count;
            }
        }

        public void RemoveAllCars()
        {
            listCars = null;
        }


    }
}
