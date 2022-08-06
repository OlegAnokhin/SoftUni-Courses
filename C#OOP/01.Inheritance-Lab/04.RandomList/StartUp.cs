using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var randomList = new RandomList();
            randomList.Add("randomOne");
            randomList.Add("randomTwo");

            Console.WriteLine(string.Join(", ", randomList));

            randomList.RandomString();
            Console.WriteLine(string.Join(", ", randomList));
        }
    }
}