namespace P03.DetailPrinter
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Employee
    {
        public Employee(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
        public override string ToString()
        {
            return $"Name: {Name}";
        }
    }
}