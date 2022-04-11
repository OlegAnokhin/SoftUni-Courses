using System;

namespace _901PipesInPool
{
    class Program
    {
        static void Main(string[] args)
        {
            int V = int.Parse(Console.ReadLine());
            int P1 = int.Parse(Console.ReadLine());
            int P2 = int.Parse(Console.ReadLine());
            double H = double.Parse(Console.ReadLine());

            double P1work = P1 * H;
            double P2work = P2 * H;
            double Pwork = P1work + P2work;

            if (Pwork <= V)
            {
                Console.WriteLine($"The pool is {(Pwork / V) * 100:f2}% full. Pipe 1: {(P1work / Pwork) * 100:f2}%. Pipe 2: {(P2work / Pwork) * 100:f2}%.");
            }
            else if (Pwork > V)
            {
                Console.WriteLine($"For {H:f2} hours the pool overflows with {(P1work + P2work) - V:f2} liters.");
            }
        }
    }
}
