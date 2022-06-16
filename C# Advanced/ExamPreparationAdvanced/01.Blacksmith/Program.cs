using System;
using System.Linq;
using System.Collections.Generic;

namespace _01.Blacksmith
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] steel = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] carbon = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> queueSteel = new Queue<int>(steel);
            Stack<int> stackCarbon = new Stack<int>(carbon);

            Dictionary<string, int> swords = new Dictionary<string, int>
        {
            {"Broadsword", 0},
            {"Sabre", 0},
            {"Katana", 0},
            {"Shamshir", 0},
            {"Gladius", 0}
        };
            int totalSwords = 0;
            while (queueSteel.Count > 0 && stackCarbon.Count > 0)
            {
                int currSteel = queueSteel.Peek();
                int currCarbon = stackCarbon.Peek();
                int sum = currSteel + currCarbon;
                if (sum == 70)
                {
                    swords["Gladius"]++;
                    queueSteel.Dequeue();
                    stackCarbon.Pop();
                    totalSwords++;
                }
                else if (sum == 80)
                {
                    swords["Shamshir"]++;
                    queueSteel.Dequeue();
                    stackCarbon.Pop();
                    totalSwords++;
                }
                else if (sum == 90)
                {
                    swords["Katana"]++;
                    queueSteel.Dequeue();
                    stackCarbon.Pop();
                    totalSwords++;
                }
                else if (sum == 110)
                {
                    swords["Sabre"]++;
                    queueSteel.Dequeue();
                    stackCarbon.Pop();
                    totalSwords++;
                }
                else if (sum == 150)
                {
                    swords["Broadsword"]++;
                    queueSteel.Dequeue();
                    stackCarbon.Pop();
                    totalSwords++;
                }
                else
                {
                    queueSteel.Dequeue();
                    currCarbon += 5;
                    stackCarbon.Pop();
                    stackCarbon.Push(currCarbon);
                }
            }
            if (totalSwords >= 1)
            {
            Console.WriteLine($"You have forged {totalSwords} swords.");
            }
            else
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }
            if (queueSteel.Count == 0)
            {
                Console.WriteLine("Steel left: none");
            }
            else
            {
                Console.WriteLine("Steel left: " + String.Join(", ", queueSteel));
            }
            if (stackCarbon.Count == 0)
            {
                Console.WriteLine("Carbon left: none");
            }
            else
            {
                Console.WriteLine("Carbon left: " + String.Join(", ", stackCarbon));
            }
            foreach(var swordItem in swords.OrderBy(s => s.Key))
            {
                if (swordItem.Value > 0)
                {
                    Console.WriteLine($"{swordItem.Key}: {swordItem.Value}");
                }
            }
        }
    }
}