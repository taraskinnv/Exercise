using System;
using System.Collections.Generic;
using System.Text;

namespace exercise_8
{
    class Invoice
    {
        public readonly int account;
        public readonly string customer;
        public readonly string provider;
        public List<Product> products;

        public Invoice(int account, string customer, string provider)
        {
            this.account = account;
            this.customer = customer;
            this.provider = provider;
            products = new List<Product>();
        }

        public Double GetSumWithNDS()
        {
            Double sum = 0;

            for (int i = 0; i < products.Count; i++)
            {
                sum = products[i].GetSum();
            }

            return sum * 1.2;
        }

        public Double GetSumWithoutNDS()
        {
            Double sum = 0;

            for (int i = 0; i < products.Count; i++)
            {
                sum = products[i].GetSum();
            }

            return sum;
        }

    }


    
}
