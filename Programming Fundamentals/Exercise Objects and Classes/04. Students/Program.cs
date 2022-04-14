using System;
using System.Linq;
using System.Collections.Generic;

namespace _04._Students
{
    class Student
    {
        public Student(string firstName, string lastName, double grade)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Grade = grade;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName}: {this.Grade:f2}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            int countOfAllStudents = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfAllStudents; i++)
            {
                string[] studentArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string currentfirstName = studentArgs[0];
                string currentlastName = studentArgs[1];
                double currentgrade = double.Parse(studentArgs[2]);
                Student currentstudent =
                    new Student(currentfirstName, currentlastName, currentgrade);
                students.Add(currentstudent);
            }
            List<Student> orderedStudents = students
                .OrderByDescending(s => s.Grade).ToList();

            foreach (Student student in orderedStudents)
            {
                Console.WriteLine(student);
            }
        }
    }
}
