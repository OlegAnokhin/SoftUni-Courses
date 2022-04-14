using System;
using System.Collections.Generic;
using System.Linq;

namespace Exe04._Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var priceAndProduct = new Dictionary<string, double>();
            var countAndProduct = new Dictionary<string, int>();
            string input;

            while ((input = Console.ReadLine()) != "buy")
            {
                string[] tokens = input.Split(' ').ToArray();
                string product = tokens[0];
                double price = double.Parse(tokens[1]);
                int quantity = int.Parse(tokens[2]);

                if (!countAndProduct.ContainsKey(product))
                {
                    countAndProduct[product] = 0;
                }

                countAndProduct[product] += quantity;

                if (!priceAndProduct.ContainsKey(product))
                {
                    priceAndProduct[product] = 0;
                }

                priceAndProduct[product] = price;
            }

            foreach (var kvp in countAndProduct)
            {
                string product = kvp.Key;
                int quantity = kvp.Value;
                double price = priceAndProduct[product];

                double result = quantity * price;
                Console.WriteLine($"{product} -> {result:f2}");
            }
        }
    }
}