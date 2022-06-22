using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Birthday_Celebration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] guestCapacity = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] platesOfFood = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> guests = new Queue<int>(guestCapacity);
            Stack<int> foods = new Stack<int>(platesOfFood);
            int wastedGramsOfFood = 0;

            while (guests.Count > 0 && foods.Count > 0)
            {
                int guest = guests.Peek();
                int food = foods.Peek();
                if (food >= guest)
                {
                    guests.Dequeue();
                    foods.Pop();
                    wastedGramsOfFood += food - guest;
                }
                else if (guest > food)
                {
                    while (guest > 0)
                    {
                        int sum = food - guest;
                        guest -= food;
                        foods.Pop();
                        if (sum > 0)
                        {
                            wastedGramsOfFood += sum;
                        }
                        if (foods.Count > 0)
                        {
                            food = foods.Peek();
                        }
                        else
                        {
                            break;
                        }
                    }
                    guests.Dequeue();
                }
            }
            if (foods.Count > 0)
            {
                Console.WriteLine($"Plates: {string.Join(" ", foods)}");
            }
            if (guests.Count > 0)
            {
                Console.WriteLine($"Guests: {string.Join(" ", guests)}");
            }
            Console.WriteLine($"Wasted grams of food: {wastedGramsOfFood}");
        }
    }
}