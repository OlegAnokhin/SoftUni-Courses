using System;
using System.Linq;

namespace Arrays___Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //int[] numbersArray = new int[6];

            //Console.WriteLine(numbersArray.Length);

            //numbersArray[0] = 88;

            //Console.WriteLine(numbersArray[0]); 
            //Console.WriteLine(numbersArray[1]);


            //int indexToSearch = 6;
            //bool inArray = indexToSearch >= 0 && indexToSearch < numbersArray.Length;




            //string[] stringsArray = new string[3];

            //double[] doublesArray = new double[8]; 


            //int numberOfItems = int.Parse(Console.ReadLine());
            //int [] items = new int[numberOfItems];

            //for (int i = 0; i < numberOfItems; i++)
            //{
            //    items[i] = int.Parse(Console.ReadLine());
            //}

            //string[] values = Console.ReadLine().Split(' ' , StringSplitOptions.RemoveEmptyEntries);
            //int[] newitem = new int[values.Length];

            //for (int i = 0; i < values.Length; i++)
            //{
            //    newitem[i] = int.Parse(values[i]);
            //    Console.WriteLine($"index: {i} value : {newitem[i]}");
            //}

            //string[] names =
            //{
            //    "Ivan",
            //    "Gosho",
            //    "Slavcho"
            //};

            //foreach (string name in names)
            //{
            //    Console.WriteLine(name);
            //}


            // PR_01
            //int input = int.Parse(Console.ReadLine());
            //string[] dayOfWeek =
            //{
            //    "Monday",
            //    "Thuesday",
            //    "Wednesday",
            //    "Thursday",
            //    "Friday",
            //    "Saturday",
            //    "Sunday"
            //};
            //if (input >= 1 && input <= dayOfWeek.Length)
            //{
            //    Console.WriteLine(dayOfWeek[input - 1]);
            //}
            //else
            //{
            //    Console.WriteLine("Invalid day!");
            //}

            //PR_02
            //int numtimes = int.Parse(Console.ReadLine());
            //int[] input = new int[numtimes];
            //for (int i = 0; i < numtimes; i++)
            //{
            //    int number = int.Parse(Console.ReadLine());
            //    input[i] = number;
            //}
            //Array.Reverse(input);
            //Console.WriteLine(string.Join(" ", input));


            //PR_03
            //double[] array = Console.ReadLine()
            //.Split(' ')
            //.Select(double.Parse)
            //.ToArray();
            //for (int i = 0; i < array.Length; i++)
            //{
            //    if (array[i] == 0)
            //    {
            //        array[i] = 0;
            //    }
            //    Console.WriteLine($"{array[i]} => {(int)Math.Round(array[i], MidpointRounding.AwayFromZero)}");
            //}


            ////PR_04
            //string[] input = Console.ReadLine().Split();
            //Array.Reverse(input);
            //Console.WriteLine(String.Join(" ", input));


            //PR_05
            //double[] input = Console.ReadLine()
            //.Split(' ')
            //.Select(double.Parse)
            //.ToArray();
            //double evenSum = 0;
            //for (int i = 0; i < input.Length; i++)
            //{
            //    if (input[i] % 2 == 0)
            //    {
            //       evenSum += input[i];
            //    }
            //}
            //Console.WriteLine(evenSum);


            //PR_06
            //double[] input = Console.ReadLine()
            //.Split(' ')
            //.Select(double.Parse)
            //.ToArray();
            //double evenSum = 0;
            //double oddSum = 0;
            //for (int i = 0; i < input.Length; i++)
            //{
            //    if (input[i] % 2 == 0)
            //    {
            //        evenSum += input[i];
            //    }
            //    else
            //    {
            //        oddSum += input[i];
            //    }
            //}
            //Console.WriteLine(evenSum - oddSum);


            //PR_07
            //int[] array1 = Console.ReadLine()
            //.Split(' ')
            //.Select(int.Parse)
            //.ToArray();
            //int[] array2 = Console.ReadLine()
            //.Split(' ')
            //.Select(int.Parse)
            //.ToArray();
            //int sum = 0;
            //bool isNot = false;
            //for (int i = 0; i < array1.Length; i++)
            //{
            //    if (array1[i] != array2[i])
            //    {
            //        isNot = true;
            //        Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
            //        break;
            //    }
            //    if (array1[i] == array2[i])
            //    {
            //        sum += array1[i];
            //    }
            //}
            //if (!isNot)
            //{
            //    Console.WriteLine($"Arrays are identical. Sum: {sum}");
            //}


            //PR_08

            //int[] array = Console.ReadLine()
            //.Split(' ')
            //.Select(int.Parse)
            //.ToArray();

            //int firstLength = array.Length;

            //for (int a = 0; a < firstLength - 1; a++)
            //{
            //    int[] condensedArray = new int[array.Length - 1];
            //    for (int b = 0; b < array.Length - 1; b++)
            //    {
            //        condensedArray[b] = array[b] + array[b + 1];
            //    }
            //    array = condensedArray;
            //}
            //Console.WriteLine(array[0]);

        }
    }
}
