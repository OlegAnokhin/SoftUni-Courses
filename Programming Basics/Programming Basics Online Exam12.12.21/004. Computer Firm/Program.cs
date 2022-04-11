using System;

namespace _004._Computer_Firm
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            double rating = 0;
            double posibleSells = 0;
            double sum = 0;
            double counter = 0;

            for (int i = 0; i < number; i++)
            {
                int sell = int.Parse(Console.ReadLine());
                rating = sell % 10;
                posibleSells = (sell - rating) / 10;

                if (rating == 2)
                {
                    counter += rating;
                    continue;
                }
                else if (rating == 3)
                {
                    counter += rating;
                    posibleSells *= 0.5;
                }
                else if (rating == 4)
                {
                    counter += rating;
                    posibleSells *= 0.7;
                }
                else if (rating == 5)
                {
                    counter += rating;
                    posibleSells *= 0.85;
                }
                else if (rating == 6)
                {
                    counter += rating;
                    posibleSells *= 1.0;
                }
                sum += posibleSells;

            }
            double average = counter / number;

            Console.WriteLine($"{sum:F2}");
            Console.WriteLine($"{average:F2}");

        }
    }
}