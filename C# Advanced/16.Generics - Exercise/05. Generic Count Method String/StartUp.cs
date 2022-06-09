using System;
using System.Collections.Generic;
using System.Linq;

namespace Box
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var list = new List<string>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                list.Add(input);
            }
            var box = new Box<string>(list);
            var elementToCompare = Console.ReadLine();
            var count = box.CountsOfGreaterElements(list, elementToCompare);

            Console.WriteLine(count);
        }
    }
}
