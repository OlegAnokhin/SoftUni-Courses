using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Advertisement_Message
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countFaceMessages = int.Parse(Console.ReadLine());
            string currentPhrases = string.Empty;
            string currentEvent = string.Empty;
            string currentAutor = string.Empty;
            string currentCity = string.Empty;

            for (int i = 0; i < countFaceMessages; i++)
            {
                string[] phrases = new string[]
                {
                    "Excellent product.",
                    "Such a great product.",
                    "I always use that product.",
                    "Best product of its category.",
                    "Exceptional product.",
                    "I can’t live without this product."
                };
                Random randomPhrases = new Random();
                for (int a = 0; a < phrases.Length; a++)
                {
                    int randomPhrasesIndex = randomPhrases.Next(0, phrases.Length);
                    currentPhrases = phrases[a];
                    phrases[a] = phrases[randomPhrasesIndex];
                    phrases[randomPhrasesIndex] = currentPhrases;
                }

                string[] events = new string[]
                {
                    "Now I feel good.",
                    "I have succeeded with this product.",
                    "Makes miracles. I am happy of the results!",
                    "I cannot believe but now I feel awesome.",
                    "Try it yourself, I am very satisfied.",
                    "I feel great!"
                };

                Random randomEvent = new Random();
                for (int b = 0; b < events.Length; b++)
                {
                    int randomEventsIndex = randomEvent.Next(0, events.Length);
                    currentEvent = events[b];
                    events[b] = events[randomEventsIndex];
                    events[randomEventsIndex] = currentEvent;
                }

                string[] autors = new string[]
                {
                    "Diana",
                    "Petya",
                    "Stella",
                    "Elena",
                    "Katya",
                    "Iva",
                    "Annie",
                    "Eva"
                };

                Random randomAutor = new Random();
                for (int c = 0; c < autors.Length; c++)
                {
                    int randomAutorsIndex = randomAutor.Next(0, autors.Length);
                    currentAutor = autors[c];
                    autors[c] = autors[randomAutorsIndex];
                    autors[randomAutorsIndex] = currentAutor;
                }

                string[] cities = new string[]
                {
                    "Burgas",
                    "Sofia",
                    "Plovdiv",
                    "Varna",
                    "Ruse"
                };

                Random randomCities = new Random();
                for (int d = 0; d < cities.Length; d++)
                {
                    int randomCitiesIndex = randomCities.Next(0, cities.Length);
                    currentCity = cities[d];
                    cities[d] = cities[randomCitiesIndex];
                    cities[randomCitiesIndex] = currentCity;

                }
                Console.WriteLine($"{currentPhrases} {currentEvent} {currentAutor} – {currentCity}.");
            }
        }
    }
}