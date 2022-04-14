using System;
using System.Linq;
using System.Collections.Generic;

namespace _02._Articles
{
    internal class Program
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

            public void Edit(string content)
            {
                Content = content;
            }
            public void ChangeAuthor(string author)
            {
                Author = author;
            }

            public void Rename(string title)
            {
                Title = title;
            }

            public override string ToString()
            {
                return $"{this.Title} - {this.Content}: {this.Author}";
            }
        }

        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(",",StringSplitOptions.RemoveEmptyEntries);

            Article article = new Article(input[0], input[1], input[2]);

            int countOfChanges = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfChanges; i++)
            {
                string[] command = Console.ReadLine()
                .Split(":",StringSplitOptions.RemoveEmptyEntries);

                string commandType = command[0];
                string newText = command[1];


                if (commandType == "Edit")
                {
                    article.Edit(newText);
                }
                if (commandType == "ChangeAuthor")
                {
                    article.ChangeAuthor(newText);
                }
                if (commandType == "Rename")
                {
                    article.Rename(newText);
                }
            }
            Console.WriteLine(article);
        }
    }
}
