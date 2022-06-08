using System;

namespace GenericArrayCreator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var numbers = ArrayCreator.Create(10, 6);

            var texts = ArrayCreator.Create(10, "Oleg");

            Console.WriteLine(string.Join(" ", numbers));
            Console.WriteLine(string.Join(" ", texts));
        }
    }
}
