using System;

namespace _007HotelRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int numDays = int.Parse(Console.ReadLine());

            double priceStudio = 0.0;
            double priceApartment = 0.0;

            if (month == "May" || month == "October")
            {
                priceStudio = 50;
                priceApartment = 65;
                if (numDays > 7 && numDays <= 14)
                {
                    priceStudio = (priceStudio - priceStudio * 0.05) * numDays;
                    priceApartment = priceApartment * numDays;
                }
                else if (numDays > 14)
                {
                    priceStudio = (priceStudio - priceStudio * 0.3) * numDays;
                    priceApartment = (priceApartment - priceApartment * 0.1) * numDays;
                }
                else
                {
                    priceStudio = 50 * numDays;
                    priceApartment = 65 * numDays;
                }
            }
            else if (month == "June" || month == "September")
            {
                priceStudio = 75.20;
                priceApartment = 68.70;

                if (numDays > 14)
                {
                    priceStudio = (priceStudio - priceStudio * 0.2) * numDays;
                    priceApartment = (priceApartment - priceApartment * 0.1) * numDays;
                }
                else
                {
                    priceStudio = 75.20 * numDays;
                    priceApartment = 68.70 * numDays;
                }
            }
            else if (month == "July" || month == "August")
            {
                priceStudio = 76;
                priceApartment = 77;

                if (numDays > 14)
                {
                    priceApartment = (priceApartment - priceApartment * 0.1) * numDays;
                    priceStudio = 76 * numDays;
                }
                else
                {
                    priceStudio = 76 * numDays;
                    priceApartment = 77 * numDays;
                }
            }
            Console.WriteLine($"Apartment: {priceApartment:F2} lv.");
            Console.WriteLine($"Studio: {priceStudio:F2} lv.");

        }
    }
}
