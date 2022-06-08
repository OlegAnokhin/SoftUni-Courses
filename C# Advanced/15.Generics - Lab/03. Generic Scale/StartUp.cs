using System;

namespace GenericScale
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var areEquals = EqualityScale<int>.AreEqual(1, 1);
            var areEquals2 = EqualityScale<string>.AreEqual("Oleg", "Oleg");
            Console.WriteLine(areEquals);
            Console.WriteLine(areEquals2);

        }
    }
}
