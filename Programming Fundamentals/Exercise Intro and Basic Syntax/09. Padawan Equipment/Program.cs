using System;

namespace _09._Padawan_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double amount = double.Parse(Console.ReadLine());
            double students = double.Parse(Console.ReadLine());
            double priceOfSaber = double.Parse(Console.ReadLine());
            double priceOfRobe = double.Parse(Console.ReadLine());
            double priceOfBelt = double.Parse(Console.ReadLine());

            double countOfLS = Math.Ceiling(students * 0.10 + students);
            double saber = countOfLS * priceOfSaber;
            double robe = priceOfRobe * students;
            double belt = priceOfBelt * (students - Math.Floor(students / 6));
            double sum = belt + robe + saber;

            if (amount >= sum)
            {
                Console.WriteLine($"The money is enough - it would cost {sum:f2}lv.");
            }
            else
            {
                Console.WriteLine($"John will need {sum - amount:F2}lv more.");
            }
        }
    }
}
