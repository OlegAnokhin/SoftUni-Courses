//using System;
//using System.Linq;
//using System.Collections.Generic;

//namespace MidExamPreparation
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
// ot strign kym char i obratno

// List<char> test = new List<char>("test");
// string result = string.Join('', test);


// PR-01-ComputerStore

//string input = Console.ReadLine();
//double priceWithoutTaxes = 0;
//double taxes = 0;
//double totalAmount = 0;
//bool ItsNumber = false;

//if (input == "special" || input == "regular")
//{
//    Console.WriteLine("Invalid order!");
//    ItsNumber = true;
//}

//while (ItsNumber == false)
//{
//    if (input == "special")
//    {
//        taxes = priceWithoutTaxes * 0.2;
//        totalAmount += taxes + priceWithoutTaxes;
//        totalAmount = totalAmount * 0.9;
//        if (totalAmount == 0)
//        {
//            Console.WriteLine("Invalid order!");
//            break;
//        }
//        Console.WriteLine($"Congratulations you've just bought a new computer!");
//        Console.WriteLine($"Price without taxes: {priceWithoutTaxes:f2}$");
//        Console.WriteLine($"Taxes: {taxes:f2}$");
//        Console.WriteLine($"-----------");
//        Console.WriteLine($"Total price: {totalAmount:f2}$");
//        break;
//    }
//    else if (input == "regular")
//    {
//        taxes = priceWithoutTaxes * 0.2;
//        totalAmount += taxes + priceWithoutTaxes;
//        if (totalAmount == 0)
//        {
//            Console.WriteLine("Invalid order!");
//            break;
//        }
//        Console.WriteLine($"Congratulations you've just bought a new computer!");
//        Console.WriteLine($"Price without taxes: {priceWithoutTaxes:f2}$");
//        Console.WriteLine($"Taxes: {taxes:f2}$");
//        Console.WriteLine($"-----------");
//        Console.WriteLine($"Total price: {totalAmount:f2}$");
//        break;
//    }
//    double price = double.Parse(input);

//    if (price < 0)
//    {
//        Console.WriteLine("Invalid price!");
//    }
//    else if (price >= 0)
//    {
//        priceWithoutTaxes += price;
//    }
//    input = Console.ReadLine();
//}


//PR-01-ComputerStore 
//drugo re6enie




//PR-02-ShootForTheWin

//List<int> shotTargets = Console.ReadLine()
//    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
//    .Select(int.Parse)
//    .ToList();

//int count = 0;
//int deathNum = 0;
//int deathIndex = -1;
//string command;

//while ((command = Console.ReadLine()) != "End")
//{
//    string[] cmdArgs = command
//        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
//        .ToArray();

//    int shotIndex = int.Parse(cmdArgs[0]);

//    if (shotIndex < 0 || shotIndex > shotTargets.Count - 1)
//    {
//        continue;
//        count--;
//    }

//    deathNum = shotTargets[shotIndex];
//    shotTargets[shotIndex] = deathIndex;
//    count++;

//    for (int i = 0; i < shotTargets.Count; i++)
//    {
//        int currentNum = shotTargets[i];
//        if (currentNum == -1)
//        {
//            continue;
//        }
//        if (deathNum < currentNum)
//        {
//            shotTargets[i] -= deathNum;
//        }
//        else if (deathNum >= currentNum)
//        {
//            shotTargets[i] += deathNum;
//        }
//    }
//}
//Console.Write($"Shot targets: {count} -> ");
//Console.WriteLine(string.Join(" ", shotTargets));


// PR-03-MemoryGame

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


// PR-03-MemoryGame rabote6o


//List<string> input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

//string command = Console.ReadLine();

//int numberOfMoves = 0;

//while (true)
//{
//    if (command == "end")
//    {
//        break;
//    }

//    numberOfMoves++;

//    string[] indexes = command.Split();
//    int index1 = int.Parse(indexes[0]);
//    int index2 = int.Parse(indexes[1]);

//    if (index1 >= 0 && index2 >= 0 && index1 < input.Count && index2 < input.Count && index1 != index2)
//    {
//        if (input[index1] == input[index2])
//        {
//            Console.WriteLine($"Congrats! You have found matching elements - {input[index1]}!");

//            if (index1 > index2)
//            {
//                input.RemoveAt(index1);
//                input.RemoveAt(index2);
//            }
//            else
//            {
//                input.RemoveAt(index2);
//                input.RemoveAt(index1);
//            }

