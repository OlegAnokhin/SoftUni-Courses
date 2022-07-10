namespace _06.FoodShortage
{
    using System;
    using System.Linq;
    using _06.FoodShortage.Models;
    using System.Collections.Generic;
    using _06.FoodShortage.Interfaces;
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBuyer> buyers = new List<IBuyer>();
            int countOfBuyers = int.Parse(Console.ReadLine());
            for (int i = 0; i < countOfBuyers; i++)
            {
                string[] input = Console.ReadLine().Split();
                if (input.Length == 4)
                {
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string id = input[2];
                    string birthdate = input[3];
                    buyers.Add(new Citizen(name, age, id, birthdate));
                }
                else if (input.Length == 3)
                {
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string group = input[2];
                    buyers.Add(new Rebel(name, age, group));
                }
            }
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                var buyer = buyers.FirstOrDefault(n => n.Name == command);
                if (buyer != null)
                {
                    buyer.BuyFood();
                }
            }
            Console.WriteLine(buyers.Sum(b => b.Food));
        }
    }
}