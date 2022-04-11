using System;

namespace _007TrekkingMania
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double Musala = 0;
            double Monblan = 0;
            double Kilimandjaro = 0;
            double K2 = 0;
            double Everest = 0;
            double AllPeople = 0;

            for (int i = 1; i <= n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (num <= 5)
                {
                    Musala += num;
                }
                else if (num <= 12)
                {
                    Monblan += num;
                }
                else if (num <= 25)
                {
                    Kilimandjaro += num;
                }
                else if (num <= 40)
                {
                    K2 += num;
                }
                else if (num >= 41)
                {
                    Everest += num;
                }
            }
            AllPeople = Musala + Monblan + Kilimandjaro + K2 + Everest;
            Musala = Musala / AllPeople * 100;
            Monblan = Monblan / AllPeople * 100;
            Kilimandjaro = Kilimandjaro / AllPeople * 100;
            K2 = K2 / AllPeople * 100;
            Everest = Everest / AllPeople * 100;

            Console.WriteLine($"{Musala:F2}%");
            Console.WriteLine($"{Monblan:F2}%");
            Console.WriteLine($"{Kilimandjaro:F2}%");
            Console.WriteLine($"{K2:F2}%");
            Console.WriteLine($"{Everest:F2}%");

        }
    }
}

