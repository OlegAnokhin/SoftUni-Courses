using System;
using System.Linq;
using System.Collections.Generic;

namespace _004._Students
{
    class Student
    {
        public Student(string firstName, string lastName, int age, string homeTown)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Hometown = homeTown;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Hometown { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            List<Student> students = new List<Student>();

            while (command != "end")
            {
                string[] splitParams = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string firstName = splitParams[0];
                string lastName = splitParams[1];
                int age = int.Parse(splitParams[2]);
                string hometown = splitParams[3];

                bool doesStudentExist = DoesStudentExsist(students, firstName, lastName);

                if (doesStudentExist)
                {
             //       Student existingStudent = GetExistingStudent(students, firstName, lastName);

                    Student existingStudent = students.FirstOrDefault(student => student.FirstName == 
                    firstName && student.LastName == lastName);

                    existingStudent.FirstName = firstName;
                    existingStudent.LastName = lastName;
                    existingStudent.Age = age;
                    existingStudent.Hometown = hometown;
                }
                else
                {
                    Student newStudent = new Student(firstName, lastName, age, hometown);
                    students.Add(newStudent);
                }

                command = Console.ReadLine();
            }
            string hometownToSearch = Console.ReadLine();
            List<Student> filtred = students.FindAll(student =>
            student.Hometown == hometownToSearch);

            foreach (Student student in filtred)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
            }
        }

        //static Student GetExistingStudent(List<Student> students, string firstName, string lastName)
        //{
        //    foreach (Student student in students)
        //    {
        //        if (student.FirstName == firstName && student.LastName == lastName)
        //        {
        //            return student;
        //        }
        //    }
        //        return null;
        //}

        static bool DoesStudentExsist(List<Student> students, string firstName, string lastName)
        {
            foreach (Student student in students)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
