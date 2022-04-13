using System;

namespace _03._Calculations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string function = Console.ReadLine();
            double firstNum = double.Parse(Console.ReadLine());
            double secondNum = double.Parse(Console.ReadLine());


            if (function == "add")
            {
                Console.WriteLine(Add(firstNum,secondNum));
            }
            else if (function == "multiply")
            {
                Console.WriteLine(Multiply(firstNum, secondNum));
            }
            else if (function == "subtract")
            {
                Console.WriteLine(Subtract(firstNum, secondNum));
            }
            else if (function == "divide")
            {
                Console.WriteLine(Divide(firstNum, secondNum));
            }
        }

        static double Add (double firstNum, double secondNum)
        {
            return (firstNum + secondNum);
        }
        static double Multiply (double firstNum, double secondNum)
        {
            return (firstNum * secondNum);
        }
        static double Subtract (double firstNum, double secondNum)
        {
            return (firstNum - secondNum);
        }
        static double Divide (double firstNum, double secondNum)
        {
            return (firstNum / secondNum);
        }
    }
}
