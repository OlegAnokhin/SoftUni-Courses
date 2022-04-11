using System;

namespace _006._Multiply_Table
{
    class Program
    {
        static void Main(string[] args)
        {

            int num = int.Parse(Console.ReadLine());
            int number = num;
            int n1 = 0;
            int n2 = 0;
            int n3 = 0;

            int r = number % 10;
            n1 = n1 + r;
            number = number / 10;
            r = number % 10;
            n2 = n2 + r;
            number = number / 10;
            r = number % 10;
            n3 = n3 + r;

            for (int a = 1; a <= n1; a++)
            {
                for (int b = 1; b <= n2; b++)
                {
                    for (int c = 1; c <= n3; c++)
                    {
                        Console.WriteLine(a + " " + "*" + " " + b + " " + "*" + " " + c + " " + "=" + " " + a * b * c + ";");
                    }
                }
            }
        }
    }
}
