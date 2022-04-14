using System;
using System.Linq;
using System.Collections.Generic;

namespace Exe02._A_Miner_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, long> resources = new Dictionary<string, long>();

            string resource;
            while ((resource = Console.ReadLine()) != "stop")
            {
                int quantity = int.Parse(Console.ReadLine());

                if (resources.ContainsKey(resource))
                {
                    resources[resource] += quantity;
                }
                else
                {
                    resources.Add(resource, quantity);
                }
            }
            foreach (var rqp in resources)
            {
                Console.WriteLine($"{rqp.Key} -> {rqp.Value}");
            }
        }
    }
}
