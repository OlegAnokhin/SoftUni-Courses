using System;

namespace _03._Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfPeople = int.Parse(Console.ReadLine());
            string typeOfGroup = Console.ReadLine();
            string dayOfWeek = Console.ReadLine();
            double amount = 0;

            if (typeOfGroup == "Students")
            {
                if (dayOfWeek == "Friday")
                {
                    amount = numOfPeople * 8.45;
                }
                else if (dayOfWeek == "Saturday")
                {
                    amount = numOfPeople * 9.80;
                }
                else if (dayOfWeek == "Sunday")
                {
                    amount = numOfPeople * 10.46;
                }
                if (numOfPeople >= 30)
                {
                    amount *= 0.85;
                }
            }
            if (typeOfGroup == "Business")
            {
                if (numOfPeople >= 100)
                {
                    numOfPeople -= 10;
                }
                if (dayOfWeek == "Friday")
                {
                    amount = numOfPeople * 10.90;
                }
                else if (dayOfWeek == "Saturday")
                {
                    amount = numOfPeople * 15.60;
                }
                else if (dayOfWeek == "Sunday")
                {
                    amount = numOfPeople * 16;
                }
            }
            if (typeOfGroup == "Regular")
            {
                if (dayOfWeek == "Friday")
                {
                    amount = numOfPeople * 15;
                }
                else if (dayOfWeek == "Saturday")
                {
                    amount = numOfPeople * 20;
                }
                else if (dayOfWeek == "Sunday")
                {
                    amount = numOfPeople * 22.50;
                }
                if (numOfPeople >= 10 && numOfPeople <= 20)
                {
                    amount *= 0.95;
                }
            }
            Console.WriteLine($"Total price: {amount:F2}");
        }
    }
}
