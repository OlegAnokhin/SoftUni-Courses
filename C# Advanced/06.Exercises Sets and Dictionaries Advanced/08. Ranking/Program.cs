using System;
using System.Linq;
using System.Collections.Generic;

namespace _08._Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, int>> students = 
                new SortedDictionary<string, Dictionary<string, int>>();




            foreach (var studentEntry in students)
            {
                Dictionary<string , int> courses = studentEntry.Value; 
                courses.OrderByDescending(entry => entry.Value);
            }
        }
    }
}
