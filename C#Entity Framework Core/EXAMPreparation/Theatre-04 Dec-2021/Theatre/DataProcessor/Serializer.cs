namespace Theatre.DataProcessor
{
    using Data;
    using Newtonsoft.Json;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data.Models.Enums;
    using ExportDto;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var theatres = context.Theatres
                .ToList()
                .Where(t => t.NumberOfHalls >= numbersOfHalls)
                .Where(t => t.Tickets.Count >= 20)
                .Select(t => new
                {
                    Name = t.Name,
                    Halls = t.NumberOfHalls,
                    TotalIncome = Decimal.Parse(t.Tickets
                        .Where(tc => tc.RowNumber >= 1 && tc.RowNumber <= 5)
                        .Sum(tc => tc.Price).ToString("f2")),
                    Tickets = t.Tickets
                        .Where(tc => tc.RowNumber >= 1 && tc.RowNumber <= 5)
                        .Select(tc => new
                        {
                            Price = Decimal.Parse(tc.Price.ToString("f2")),
                            RowNumber = tc.RowNumber
                        })
                        .OrderByDescending(tk => tk.Price)
                })
                .OrderByDescending(t => t.Halls)
                .ThenBy(t => t.Name)
                .ToArray();

            return JsonConvert.SerializeObject(theatres, Formatting.Indented);
        }

        public static string ExportPlays(TheatreContext context, double rating)
        {
            var plays = context.Plays
                .ToList()
                .Where(p => p.Rating <= rating)
                .Select(p => new ExportPlayDto()
                {
                    Title = p.Title,
                    Duration = p.Duration.ToString("c"),
                    Rating = p.Rating == 0f ? "Premier" : p.Rating.ToString(CultureInfo.InvariantCulture),
                    Genre = Enum.GetName(typeof(Genre), p.Genre),
                    Actors = p.Casts
                        .Where(c => c.IsMainCharacter)
                        .Select(c => new ExportActorDto()
                        {
                            FullName = c.FullName,
                            MainCharacter = $"Plays main character in '{p.Title}'."
                        })
                        .OrderByDescending(a => a.FullName)
                        .ToArray()
                })
                .OrderBy(p => p.Title)
                .ThenByDescending(p => p.Genre)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            using (StringWriter writer = new StringWriter(sb))
            {
                XmlRootAttribute root = new XmlRootAttribute("Plays");
                XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
                namespaces.Add(string.Empty, string.Empty);
                XmlSerializer serializer = new XmlSerializer(typeof(ExportPlayDto[]), root);
                serializer.Serialize(writer, plays, namespaces);
            }
            return sb.ToString().TrimEnd();
        }
    }
}