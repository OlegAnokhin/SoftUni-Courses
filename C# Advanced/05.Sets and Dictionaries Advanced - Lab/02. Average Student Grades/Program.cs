﻿using System;
using System.Linq;
using System.Collections.Generic;

namespace _02._Average_Student_Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var studentGrades = new Dictionary<string, List<decimal>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ');

                string name = input[0];
                decimal grade = decimal.Parse(input[1]);
                if (!studentGrades.ContainsKey(name))
                {
                    studentGrades.Add(name, new List<decimal>());
                }
                studentGrades[name].Add(grade);
            }
            foreach (var name in studentGrades.Keys)
            {
                List<decimal> grades = studentGrades[name];
                string gradesStr = string.Join(" ", grades.Select(g => g.ToString("f2")));
                decimal avg = grades.Average();
                Console.WriteLine($"{name} -> {gradesStr} (avg: {avg:f2})");
            }
        }
    }
}
