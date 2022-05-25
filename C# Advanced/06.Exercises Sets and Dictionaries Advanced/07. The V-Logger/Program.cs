using System;
using System.Linq;
using System.Collections.Generic;

namespace _07._The_V_Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> followers = 
                new Dictionary<string, List<string>>();

            followers.OrderBy(entry => entry.Value.Count);

            Dictionary<string, List<string>> followings = 
                new Dictionary<string, List<string>>();

            followings.OrderByDescending(entry => entry.Value.Count).ThenBy(entry => entry.Key);

        }
    }
}
