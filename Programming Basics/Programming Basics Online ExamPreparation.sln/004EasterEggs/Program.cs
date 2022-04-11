using System;

namespace _004EasterEggs
{
    class Program
    {
        static void Main(string[] args)
        {
            int numEggs = int.Parse(Console.ReadLine());

            int RedEggs = 0;
            int OrangeEggs = 0;
            int BlueEggs = 0;
            int GreenEggs = 0;
            int MaxEggscounter = 0;
            string colorcounter = "";

            for (int i = 0; i < numEggs; i++)
            {
                string color = Console.ReadLine();
                if (color == "red")
                {
                    RedEggs++;
                    if (RedEggs > MaxEggscounter)
                    {
                        MaxEggscounter = RedEggs;
                        colorcounter = "red";
                    }
                }
                if (color == "orange")
                {
                    OrangeEggs++;
                    if (OrangeEggs > MaxEggscounter)
                    {
                        MaxEggscounter = OrangeEggs;
                        colorcounter = "orange";
                    }
                }
                if (color == "blue")
                {
                    BlueEggs++;
                    if (BlueEggs > MaxEggscounter)
                    {
                        MaxEggscounter = BlueEggs;
                        colorcounter = "blue";
                    }
                }
                if (color == "green")
                {
                    GreenEggs++;
                    if (GreenEggs > MaxEggscounter)
                    {
                        MaxEggscounter = GreenEggs;
                        colorcounter = "green";
                    }
                }
            }
            Console.WriteLine($"Red eggs: {RedEggs}");
            Console.WriteLine($"Orange eggs: {OrangeEggs}");
            Console.WriteLine($"Blue eggs: {BlueEggs}");
            Console.WriteLine($"Green eggs: {GreenEggs}");
            Console.WriteLine($"Max eggs: {MaxEggscounter} -> {colorcounter}");
        }
    }
}
