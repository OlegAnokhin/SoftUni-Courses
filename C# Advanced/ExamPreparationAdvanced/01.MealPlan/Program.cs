using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace MealPlan
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> mealsCalories = new Dictionary<string, int>
        {
            {"salad", 350},
            {"soup", 490},
            {"pasta", 680},
            {"steak", 790}
        };
            Queue<string> meals = new Queue<string>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries));
            Stack<int> calories = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            int startMealsCount = meals.Count;
            while ((meals.Count > 0) && (calories.Count > 0))
            {
                int currCallories = calories.Pop();

                int currentMealCallories = mealsCalories[meals.Peek()];

                if (currCallories - currentMealCallories >= 0)
                {
                    currCallories -= currentMealCallories;
                    meals.Dequeue();
                    calories.Push(currCallories);
                }
                else if (calories.Count > 0)
                {
                    currCallories -= currentMealCallories;
                    currCallories += calories.Pop();
                    if (currCallories > 0)
                    {
                        calories.Push(currCallories);
                        meals.Dequeue();
                    }

                    if (calories.Count == 0)
                    {
                        meals.Dequeue();
                    }
                }
                else
                {
                    if (calories.Count == 0)
                    {
                        meals.Dequeue();
                    }
                }
            }
            StringBuilder sb = new StringBuilder();

            if (calories.Count > 0)
            {
                sb.AppendLine($"John had {startMealsCount} meals.");
                sb.AppendLine($"For the next few days, he can eat {string.Join(", ", calories)} calories.");
            }
            else
            {
                sb.AppendLine($"John ate enough, he had {startMealsCount - meals.Count} meals.");
                sb.AppendLine($"Meals left: {string.Join(", ", meals)}.");
            }
            Console.WriteLine(sb.ToString().TrimEnd());
         }
    }
}
