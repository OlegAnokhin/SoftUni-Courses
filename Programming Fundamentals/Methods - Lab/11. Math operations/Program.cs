using System;

namespace _11._Math_operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            string @operator = Console.ReadLine();
            int secondNum = int.Parse(Console.ReadLine());

            result(firstNum, @operator, secondNum);

            static void result(int firstNum, string @operator, int secondNum)
            {

                if (@operator == "+")
                {
                    Console.WriteLine(firstNum + secondNum);
                }
                else if (@operator == "-")
                {
                    Console.WriteLine(firstNum - secondNum);
                }
                else if (@operator == "*")
                {
                    Console.WriteLine(firstNum * secondNum);
                }
                else if (@operator == "/")
                {
                    Console.WriteLine(firstNum / secondNum);
                }
            }
        }
    }
}
