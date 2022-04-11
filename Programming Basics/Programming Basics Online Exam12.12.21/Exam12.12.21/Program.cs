using System;

namespace _001._Cat_Diet
{
    class Program
    {
        static void Main(string[] args)
        {
                int percentageOfFat = int.Parse(Console.ReadLine());
                int percentageOfProtein = int.Parse(Console.ReadLine());
                int percentageOfCarb = int.Parse(Console.ReadLine());
                int totalCalories = int.Parse(Console.ReadLine());
                int waterContent = int.Parse(Console.ReadLine());

                double gramOfFat = (totalCalories * percentageOfFat / 100) / 9.0;
                double gramOfProtein = (totalCalories * percentageOfProtein / 100) / 4.0;
                double gramOfCarb = (totalCalories * percentageOfCarb / 100) / 4.0;
                double gramFood = gramOfFat + gramOfProtein + gramOfCarb;
                double caloriesOfGram = totalCalories / gramFood;
                double calories = caloriesOfGram * waterContent / 100;

                Console.WriteLine($"{caloriesOfGram - calories:F4}");
            }
        }
    }
