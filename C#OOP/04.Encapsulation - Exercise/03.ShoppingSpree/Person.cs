using System;
using System.Text;
using System.Collections.Generic;

namespace _03.ShoppingSpree
{
    public class Person
    {
        private string name;
        private double money;
        private List<Product> products;
        public Person(string name, double money)
        {
            this.Name = name;
            this.Money = money;
            this.products = new List<Product>();
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                this.name = value;
            }
        }
        public double Money
        {
            get
            {
                return money;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.money = value;
            }
        }
        public IReadOnlyCollection<Product> Products
        {
            get
            {
                return this.products;
            }
        }
        public bool BuyProduct(Product product)
        {
            if (this.money >= product.Cost)
            {
                this.money -= product.Cost;
                this.products.Add(product);
                return true;
            }
            return false;
        }
    }
}