using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Articles_2._0
{
    class Article
    {
        public Article(string title, string content, string author)
        {
            this.Title = title;
            this.Content = content;
            this.Author = author;
        }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public override string ToString()
        {
            return $"{this.Title} -{this.Content}:{this.Author}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Article> articles = new List<Article>();

            int numberOfArticle = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfArticle; i++)
            {
            string[] input = Console.ReadLine()
                            .Split(",", StringSplitOptions.RemoveEmptyEntries)
                            .ToArray();

                string title = input[0];
                string content = input[1];
                string author = input[2];

                Article currentArticle = new Article(title, content, author);

                articles.Add(currentArticle);
            }
            string command = Console.ReadLine();

            if (command == "title")
            {
                articles = articles.OrderBy(s => s.Title).ToList();
            }
            if (command == "content")
            {
                articles = articles.OrderBy(s => s.Content).ToList();
            }
            if (command == "author")
            {
                articles = articles.OrderBy(s => s.Author).ToList();
            }
            Console.WriteLine(string.Join(Environment.NewLine, articles));
        }
    }
}
