using System;
using System.Text;
using System.Collections.Generic;

namespace PersonsInfo
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;
        public Person(string firstName, string lastName, int age, decimal salary)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.salary = salary;
        }
        public string FirstName { get { return firstName; } }
        public string LastName { get { return lastName; } }
        public int Age { get { return this.age; } }
        public decimal Salary { get { return this.salary; } }
    }
}