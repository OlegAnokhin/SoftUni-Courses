using System;
using System.Linq;
using System.Collections.Generic;

namespace _03.ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries);
            List<Person> persons = new List<Person>();
            List<Product> products = new List<Product>();
            foreach (var pair in input)
            {
                var nameAndMoney = pair.Split("=");
                try
                {
                    persons.Add(new Person(nameAndMoney[0], double.Parse(nameAndMoney[1])));
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    return;
                }
            }
            input = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries);
            foreach (var pair in input)
            {
                var nameAndCost = pair.Split("=");
                try
                {
                    products.Add(new Product(nameAndCost[0], double.Parse(nameAndCost[1])));
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    return;
                }
            }
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                var pair = command.Split();
                string personName = pair[0];
                string productName = pair[1];
                var person = persons.First(p => p.Name == personName);
                var product = products.First(p => p.Name == productName);
                if (!person.BuyProduct(product))
                {
                    Console.WriteLine($"{person.Name} can't afford {product.Name}");
                }
                else
                {
                    Console.WriteLine($"{person.Name} bought {product.Name}");
                }
            }
            foreach (var person in persons)
            {
                string productsBought = person
                    .Products.Count == 0 ? "Nothing bought" : 
                     String.Join(", ", person.Products.Select(p => p.Name));
                Console.WriteLine($"{person.Name} - {productsBought}");
            }
        }
    }
}