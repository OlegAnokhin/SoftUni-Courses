namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    public class WordCount
    {
        static void Main(string[] args)
        {
            string wordPath = @"words.txt";
            string textPath = @"text.txt";
            string outputPath = @"output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordPath, string textPath, string outputPath)
        {
            Dictionary<string, int> wordCounts = new Dictionary<string, int>();
            StreamReader wordReader = new StreamReader(wordPath);
            using (wordReader)
            {
                string[] words = wordReader.ReadLine().Split(" ");
                var textReader = new StreamReader(textPath);
                using (textReader)
                {
                    var writer = new StreamWriter(outputPath);
                    using (writer)
                    {
                        string line;
                        while ((line = textReader.ReadLine()) != null)
                        {
                            line = line.ToLower();
                            if (line.Contains(words[0]))
                            {
                                if (!wordCounts.ContainsKey(words[0]))
                                {
                                    wordCounts.Add(words[0], 1);
                                }
                                else
                                {
                                    wordCounts[words[0]]++;
                                }
                            }
                            if (line.Contains(words[1]))
                            {
                                if (!wordCounts.ContainsKey(words[1]))
                                {
                                    wordCounts.Add(words[1], 1);
                                }
                                else
                                {
                                    wordCounts[words[1]]++;
                                }
                            }
                            if (line.Contains(words[2]))
                            {
                                if (!wordCounts.ContainsKey(words[2]))
                                {
                                    wordCounts.Add(words[2], 1);
                                }
                                else
                                {
                                    wordCounts[words[2]]++;
                                }
                            }
                        }
                        var wordCount = wordCounts.OrderByDescending(x => x.Value).ToList();
                        foreach (var word in wordCount)
                        {
                            writer.WriteLine($"{word.Key} - {word.Value}");
                        }
                    }
                }
            }
        }
    }
}