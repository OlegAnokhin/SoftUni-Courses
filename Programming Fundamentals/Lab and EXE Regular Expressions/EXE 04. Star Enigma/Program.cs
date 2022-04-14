using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

namespace EXE_04._Star_Enigma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> attacketPlanets = new List<string>();
            List<string> destroedPlanets = new List<string>();

            string pattern = @"@(?<planet>[A-Za-z]+)[^\@\-\!\:\>]*?\:(\d+)[^\@\-\!\:\>]*?\!(?<attackType>A|D){1}\![^\@\-\!\:\>]*?\-\>(\d+)";

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string encryptedMessage = Console.ReadLine();
                string decryptedMessage = DecryptMessage(encryptedMessage);

                Match orderInfo = Regex.Match(decryptedMessage, pattern);
                if (orderInfo.Success)
                {
                    string planet = orderInfo.Groups["planet"].Value;
                    string attackTupe = orderInfo.Groups["attackType"].Value;

                    if (attackTupe == "A")
                    {
                        attacketPlanets.Add(planet);
                    }
                    else if (attackTupe == "D")
                    {
                        destroedPlanets.Add(planet);
                    }
                }
            }
            PrintOutput(attacketPlanets, destroedPlanets);
        }

        static void PrintOutput(List<string> attacketPlanets, List<string> destroedPlanet)
        {
            Console.WriteLine($"Attacked planets: {attacketPlanets.Count}");
            foreach (var planetName in attacketPlanets.OrderBy(n => n))
            {
                Console.WriteLine($"-> {planetName}");
            }

            Console.WriteLine($"Destroyed planets: {destroedPlanet.Count}");
            foreach (var planetName in destroedPlanet.OrderBy(n => n))
            {
                Console.WriteLine($"-> {planetName}");
            }
        }

        static string DecryptMessage(string encryptedMessage)
        {
            StringBuilder decryptedMessage = new StringBuilder();

            int decruptionKey = GetDecryptionKey(encryptedMessage);
            foreach (char currCh in encryptedMessage)
            {
                char decryptedCh = (char)(currCh - decruptionKey);
                decryptedMessage.Append(decryptedCh);
            }
            return decryptedMessage.ToString();
        }
        static int GetDecryptionKey(string encryptMessage)
        {
            string decryptPattern = "[star]{1}";
            MatchCollection matches =
                Regex.Matches(encryptMessage, decryptPattern, RegexOptions.IgnoreCase);
            return matches.Count;
        }
    }
}