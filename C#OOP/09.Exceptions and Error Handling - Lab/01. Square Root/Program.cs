namespace _01._Square_Root
{
    using System;
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {               
                int num = int.Parse(Console.ReadLine());
                if (num < 0)
                {
                    throw new ArgumentException();
                }
                double sum = Math.Sqrt(num);
                Console.WriteLine(sum);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid number.");
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }
        }
    }
}