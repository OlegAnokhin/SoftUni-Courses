using System;

namespace _001OldBooks
{
    class Program
    {
        static void Main(string[] args)
        {
            string searchBook = Console.ReadLine();
            string BookName = Console.ReadLine();
            int chekbook = 0;

            while (BookName != "No More Books")
            {
                if (BookName == searchBook)
                {
                    break;
                }
                chekbook++;
                BookName = Console.ReadLine();
            }
            if (BookName == searchBook)
            {
                Console.WriteLine($"You checked {chekbook} books and found it.");
            }
            else
            {
                Console.WriteLine("The book you search is not here!");
                Console.WriteLine($"You checked {chekbook} books.");
            }
        }
    }
}
