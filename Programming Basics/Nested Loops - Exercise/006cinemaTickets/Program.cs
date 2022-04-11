using System;

namespace _006cinemaTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalTickets = 0;
            int studentTickets = 0;
            int standardTickets = 0;
            int kidsTickets = 0;
            while (true)
            {
                string movieName = Console.ReadLine();
                if (movieName == "Finish")
                {
                    break;
                }
                int seatsCapacity = int.Parse(Console.ReadLine());
                int movieTickets = 0;
                while (true)
                {
                    string ticketType = Console.ReadLine();
                    if (ticketType == "End")
                    {
                        break;
                    }
                    switch (ticketType)
                    {
                        case "standard":
                            standardTickets++;
                            totalTickets++;
                            movieTickets++;
                            break;
                        case "student":
                            studentTickets++;
                            totalTickets++;
                            movieTickets++;
                            break;
                        case "kid":
                            kidsTickets++;
                            totalTickets++;
                            movieTickets++;
                            break;
                    }
                    int availableSpace = seatsCapacity - movieTickets;
                    if (availableSpace == 0)
                    {
                        break;
                    }
                }
                Console.WriteLine($"{movieName} - {((double)movieTickets / seatsCapacity) * 100:f2}% full.");
            }
            Console.WriteLine($"Total tickets: {totalTickets}");
            Console.WriteLine($"{(double)studentTickets / totalTickets * 100:f2}% student tickets.");
            Console.WriteLine($"{(double)standardTickets / totalTickets * 100:f2}% standard tickets.");
            Console.WriteLine($"{(double)kidsTickets / totalTickets * 100:f2}% kids tickets.");
        }
    }
}
