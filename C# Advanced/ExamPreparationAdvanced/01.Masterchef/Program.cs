using System;
using System.Linq;
using System.Collections.Generic;

namespace _01.Masterchef
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] ingredients = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int[] freshness = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            Queue<int> queueIngred = new Queue<int>(ingredients);
            Stack<int> stackFresh = new Stack<int>(freshness);
            Dictionary<string, int> dishes = new Dictionary<string, int>
        {
            {"Dipping sauce", 0},
            {"Green salad", 0},
            {"Chocolate cake", 0},
            {"Lobster", 0},
        };
            while (queueIngred.Count > 0 && stackFresh.Count > 0)
            {
                int currIngred = queueIngred.Peek();
                int currFresh = stackFresh.Peek();
                if (currIngred == 0)
                {
                    queueIngred.Dequeue();
                    continue;
                }
                int sum = currIngred * currFresh;
                if (sum == 150)
                {
                    dishes["Dipping sauce"]++;
                    queueIngred.Dequeue();
                    stackFresh.Pop();
                }
                else if (sum == 250)
                {
                    dishes["Green salad"]++;
                    queueIngred.Dequeue();
                    stackFresh.Pop();
                }
                else if (sum == 300)
                {
                    dishes["Chocolate cake"]++;
                    queueIngred.Dequeue();
                    stackFresh.Pop();
                }
                else if (sum == 400)
                {
                    dishes["Lobster"]++;
                    queueIngred.Dequeue();
                    stackFresh.Pop();
                }
                else
                {
                    stackFresh.Pop();
                    currIngred += 5;
                    queueIngred.Dequeue();
                    queueIngred.Enqueue(currIngred);
                }
            }
            int dishCount = 0;
            foreach (var dish in dishes)
            {
                if (dish.Value > 0)
                {
                    dishCount++;
                }
            }
            if (dishCount == 4)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
                if (queueIngred.Count > 0)
                {
                    Console.WriteLine($"Ingredients left: {queueIngred.Sum()}");
                }
            }
            foreach (var dish in dishes.OrderBy(s => s.Key))
            {
                if (dish.Value > 0)
                {
                    Console.WriteLine($"# {dish.Key} --> {dish.Value}");
                }
            }
        }
    }
}