using System;
using System.Collections.Generic;
using System.Linq;

namespace Exe07._Student_Academy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> allstudents = new Dictionary<string, List<double>>();

            int rows = int.Parse(Console.ReadLine());

            for (int i = 0; i < rows; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!allstudents.ContainsKey(name))
                {
                    allstudents[name] = new List<double>();
                }
                allstudents[name].Add(grade);
            }
            foreach (var kvp in allstudents)
            {
                string courseName = kvp.Key;
                List<double> students = kvp.Value;
                double averageGrade = students.Average();
                if (averageGrade >= 4.50)
                {
                    Console.WriteLine($"{courseName} -> {averageGrade:f2}");
                }
            }
        }
    }
}
