using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Word_Synonyms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pairCount = int.Parse(Console.ReadLine());

            Dictionary<string, List<string>> sinonymList = new Dictionary<string, List<string>>();  

            for (int i = 0; i < pairCount; i++)
            {
                string word = Console.ReadLine();
                string sinonym = Console.ReadLine();

                if (sinonymList.ContainsKey(word))
                {
                    sinonymList[word].Add(sinonym);
                }
                else
                {
                    List<string> newSimList = new List<string>();
                    newSimList.Add(sinonym);
                    sinonymList.Add(word, newSimList);
                }
            }
            foreach (var item in sinonymList)
            {
                Console.WriteLine($"{item.Key} - {string.Join(", ", item.Value)}");
            }
        }
    }
}
