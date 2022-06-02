using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person person1 = new Person();

            Person person2 = new Person(20);

            Person person3 = new Person("Peter", 25);
        }
    }
}
