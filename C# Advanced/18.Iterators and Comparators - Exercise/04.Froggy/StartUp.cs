using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace _04.Froggy
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var lake = new Lake(Console.ReadLine().Split(", ")
                .Select(int.Parse).ToArray());
            Console.WriteLine(String.Join(", ", lake));
        }
    }
}