//            if (input.Count == 0)
//            {
//                Console.WriteLine($"You have won in {numberOfMoves} turns!");
//                return;
//            }
//        }
//        else if (input[index1] != input[index2])
//        {
//            Console.WriteLine("Try again!");
//        }
//    }
//    else
//    {
//        input.Insert(input.Count / 2, $"-{numberOfMoves}a");
//        input.Insert(input.Count / 2, $"-{numberOfMoves}a");
//        Console.WriteLine("Invalid input! Adding additional elements to the board");
//    }
//    command = Console.ReadLine();
//}
//Console.WriteLine("Sorry you lose :(");
//Console.WriteLine(String.Join(" ", input));



// PR-TheLift

//            int waitingPeople = int.Parse(Console.ReadLine());

//            int[] lift = Console.ReadLine()
//                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
//                .Select(int.Parse)
//                .ToArray();

//            int maxCapacity = 4;

//            bool noMorePeople = false;

//            for (int i = 0; i < lift.Length; i++)
//            {
//                int currentWagon = lift[i];

//                if (waitingPeople - (maxCapacity - currentWagon) == 0)
//                {
//                    waitingPeople -= maxCapacity - currentWagon;
//                    lift[i] = 4;
//                    noMorePeople = true;
//                    break;
//                }
//                else if (waitingPeople - (maxCapacity - currentWagon) < 0)
//                {
//                    lift[i] = waitingPeople;
//                    waitingPeople = 0;
//                    noMorePeople = true;
//                    break;
//                }
//                else if (currentWagon > 4)
//                {
//                    continue;
//                }
//                else
//                {
//                    waitingPeople -= maxCapacity - currentWagon;
//                    lift[i] = 4;
//                }
//            }

//            bool emptyCabins = false;

//            for (int i = 0; i < lift.Length; i++)
//            {
//                if (lift[i] < 4)
//                {
//                    emptyCabins = true;
//                    break;
//                }
//            }

//            if (noMorePeople == true && emptyCabins == true)
//            {
//                Console.WriteLine("The lift has empty spots!");
//                Console.WriteLine(String.Join(" ", lift));

//            }
//            else if (waitingPeople > 0 && emptyCabins == false)
//            {
//                Console.WriteLine($"There isn't enough space! {waitingPeople} people in a queue!");
//                Console.WriteLine(String.Join(" ", lift));
//            }
//            else if (waitingPeople == 0 && emptyCabins == false)
//            {
//                Console.WriteLine(String.Join(" ", lift));
//            }
//        }
//    }
//}


// PR-Counter-Strike

//int energy = int.Parse(Console.ReadLine());

//string command = Console.ReadLine();

//int wonBattlesCount = 0;

//while (command != "End of battle")
//{
//    int distance = int.Parse(command);

//    if (distance <= energy)
//    {
//        energy -= distance;
//        wonBattlesCount++;
//    }
//    else if (distance > energy)
//    {
//        Console.WriteLine($"Not enough energy! Game ends with {wonBattlesCount} won battles and {energy} energy");
//        return;
//    }
//    if (wonBattlesCount % 3 == 0)
//    {
//        energy += wonBattlesCount;
//    }
//    command = Console.ReadLine();
//}
//Console.WriteLine($"Won battles: {wonBattlesCount}. Energy left: {energy}");


// PR-MovingTarget


//            List<int> targets = Console.ReadLine()
//                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
//                .Select(int.Parse)
//                .ToList();

//            string command = Console.ReadLine();
//            while (command != "End")
//            {
//                string[] splitComand = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
//                string action = splitComand[0];
//                if (action == "Shoot")
//                {
//                    int attackIndex = int.Parse(splitComand[1]);
//                    int attackPower = int.Parse(splitComand[2]);

//                    if (attackIndex >= 0 && attackIndex < targets.Count)
//                    {
//                        targets[attackIndex] -= attackPower;
//                        if (targets[attackIndex] <= 0)
//                        {
//                            targets.RemoveAt(attackIndex);
//                        }
//                    }
//                }
//                else if (action == "Add")
//                {
//                    int addIndex = int.Parse(splitComand[1]);
//                    int addValue = int.Parse(splitComand[2]);

