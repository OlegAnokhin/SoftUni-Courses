using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace EXE_03._SoftUni_Bar_Income
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double totalIncome = 0;
            string patern = @"\%(?<client>[A-Z]{1}[a-z]+)\%[^%$|.]*?\<(?<product>\w+)\>[^%$|.]*?\|(?<count>\d+)\|[^%$|.]*?(?<price>\d+(\.\d+)?)\$";
            string input;

            while ((input = Console.ReadLine()) != "end of shift")
            {
                Match orderInfo = Regex.Match(input, patern);
                if (orderInfo.Success)
                {
                    string client = orderInfo.Groups["client"].Value;
                    string product = orderInfo.Groups["product"].Value;
                    int count = int.Parse(orderInfo.Groups["count"].Value);
                    double price = double.Parse(orderInfo.Groups["price"].Value);

                    double totalPrice = count * price;
                    totalIncome += totalPrice;
                    Console.WriteLine($"{client}: {product} - {totalPrice:f2}");
                }
            }
            Console.WriteLine($"Total income: {totalIncome:f2}");
        }
    }
}
