using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_1
{
    class Address
    {
        private Int32 index;
        private String country;
        private String city;
        private String street;
        private Int32 house;
        private Int32 apartment;

        public String Country
        {
            get { return country; }
            set { country = value; }
        }

        public String City
        {
            get { return city; }
            set { city = value; }
        }

        public String Street
        {
            get { return street; }
            set { street = value; }
        }

        public Int32 Index
        {
            get { return index; }
            set { index = value; }
        }

        public Int32 House
        {
            get { return house; }
            set { house = value; }
        }
        
        public Int32 Apartment
        {
            get { return apartment; }
            set { apartment = value; }
        }




    }
}