//                    if (addIndex >= 0 && addIndex < targets.Count)
//                    {
//                        targets.Insert(addIndex, addValue);
//                    }
//                    else
//                    {
//                        Console.WriteLine("Invalid placement!");
//                    }
//                }
//                else if (action == "Strike")
//                {
//                    int strikeIndex = int.Parse(splitComand[1]);
//                    int strikeRadius = int.Parse(splitComand[2]);

//                    if (strikeIndex - strikeRadius >= 0 && strikeIndex + strikeRadius <= targets.Count)
//                    {
//                        hitStrike(targets, strikeIndex, strikeRadius);
//                    }
//                    else
//                    {
//                        Console.WriteLine("Strike missed!");
//                    }
//                }
//                command = Console.ReadLine();
//            }
//            Console.WriteLine(string.Join("|", targets));
//        }

//        static void hitStrike(List<int> targets, int strikeIndex, int strikeRadius)
//        {
//            int rightCount = strikeIndex + strikeRadius;

//            for (int cnt = strikeIndex; cnt <= rightCount; cnt++)
//            {
//                if (strikeIndex >= targets.Count)
//                {
//                    break;
//                }
//                targets.RemoveAt(strikeIndex);
//            }
//            int leftCount = strikeIndex - strikeRadius;
//            if (leftCount < 0)
//            {
//                leftCount = 0;
//            }
//            for (int cnt = leftCount; cnt < strikeIndex; cnt++)
//            {
//                if (leftCount >= targets.Count)
//                {
//                    break;
//                }
//                targets.RemoveAt(leftCount);
//            }
//        }
//    }
//}

//using System;
//using System.Linq;
//using System.Collections.Generic;

//namespace MidExamPreparation
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            //PR-01-SoftUniReception

//            int powerOfFirstTeather = int.Parse(Console.ReadLine());
//            int powerOfSecondTeather = int.Parse(Console.ReadLine());
//            int powerOfThirdTeather = int.Parse(Console.ReadLine());
//            int studentsquestions = int.Parse(Console.ReadLine());

//            int hoursCount = 0;
//            int sumAllPower = powerOfFirstTeather + powerOfSecondTeather + powerOfThirdTeather;

//            while (studentsquestions > 0)
//            {
//                studentsquestions -= sumAllPower;
//                hoursCount++;

//                if (hoursCount % 4 == 0)
//                {
//                    hoursCount++;
//                }
//            }
//            Console.WriteLine($"Time needed: {hoursCount}h.");
//        }
//    }
//}



//using System;
//using System.Linq;
//using System.Collections.Generic;

//namespace MidExamPreparation
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            //PR-02-ArrayModifier

//            List<int> elements = Console.ReadLine()
//                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
//                .Select(int.Parse)
//                .ToList();

//            string command;

//            while ((command = Console.ReadLine()) != "end")
//            {
//                string[] cmdArgs = command
//                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
//                    .ToArray();
//                string cmdType = cmdArgs[0];


//                if (cmdType == "swap")
//                {
//                    int firstIndex = int.Parse(cmdArgs[1]);
//                    int secondIndex = int.Parse(cmdArgs[2]);
//                    int swapElement = elements[firstIndex];
//                    elements[firstIndex] = elements[secondIndex];
//                    elements[secondIndex] = swapElement;
//                }
//                else if (cmdType == "multiply")
//                {
//                    int firstIndex = int.Parse(cmdArgs[1]);
//                    int secondIndex = int.Parse(cmdArgs[2]);
//                    int newNumber = elements[firstIndex] * elements[secondIndex];
//                    elements[firstIndex] = newNumber;
//                }
//                else if (cmdType == "decrease")
//                {
//                    for (int i = 0; i < elements.Count; i++)
//                    {
//                        elements[i] -= 1;
//                    }
//                }
//            }
//            Console.WriteLine(string.Join(", ", elements));

//        }
//    }
//}



using System;
using System.Linq;
using System.Collections.Generic;

namespace MidExamPreparation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //PR-03-Numbers

            List<double> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToList();

            List<double> top5 = new List<double>();

            double averageNumber = numbers.Sum() / numbers.Count;

            int counter = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] > averageNumber)
                {
                    top5.Add(numbers[i]);
                    counter++;
                }
            }
            if (counter == 0)
            {
                Console.WriteLine("No");
                return;
            }
            top5 = top5.OrderByDescending(x => x).ToList();
            if (top5.Count < 5)
            {
                Console.WriteLine(string.Join(" ", top5));
                return;
            }
            else
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write($"{top5[j]} ");
                }
            }
        }
    }
}