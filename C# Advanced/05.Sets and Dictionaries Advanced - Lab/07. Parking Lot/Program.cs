using System;
using System.Collections.Generic;

namespace _07._Parking_Lot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            HashSet<string> parking = new HashSet<string>();

            while (input != "END")
            {
                string[] cmdArg = input.Split(", ");
                string cmd = cmdArg[0];
                string number = cmdArg[1];

                if (cmd == "IN")
                {
                    parking.Add(number);
                }
                else
                {
                    parking.Remove(number);
                }
                input = Console.ReadLine();
            }
            if (parking.Count > 0)
            {
                foreach (string numbers in parking)
                {
                    Console.WriteLine(numbers);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
