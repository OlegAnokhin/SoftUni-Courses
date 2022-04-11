using System;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            //ctrl + K + U uncomment
            //ctrl + K + C comment

            //lifetime, span, scope


            //Console.WriteLine(6 == 5); false
            //Console.WriteLine("hello" == "hello"); true

            //int age = 15;
            //bool isOfAge = age >= 18;
            //if (isOfAge);
            //{ Console.WriteLine("Welcome!"); }

            //double grade = double.Parse(Console.ReadLine());

            //if (grade >= 5.50)
            //{
            //    if (grade >= 2 && grade <= 6)
            //    {
            //        Console.WriteLine("Exelent !");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Try again!");
            //    }
            //}



            //int num1 = int.Parse(Console.ReadLine());
            //int num2 = int.Parse(Console.ReadLine());

            //if (num1 > num2)
            //{
            //    Console.WriteLine(num1);
            //}
            //else
            //{
            //    Console.WriteLine(num2);
            //}


            //int num = int.Parse(Console.ReadLine());

            //if (num % 2 == 0)
            //{
            //    Console.WriteLine("even");
            //}
            //else
            //{
            //    Console.WriteLine("odd");
            //}


            //double up = Math.Ceiling(23.45); //24
            //double dowm = Math.Floor(45.67); //46
            //double round = Math.Round(45.67852, 2); // 45.68
            //Console.WriteLine("0:F2", 123.456); //123.46

            //double num = 25.600;
            //Console.WriteLine($"{num:f2}");



            //string weather = Console.ReadLine();
            //sunny, cloudy, rainy, snowy
            //other -> "Invalid weather!"

            //if (weather == "sunny")
            //{
            //    Console.WriteLine("Go outside!");
            //}
            //else if (weather == "cloudy")
            //{
            //    Console.WriteLine("Bring an umbrella!");
            //}
            //else if (weather == "rainy")
            //{
            //    Console.WriteLine("Stay at home!");
            //}
            //else if (weather == "snowy")
            //{
            //    Console.WriteLine("Go skiing!");
            //}
            //else
            //{
            //    Console.WriteLine("Invalid weather!");
            //}


            //zadacha 4 trqbwa &&


            //zadacha7 lica i figuri

            string FigureType = Console.ReadLine();
            double area = 0;

            if (FigureType == "square")
            {
                double a = double.Parse(Console.ReadLine());
                area = a * a;
            }
            else if (FigureType == "rectangle")
            {
                double a = double.Parse(Console.ReadLine());
                double b = double.Parse(Console.ReadLine());
                area = a * b;
            }
            else if (FigureType == "circle")
            {
                double r = double.Parse(Console.ReadLine());
                area = r * r * Math.PI;
            }
            else if (FigureType == "triangle")
            {
                double a = double.Parse(Console.ReadLine());
                double ha = double.Parse(Console.ReadLine());
                area = a * ha / 2;
            }
            Console.WriteLine($"{area:f3}");

        }
    }
}
