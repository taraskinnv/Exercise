using System;
using System.Collections.Generic;
using System.Text;

namespace exercise_8
{

    class Product
    {
        private string article;
        private int quantity;
        private Double price;
        public Product(string article, Double price, int quantity)
        {
            this.article = article;
            this.quantity = quantity;
            this.price = price;
        }

        public Double GetSum()
        {
            return quantity * price;
        }
    }
}

