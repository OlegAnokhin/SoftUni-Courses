using System;
using System.Diagnostics;
using System.Text;

namespace Lab_and_Exercise_Strings_and_Text_Processing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Stopwatch sw = new Stopwatch();

            //sw.Start();

            //string text = "";

            //for (int i = 0; i < 50000; i++)

            //    text += i;

            //sw.Stop();

            //Console.WriteLine(sw.ElapsedMilliseconds);

            //Stopwatch sw = new Stopwatch();

            //sw.Start();

            //StringBuilder text = new StringBuilder();

            //for (int i = 0; i < 200000; i++)

            //    text.Append(i);

            //sw.Stop();

            //Console.WriteLine(sw.ElapsedMilliseconds);


            //StringBuilder sb = new StringBuilder();
            //sb.AppendLine("Hello");
            //sb.Append("Oleg");
            //sb.Insert(0, "Zdrawei");
            //sb.Replace("Hello", "Hi!");

            //Console.WriteLine(sb);
            //sb.Clear();
            //Console.WriteLine(sb);

            //string finalString = sb.ToString(0, 2);


            string text = "! text !";
            Console.WriteLine(text.Trim(new char[] {' ', '!'})); // premahwa wsichki simwoli
        }
    }
}
