using Newtonsoft.Json;

namespace Theatre.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Data.Models;
    using Data.Models.Enums;
    using ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Plays");

            XmlSerializer serializer = new XmlSerializer(typeof(ImportPlayDto[]), xmlRoot);
            ImportPlayDto[] plays;
            List<Play> validPlays = new List<Play>();

            using (StringReader reader = new StringReader(xmlString))
            {
                plays = (ImportPlayDto[])serializer.Deserialize(reader);
            };

            foreach (var play in plays)
            {
                if (!IsValid(play))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                TimeSpan duration = TimeSpan.ParseExact(play.Duration, "c", CultureInfo.InvariantCulture);
                if (duration.Hours < 1)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                if (!Enum.TryParse(typeof(Genre), play.Genre, out var genre))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                validPlays.Add(new Play()
                {
                    Title = play.Title,
                    Duration = duration,
                    Rating = play.Rating,
                    Genre = (Genre)genre,
                    Description = play.Description,
                    Screenwriter = play.Screenwriter
                });
                sb.AppendLine(String.Format(SuccessfulImportPlay, play.Title, play.Genre,play.Rating));
            }
            context.Plays.AddRange(validPlays);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Casts");

            XmlSerializer serializer = new XmlSerializer(typeof(ImportCastDto[]), xmlRoot);
            ImportCastDto[] casts;
            List<Cast> validCasts = new List<Cast>();

            using (StringReader reader = new StringReader(xmlString))
            {
                casts = (ImportCastDto[])serializer.Deserialize(reader);
            };
            foreach (var cast in casts)
            {
                if (!IsValid(cast))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                validCasts.Add(new Cast()
                {
                    FullName = cast.FullName,
                    IsMainCharacter = cast.IsMainCharacter,
                    PhoneNumber = cast.PhoneNumber,
                    PlayId = cast.PlayId
                });
                sb.AppendLine(String.Format(SuccessfulImportActor, cast.FullName, cast.IsMainCharacter ? "main" : "lesser"));
            }
            context.Casts.AddRange(validCasts);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            List<Theatre> validTheatres = new List<Theatre>();

            var theatres = JsonConvert.DeserializeObject<ImportTheatreWithTicketDto[]>(jsonString);

            foreach (var theatre in theatres)
            {
                if (!IsValid(theatre))
                {
                    sb.AppendLine(ErrorMessage); 
                    continue;
                }

                Theatre validTheatre = new Theatre()
                {
                    Name = theatre.Name,
                    NumberOfHalls = theatre.NumberOfHalls,
                    Director = theatre.Director
                };
                foreach (var ticket in theatre.Tickets)
                {
                    if (!IsValid(ticket))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    validTheatre.Tickets.Add(new Ticket()
                    {
                        Price = ticket.Price,
                        RowNumber = ticket.RowNumber,
                        PlayId = ticket.PlayId
                    });
                }
                validTheatres.Add(validTheatre);
                sb.AppendLine(String.Format(SuccessfulImportTheatre, validTheatre.Name, validTheatre.Tickets.Count));
            }
            context.Theatres.AddRange(validTheatres);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
