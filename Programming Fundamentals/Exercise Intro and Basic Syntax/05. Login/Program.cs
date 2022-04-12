using System;

namespace _05._Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();

            string password = string.Empty;

            for (int reverseIndex = username.Length - 1; reverseIndex >= 0; reverseIndex--)
            {
                password += username[reverseIndex];
            }
            for (int count = 1; count <= 4; count++)
            {
                string enterPassword = Console.ReadLine();

                if (enterPassword == password)
                {
                    Console.WriteLine($"User {username} logged in.");
                    Environment.Exit(0);
                }
                else
                {
                    if (count == 4)
                    {
                        Console.WriteLine($"User {username} blocked!");
                        Environment.Exit(403);
                    }
                    else
                    {
                        Console.WriteLine("Incorrect password. Try again.");
                        continue;
                    }
                }
            }
        }
    }
}
