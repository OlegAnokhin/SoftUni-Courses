using System;
using System.Collections.Generic;
using System.Linq;

namespace Exe05._SoftUni_Parking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> parkingRegistrer = new Dictionary<string, string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] cmdArg = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string cmdType = cmdArg[0];
                string username = cmdArg[1];

                if (cmdType == "register")
                {
                    string licencePlateNumber = cmdArg[2];
                    RegisterUser(parkingRegistrer, username, licencePlateNumber);
                }
                else if (cmdType == "unregister")
                {
                    UnRegisterUser(parkingRegistrer, username);
                }
            }
            foreach (var kvp in parkingRegistrer)
            {
                string username = kvp.Key;
                string licencePlateNumber = kvp.Value;
                Console.WriteLine($"{username} => {licencePlateNumber}");
            }
        }
        static void RegisterUser(Dictionary<string, string> parkingRegistrer,
            string username, string licencePlateNumber)
        {
            if (parkingRegistrer.ContainsKey(username))
            {
                string licenseNumberRegistred = parkingRegistrer[username];
                Console.WriteLine($"ERROR: already registered with plate number {licenseNumberRegistred}");
            }
            else
            {
                parkingRegistrer[username] = licencePlateNumber;
                Console.WriteLine($"{username} registered {licencePlateNumber} successfully");
            }
        }
        static void UnRegisterUser(Dictionary<string, string> parkingRegistrer,
            string username)
        {
            if (!parkingRegistrer.ContainsKey(username))
            {
                Console.WriteLine($"ERROR: user {username} not found");
            }
            else
            {
                parkingRegistrer.Remove(username);
                Console.WriteLine($"{username} unregistered successfully");
            }
        }
    }
}
