using System.Globalization;
using System.Text;
using BookShop.Models.Enums;

namespace BookShop
{
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();

            //Pr.02 Age Restriction
            //var input = Console.ReadLine();
            //var result = GetBooksByAgeRestriction(db, input);
            //Console.WriteLine(result);

            //Pr.03 Golden Books
            //var result = GetGoldenBooks(db);
            //Console.WriteLine(result);

            //Pr.04 Books by Price
            //var result = GetBooksByPrice(db);
            //Console.WriteLine(result);

            //Pr.05 Not Released In
            //int input = int.Parse(Console.ReadLine());
            //var result = GetBooksNotReleasedIn(db, input);
            //Console.WriteLine(result);

            //Pr.06 Book Titles by Category
            //var input = Console.ReadLine();
            //var result = GetBooksByCategory(db, input);
            //Console.WriteLine(result);

            //Pr.07 Released Before Date
            //var input = Console.ReadLine();
            //var result = GetBooksReleasedBefore(db, input);
            //Console.WriteLine(result);

            //Pr.08 Author Search
            //var input = Console.ReadLine();
            //var result = GetAuthorNamesEndingIn(db, input);
            //Console.WriteLine(result);

            //Pr.09 Book Search
            //var input = Console.ReadLine();
            //var result = GetBookTitlesContaining(db, input);
            //Console.WriteLine(result);

            //Pr.10 Book Search by Author
            //var input = Console.ReadLine();
            //var result = GetBooksByAuthor(db, input);
            //Console.WriteLine(result);

            //Pr.11 Count Books
            int input = int.Parse(Console.ReadLine());
            var result = CountBooks(db, input);
            Console.WriteLine(result);


            //DbInitializer.ResetDatabase(db);
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            AgeRestriction ageRestriction;
            bool isParsed = Enum.TryParse(command, true, out ageRestriction);
            if (!isParsed)
            {
                return String.Empty;
            }
            var books = string.Join($"{Environment.NewLine}", context
                .Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToArray());
            return books;
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var books = string.Join($"{Environment.NewLine}", context
                .Books
                .Where(b =>b.EditionType == EditionType.Gold && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray());
            return books;
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = string.Join($"{Environment.NewLine}", context
                .Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(b => $"{b.Title} - ${b.Price:f2}")
                .ToArray());
            return books;
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = string.Join($"{Environment.NewLine}", context
                .Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray());
            return books;
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categories = input.ToLower().Split(new []{' ', '\t', '\r', '\n'}, StringSplitOptions.RemoveEmptyEntries);

            var books = string.Join($"{Environment.NewLine}", context
                .Books
                .Where(b => b.BookCategories.Any(c => categories.Contains(c.Category.Name.ToLower())))
                .Select(b => b.Title)
                .OrderBy(t => t));
            return books;
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            StringBuilder sb = new StringBuilder();
            var submittedDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context
                .Books
                .Where(b => b.ReleaseDate < submittedDate)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    Title = b.Title,
                    EditionType = b.EditionType,
                    Price = b.Price
                })
                .ToArray();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:f2}");
            }
            return sb.ToString().TrimEnd();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = string.Join($"{Environment.NewLine}", context
                .Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => a.FirstName + " " + a.LastName)
                .OrderBy(a => a));
            return authors;
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var givenString = input.ToLower();

            var books = string.Join($"{Environment.NewLine}", context
                .Books
                .Where(b => b.Title.ToLower().Contains(givenString))
                .Select(b => b.Title)
                .OrderBy(b => b));
            return books;
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var givenString = input.ToLower();

            var books = string.Join($"{Environment.NewLine}", context
                .Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(givenString))
                .OrderBy(b => b.BookId)
                .Select(b => $"{b.Title} ({b.Author.FirstName} {b.Author.LastName})")
                .ToArray());
            return books;
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var booksCount = context
                .Books
                .Where(b => b.Title.Length > lengthCheck)
                .ToList()
                .Count();
            return booksCount;
        }


    }
}