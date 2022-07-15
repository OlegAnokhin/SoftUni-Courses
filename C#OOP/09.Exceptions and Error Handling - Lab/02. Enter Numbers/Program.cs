using System;
using System.Collections.Generic;

namespace _02._Enter_Numbers
{
    public class Program
    {
        //        static void Main(string[] args)
        //        {
        //            int start = 1;
        //            int end = 100;
        //            int count = 0;

        //            List<int> numbers = new List<int>();
        //            while (count < 10)
        //            {
        //                start = ReadNumber(start, end, numbers, ref count);
        //            }
        //            Console.WriteLine(String.Join(", ", numbers));
        //        }
        //        public static int ReadNumber(int start, int end, List<int> numbers, ref int count)
        //        {
        //            count++;
        //            int num = 0;
        //            try
        //            {
        //                num = int.Parse(Console.ReadLine());
        //                if (!(start < num && num < end))
        //                {
        //                    while (!(start < num && num < end))
        //                    {
        //                        throw new ArgumentException();
        //                    }
        //                }
        //                numbers.Add(num);
        //            }
        //            catch (FormatException)
        //            {
        //                count--;
        //                Console.WriteLine("Invalid Number!");
        //            }
        //            catch (ArgumentException)
        //            {
        //                count--;
        //                Console.WriteLine($"Your number is not in range {start} - {end}!");
        //            }
        //            catch
        //            {
        //                count--;
        //                Console.WriteLine("Invalid Number!");
        //            }
        //            return num;
        //        }
        //    }
        //}


        static void Main()
        {
            int start = 1;
            int end = 100;
            int[] numbers = new int[10];

            for (int i = 0; i < 10; i++)
            {
                while (numbers[i] <= start || numbers[i] >= end || (i > 0 && numbers[i] <= numbers[i - 1]))
                {
                    bool exeption = false;
                    try
                    {
                        numbers[i] = int.Parse(Console.ReadLine());
                        if ((numbers[i] <= start || numbers[i] >= end) && !exeption)
                        {
                            throw new ArgumentException();
                            //  Console.WriteLine($"Your number is not in range {numbers[i - 1]} - 100!");
                        }
                        else if (i > 0 && numbers[i] <= numbers[i - 1] && !exeption)
                        {
                            throw new ArgumentException();
                            //  Console.WriteLine($"Number must be bigger than {numbers[i - 1]}!");
                        }
                    }
                    catch (ArgumentException)
                    {
                        if (numbers[i] <= 1)
                        {
                            Console.WriteLine($"Your number is not in range {numbers[i]} - 100!");
                        }
                        else
                        {
                            Console.WriteLine($"Your number is not in range {numbers[i - 1]} - 100!");
                        }
                    }
                    catch (Exception exc)
                    {
                        Console.WriteLine("Invalid Number!");
                        exeption = true;
                    }
                    //if ((numbers[i] <= start || numbers[i] >= end) && !exeption)
                    //{
                    //    Console.WriteLine($"Your number is not in range {numbers[i - 1]} - 100!");
                    //}
                    //else if (i > 0 && numbers[i] <= numbers[i - 1] && !exeption)
                    //{
                    //    Console.WriteLine($"Number must be bigger than {numbers[i - 1]}!");
                    //}
                }
                if (numbers[i] == 99)
                {
                    break;
                }
            }
            Console.WriteLine(String.Join(", ", numbers));
        }
    }
}