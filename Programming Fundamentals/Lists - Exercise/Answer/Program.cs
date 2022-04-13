using System;
using System.Linq;
using System.Collections.Generic;

namespace MidExamPreparation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // PR-01-ComputerStore

            //string command = Console.ReadLine();
            //decimal totalpriseWithNoTax = 0;

            //while (command != "regular" && command != "special")
            //{
            //    decimal price = decimal.Parse(command);

            //    if (price < 0)
            //    {
            //        Console.WriteLine("Invalid price!");
            //        command = Console.ReadLine();
            //        continue;
            //    }

            //    totalpriseWithNoTax += price;


            //    command = Console.ReadLine();
            //}

            //if (totalpriseWithNoTax ==0)
            //{
            //    Console.WriteLine("Invalid order!");
            //    return;
            //}

            //    decimal taxes = totalpriseWithNoTax * 0.2m;

            //if (command == "special")
            //{
            //    decimal totalWhitTaxes = totalpriseWithNoTax + taxes;
            //    decimal totalPriseDiscount = totalWhitTaxes * 0.9m;


            //    Console.WriteLine($"Congratulations you've just bought a new computer!");
            //    Console.WriteLine($"Price without taxes: {totalpriseWithNoTax:f2}$");
            //    Console.WriteLine($"Taxes: {taxes:f2}$");
            //    Console.WriteLine($"-----------");
            //    Console.WriteLine($"Total price: {totalPriseDiscount:f2}$");
            //}
            //else
            //{
            //    Console.WriteLine($"Congratulations you've just bought a new computer!");
            //    Console.WriteLine($"Price without taxes: {totalpriseWithNoTax:f2}$");
            //    Console.WriteLine($"Taxes: {taxes:f2}$");
            //    Console.WriteLine($"-----------");
            //    Console.WriteLine($"Total price: {totalpriseWithNoTax + taxes:f2}$");
            //}


            // PR-02-Shoot for the Win

            //    int[] targets = Console.ReadLine()
            //        .Split()
            //        .Select(int.Parse)
            //        .ToArray();

            //    string command = Console.ReadLine();
            //    int shootCounter = 0;

            //    while (command != "End")
            //    {
            //        int indexToShoot = int.Parse(command);

            //        if (indexToShoot >= 0 && indexToShoot < targets.Length && indexToShoot != -1)
            //        {
            //            ShootTarget(indexToShoot, targets);
            //            shootCounter++;
            //        }
            //        command = Console.ReadLine();
            //    }
            //    Console.Write($"Shot targets: {shootCounter} -> {string.Join(" ",targets)} ");
            //}


            //static void ShootTarget(int indexToShoot, int[] targets)
            //{
            //    int valueOfTarget = targets[indexToShoot];
            //    targets[indexToShoot] = -1;
            //    for (int i = 0; i < targets.Length; i++)
            //    {
            //        if (targets[i] == -1)
            //        {
            //            continue;
            //        }
            //        if (targets[i] > valueOfTarget)
            //        {
            //            targets[i] -= valueOfTarget;
            //        }
            //        else
            //        {
            //            targets[i] += valueOfTarget;
            //        }
            //    }



            // PR-03-Memory Game

            //            List<string> elements = Console.ReadLine()
            //                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            //                .ToList();

            //            string command = Console.ReadLine();
            //            int moveCount = 0;

            //            while (command != "end")
            //            {
            //                moveCount++;
            //                string[] RawGuesses = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            //                int firstGuess = int.Parse(RawGuesses[0]);
            //                int secondGuess = int.Parse(RawGuesses[1]);

            //                if (IsInvalidGuess(firstGuess, secondGuess, elements))
            //                {
            //                    int middleOfElements = elements.Count / 2;
            //                    string elementToAdd = $"-{moveCount}a";
            //                    elements.Insert(middleOfElements, elementToAdd);
            //                    elements.Insert(middleOfElements, elementToAdd);
            //                    Console.WriteLine("Invalid input! Adding additional elements to the board");
            //                }
            //                else if (elements[firstGuess] == elements[secondGuess])
            //                {
            //                    string guessedElements = elements[firstGuess];
            //                    Console.WriteLine($"Congrats! You have found matching elements - {guessedElements}!");
            //                    elements.Remove(guessedElements);
            //                    elements.Remove(guessedElements);
            //                }
            //                else if (elements[firstGuess] != elements[secondGuess])
            //                {
            //                    Console.WriteLine("Try again!");
            //                }
            //                if (elements.Count == 0)
            //                {
            //                    Console.WriteLine($"You have won in {moveCount} turns!");
            //                    break;
            //                }

            //                command = Console.ReadLine();
            //            }
            //            if (elements.Count > 0)
            //            {
            //                Console.WriteLine("Sorry you lose :(");
            //                Console.WriteLine(string.Join(" ", elements));
            //            }
            //        }
            //        static bool IsInvalidGuess(int firstGuess, int secondGuess, List<string> elements)
            //        {
            //            return firstGuess == secondGuess || !IsGuessInList(firstGuess, elements) || !IsGuessInList(secondGuess, elements);
            //        }

            //        static bool IsGuessInList(int guess, List<string> elements)
            //        {
            //            return guess >= 0 && guess < elements.Count;

            //        }
            //    }
            //}



            // PR-04-ManOWar

            //List<int> pirateShip = Console.ReadLine()
            //    .Split('>', StringSplitOptions.RemoveEmptyEntries)
            //    .Select(int.Parse)
            //    .ToList();

            //List<int> warShip = Console.ReadLine()
            //    .Split('>', StringSplitOptions.RemoveEmptyEntries)
            //    .Select(int.Parse)
            //    .ToList();

            //int maxHealt = int.Parse(Console.ReadLine());

            //string command = Console.ReadLine();
            //while (command != "Retire")
            //{
            //    string[] splitComand = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            //    string action = splitComand[0];
            //    if (action == "Fire")
            //    {
            //        int attackWarIndex = int.Parse(splitComand[1]);
            //        int attackDamage = int.Parse(splitComand[2]);

            //        if (attackWarIndex >= 0 && attackWarIndex < warShip.Count)
            //        {
            //            warShip[attackWarIndex] -= attackDamage;
            //            if (warShip[attackWarIndex] <= 0)
            //            {
            //                Console.WriteLine("You won! The enemy ship has sunken.");
            //                return;
            //            }
            //        }
            //    }
            //    else if (action == "Defend")
            //    {
            //        int startPirateIndex = int.Parse(splitComand[1]);
            //        int endPirateIndex = int.Parse(splitComand[2]);
            //        int atackDamage = int.Parse(splitComand[3]);

            //        if (startPirateIndex >= 0 && startPirateIndex < pirateShip.Count && endPirateIndex >= 0 
            //            && endPirateIndex < pirateShip.Count)
            //        {
            //            for (int i = startPirateIndex; i <= endPirateIndex; i++)
            //            {
            //                pirateShip[i] -= atackDamage;
            //                if (pirateShip[i] <= 0)
            //                {
            //                    Console.WriteLine("You lost! The pirate ship has sunken.");
            //                    return;
            //                }
            //            }
            //        }
            //    }
            //    else if (action == "Repair")
            //    {
            //        int pirateShipIndex = int.Parse(splitComand[1]);
            //        int repairValue = int.Parse(splitComand[2]);

            //        if (pirateShipIndex >= 0 && pirateShipIndex < pirateShip.Count)
            //        {
            //            if (pirateShip[pirateShipIndex] + repairValue > maxHealt)
            //            {
            //                pirateShip[pirateShipIndex] = maxHealt;
            //            }
            //            else
            //            {
            //                pirateShip[pirateShipIndex] += repairValue;
            //            }
            //        }
            //    }
            //    else if (action == "Status")
            //    {
            //        List<int> sectionInNeedOfRepaire = pirateShip.FindAll(x => (x < maxHealt * 0.2));
            //        Console.WriteLine($"{sectionInNeedOfRepaire.Count} sections need repair.");
            //    }

            //    command = Console.ReadLine();
            //}
            //Console.WriteLine($"Pirate ship status: {pirateShip.Sum()}");
            //Console.WriteLine($"Warship status: {warShip.Sum()}");


            // PR-05-MuOnline


            //string[] mazeRooms = Console.ReadLine()
            //    .Split('|', StringSplitOptions.RemoveEmptyEntries);

            //int heroHealt = 100;
            //int heroCoint = 0;

            //for (int i = 0; i < mazeRooms.Length; i++)
            //{
            //    string[] splitCommand = mazeRooms[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            //    string action = splitCommand[0];

            //    if (action == "potion")
            //    {
            //        int healthToHeal = int.Parse(splitCommand[1]);

            //        if (healthToHeal + heroHealt > 100)
            //        {
            //            int healthHealer = 100 - heroHealt;
            //            heroHealt = 100;
            //            Console.WriteLine($"You healed for {healthHealer} hp.");
            //            Console.WriteLine($"Current health: {heroHealt} hp.");
            //        }
            //        else
            //        {
            //            heroHealt += healthToHeal;
            //            Console.WriteLine($"You healed for {healthToHeal} hp.");
            //            Console.WriteLine($"Current health: {heroHealt} hp.");
            //        }
            //    }
            //    else if (action == "chest")
            //    {
            //        int coins = int.Parse(splitCommand[1]);
            //        heroCoint += coins;
            //        Console.WriteLine($"You found {coins} bitcoins.");
            //    }
            //    else 
            //    {
            //        string monsterName = action;
            //        int monsterAttac = int.Parse(splitCommand[1]);
            //        heroHealt -= monsterAttac;

            //        if (heroHealt <= 0)
            //        {
            //            Console.WriteLine($"You died! Killed by {monsterName}.");
            //            Console.WriteLine($"Best room: {i + 1}");
            //            return;
            //        }
            //        else
            //        {
            //            Console.WriteLine($"You slayed {monsterName}.");
            //        } 
            //    }
            //}
            //Console.WriteLine("You've made it!");
            //Console.WriteLine($"Bitcoins: {heroCoint}");
            //Console.WriteLine($"Health: {heroHealt}");

        }
    }
}