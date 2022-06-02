using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person person = new Person("Peter", 20);

            Person person2 = new Person();
            person2.Name = "George";
            person2.Age = 18;
        }
    }
}
