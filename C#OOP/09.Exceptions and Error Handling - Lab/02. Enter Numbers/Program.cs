using System;
using System.Collections.Generic;

namespace _02._Enter_Numbers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int start = 1;
            int end = 100;
            int count = 0;

            List<int> numbers = new List<int>();
            while (count < 10)
            {
                start = ReadNumber(start, end, numbers, ref count);
            }
            Console.WriteLine(String.Join(", ", numbers));
        }
        public static int ReadNumber(int start, int end, List<int> numbers, ref int count)
        {
            count++;
            int num = 0;
            try
            {
                num = int.Parse(Console.ReadLine());
                if (!(start < num && num < end))
                {
                    while (!(start < num && num < end))
                    {
                        Console.WriteLine($"Your number is not in range {start} - {end}!");
                        num = int.Parse(Console.ReadLine());
                    }
                }
                numbers.Add(num);
            }
            catch (FormatException)
            {
                count--;
                Console.WriteLine("Invalid Number!");
            }
            catch
            {
                count--;
                Console.WriteLine("Invalid Number!");
            }
            return num;
        }
    }
}

//        public static void Main(string[] args)
//        {
//            int start = 1;
//            int end = 100;
//            int count = 0;
//            List<int> numList = new List<int>();

//            while (count < 10)
//            {
//                int? n = ReadNumber(ref start, ref end);

//                if (n.HasValue)
//                {
//                    count++;
//                    numList.Add((int)n);
//                }

//                if (start > end)
//                {
//                    Console.WriteLine("No more integers to choose from. Range length is zero.");
//                    break;
//                }
//            }

//            Console.WriteLine("Finnished. {0} integers have been chosen", count);
//            string implode = string.Join(", ", numList.ToArray());
//            Console.WriteLine(implode);
//        }
//        public static int? ReadNumber(ref int start, ref int end)
//        {
//            Console.Write("Enter an integer [{0}..{1}] inclusive: ", start, end);
//            try
//            {
//                int n = int.Parse(Console.ReadLine());

//                if (n < start || n > end) throw new ArgumentOutOfRangeException();
//                if (n == end)
//                {
//                    end = n - 1;
//                    return n;
//                }

//                if (n + 1 <= end)
//                {
//                    start = n + 1;
//                    return n;
//                }

//                return null;
//            }
//            catch (ArgumentOutOfRangeException)
//            {
//                return null;
//            }
//            catch (ArgumentNullException)
//            {
//                return null;
//            }
//            catch (FormatException)
//            {
//                return null;
//            }
//            catch (OverflowException)
//            {
//                return null;
//            }
//        }
//    }
//}