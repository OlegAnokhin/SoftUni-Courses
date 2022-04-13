using System;

namespace P05._Add_and_Subtract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());

            Console.WriteLine(Sum(firstNum, secondNum, thirdNum));
        }


        static int Sum(int firstNum, int secondNum, int thirdNum)
        {
            int firstSum = firstNum + secondNum;

            int secondSum = firstSum - thirdNum;

            return secondSum;
        }
    }
}
