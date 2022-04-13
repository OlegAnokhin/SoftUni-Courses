//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace MidExam20_02_2022
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//           // PR.01 Burger Bus

//            int numberOfSities = int.Parse(Console.ReadLine());
//            int sityCount = 0;
//            decimal totalProfit = 0;

//            for (int i = 0; i < numberOfSities; i++)
//            {
//                string cityName = Console.ReadLine();
//                decimal income = decimal.Parse(Console.ReadLine());
//                decimal ownerExpenses = decimal.Parse(Console.ReadLine());
//                decimal profit = 0;
//                decimal thirdSity = 0;
//                sityCount++;

//                if (sityCount % 3 == 0)
//                {
//                    thirdSity = ownerExpenses /= 2;
//                    income -= thirdSity;

//                }
//                if (sityCount % 5 == 0)
//                {
//                    income *= 0.9m;
//                }

//                profit = income - ownerExpenses - thirdSity;
//                totalProfit += profit;

//                Console.WriteLine($"In {cityName} Burger Bus earned {profit:f2} leva.");
//            }
//            Console.WriteLine($"Burger Bus total profit: {totalProfit:f2} leva.");
//        }
//    }
//}


//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace MidExam20_02_2022
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            // PR.02 Tax Calculator

//            List<string> input = Console.ReadLine()
//                .Split(">>", StringSplitOptions.RemoveEmptyEntries)
//                .ToList();

//            double totatlTax = 0;

//            for (int i = 0; i < input.Count; i++)
//            {
//                string command = input[i];
//                string[] type = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

//                string typeCar = type[0];
//                int years = int.Parse(type[1]);
//                int traveledKM = int.Parse(type[2]);
//                double willPay = 0;

//                if (typeCar != "family" && typeCar != "heavyDuty" && typeCar != "sports")
//                {
//                    Console.WriteLine("Invalid car type.");
//                    continue;
//                }
//                else if (typeCar == "family")
//                {
//                    double KM = Math.Abs(traveledKM / 3000);
//                    willPay = KM * 12 + (50 - (years * 5));
//                    totatlTax += willPay;
//                }
//                else if (typeCar == "heavyDuty")
//                {
//                    double KM = Math.Abs(traveledKM / 9000);
//                    willPay = KM * 14 + (80 - (years * 8));
//                    totatlTax += willPay;
//                }
//                else if (typeCar == "sports")
//                {
//                    double KM = Math.Abs(traveledKM / 2000);
//                    willPay = KM * 18 + (100 - (years * 9));
//                    totatlTax += willPay;
//                }
//                Console.WriteLine($"A {typeCar} car will pay {willPay:F2} euros in taxes.");
//            }
//            Console.WriteLine($"The National Revenue Agency will collect {totatlTax:F2} euros in taxes.");
//        }
//    }
//}


using System;
using System.Collections.Generic;
using System.Linq;

namespace MidExam20_02_2022
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // PR.03 The Angry Cat

            List<double> priceRating = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToList();

            int entryPoint = int.Parse(Console.ReadLine());

            string typeItems = Console.ReadLine();

            double leftSum = 0;
            double rightSum = 0;
            string position = string.Empty;

            if (typeItems == "cheap")
            {
                for (int i = 0; i < entryPoint; i++)
                {
                    if (priceRating[i] < priceRating[entryPoint])
                    {
                        leftSum += priceRating[i];
                    }
                }
                for (int i = entryPoint + 1; i < priceRating.Count; i++)
                {
                    if (priceRating[i] < priceRating[entryPoint])
                    {
                        rightSum += priceRating[i];
                    }
                }
                if (leftSum == rightSum)
                {
                    position = "Left";
                    Console.WriteLine($"{position} - {leftSum}");
                }
                else if (leftSum > rightSum)
                {
                    position = "Left";
                    Console.WriteLine($"{position} - {leftSum}");
                }
                else if (leftSum < rightSum)
                {
                    position = "Right";
                    Console.WriteLine($"{position} - {rightSum}");
                }
            }
            else if (typeItems == "expensive")
            {
                for (int i = 0; i < entryPoint; i++)
                {
                    if (priceRating[i] >= priceRating[entryPoint])
                    {
                        leftSum += priceRating[i];
                    }
                }
                for (int i = entryPoint + 1; i < priceRating.Count; i++)
                {
                    if (priceRating[i] >= priceRating[entryPoint])
                    {
                        rightSum += priceRating[i];
                    }
                }
                if (leftSum == rightSum)
                {
                    position = "Left";
                    Console.WriteLine($"{position} - {leftSum}");
                }
                else if (leftSum > rightSum)
                {
                    position = "Left";
                    Console.WriteLine($"{position} - {leftSum}");
                }
                else if (leftSum < rightSum)
                {
                    position = "Right";
                    Console.WriteLine($"{position} - {rightSum}");
                }
            }
        }
    }
}

