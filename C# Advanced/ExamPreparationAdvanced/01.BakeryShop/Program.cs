using System;
using System.Linq;
using System.Collections.Generic;

namespace _01.BakeryShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] water = Console.ReadLine().Split().Select(double.Parse).ToArray();
            double[] flour = Console.ReadLine().Split().Select(double.Parse).ToArray();

            Queue<double> queueWater = new Queue<double>(water);
            Stack<double> stackFlour = new Stack<double>(flour);

            Dictionary<string, double> delicious = new Dictionary<string, double>
        {
            {"Croissant", 0},
            {"Muffin", 0},
            {"Baguette", 0},
            {"Bagel", 0},
        };
            while (queueWater.Count > 0 && stackFlour.Count > 0)
            {
                double currWater = queueWater.Peek();
                double currFlour = stackFlour.Peek();
                double ratio = (currWater * 100) / (currWater + currFlour);
                if (ratio == 50)
                {
                    delicious["Croissant"]++;
                    queueWater.Dequeue();
                    stackFlour.Pop();
                }
                else if (ratio == 40)
                {
                    delicious["Muffin"]++;
                    queueWater.Dequeue();
                    stackFlour.Pop();
                }
                else if (ratio == 30)
                {
                    delicious["Baguette"]++;
                    queueWater.Dequeue();
                    stackFlour.Pop();
                }
                else if (ratio == 20)
                {
                    delicious["Bagel"]++;
                    queueWater.Dequeue();
                    stackFlour.Pop();
                }
                else
                {
                    queueWater.Dequeue();
                    double difference = currFlour - currWater;
                    stackFlour.Pop();
                    stackFlour.Push(difference);
                    delicious["Croissant"]++;
                }
            }
            foreach (var item in delicious.OrderByDescending(b => b.Value).ThenBy(a => a.Key))
            {
                if (item.Value > 0)
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
            }
            if (queueWater.Count == 0)
            {
                Console.WriteLine("Water left: None");
            }
            else
            {
                Console.WriteLine("Water left: " + String.Join(", ", queueWater));
            }
            if (stackFlour.Count == 0)
            {
                Console.WriteLine("Flour left: None");
            }
            else
            {
                Console.WriteLine("Flour left: " + String.Join(", ", stackFlour));
            }
        }
    }
}