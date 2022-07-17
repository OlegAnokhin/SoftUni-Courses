using System;
using System.Linq;
using System.Collections.Generic;

namespace _06._Money_Transactions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(",");
            Dictionary<int, double> accountPair = new Dictionary<int, double>();
            foreach (var line in input)
            {
                var accPair = line.Split("-").Select(double.Parse).ToArray();
                int account = (int)accPair[0];
                double balance = (double)accPair[1];
                accountPair.Add(account, balance);
            }
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                try
                {
                    string[] cmdArg = command.Split();
                    string cmdType = cmdArg[0];
                    int accNumber = int.Parse(cmdArg[1]);
                    double sum = double.Parse(cmdArg[2]);
                    double newBalance = 0;
                    if (cmdType == "Deposit")
                    {
                        if (accountPair.ContainsKey(accNumber))
                        {
                            accountPair[accNumber] += sum;
                            newBalance = GetValue(accountPair, accNumber, newBalance);
                            Console.WriteLine($"Account {accNumber} has new balance: {newBalance:f2}");
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                    else if (cmdType == "Withdraw")
                    {
                        if (accountPair.ContainsKey(accNumber))
                        {
                            if (accountPair[accNumber] - sum < 0)
                            {
                                throw new ArgumentNullException();
                            }
                            accountPair[accNumber] -= sum;
                            newBalance = GetValue(accountPair, accNumber, newBalance);
                            Console.WriteLine($"Account {accNumber} has new balance: {newBalance:f2}");
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                    else
                    {
                        throw new ArgumentException();
                    }
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Insufficient balance!");
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Invalid command!");
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid account!");
                }
                finally
                {
                    Console.WriteLine("Enter another command");
                }
            }
        }
        public static double GetValue(Dictionary<int, double> accountPair, int accNumber, double newBalance)
        {
            foreach (var kvp in accountPair)
            {
                if (kvp.Key == accNumber)
                {
                    newBalance = kvp.Value;
                }
            }
            return newBalance;
        }
    }
}