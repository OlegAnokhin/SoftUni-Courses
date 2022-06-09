using System;

namespace Box
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            var personInfo = Console.ReadLine().Split();
            var fullName = $"{personInfo[0]} {personInfo[1]}";
            var address = $"{personInfo[2]}";
            var city = personInfo.Length > 4 ? $"{personInfo[3]} {personInfo[4]}" :
                $"{personInfo[3]}";

            var nameAndBeer = Console.ReadLine().Split();
            var name = nameAndBeer[0];
            var numberOfLiters = int.Parse(nameAndBeer[1]);
            bool isDrunken = nameAndBeer[2] == "drunk" ? true : false;

            var nameAndBanK = Console.ReadLine().Split();
            var nameFromBank = nameAndBanK[0];
            var accountBalance = double.Parse(nameAndBanK[1]);
            var bankName = nameAndBanK[2];

            Threeuple<string, string, string> firstTuple = 
                new Threeuple<string, string, string>(fullName, address, city);
            Threeuple<string, int, bool> secondTuple = 
                new Threeuple<string, int, bool>(name, numberOfLiters, isDrunken);
            Threeuple<string, double, string> thirdTuple = 
                new Threeuple<string, double, string>(nameFromBank, accountBalance, bankName);

            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);
        }
    }
}
