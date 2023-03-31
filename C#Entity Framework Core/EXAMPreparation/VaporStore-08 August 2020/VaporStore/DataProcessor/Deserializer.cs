using System.Globalization;
using System.Text;
using Newtonsoft.Json;
using VaporStore.Data.Models;
using VaporStore.DataProcessor.ImportDto;

namespace VaporStore.DataProcessor
{
    using System.ComponentModel.DataAnnotations;

    using Data;

    public static class Deserializer
    {
        public const string ErrorMessage = "Invalid Data";

        public const string SuccessfullyImportedGame = "Added {0} ({1}) with {2} tags";

        public const string SuccessfullyImportedUser = "Imported {0} with {1} cards";

        public const string SuccessfullyImportedPurchase = "Imported {0} for {1}";

        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            ImportGameDto[] gameDtos = JsonConvert.DeserializeObject<ImportGameDto[]>(jsonString);

            List<Game> games = new List<Game>();
            List<Developer> developers = new List<Developer>();
            List<Genre> genres = new List<Genre>();
            List<Tag> tags = new List<Tag>();

            foreach (var gameDto in gameDtos)
            {
                if (!IsValid(gameDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                DateTime releaseDate;
                bool isReleaseDateValid = DateTime.TryParseExact(gameDto.ReleaseDate, "yyyy-MM-dd",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out releaseDate);
                if (!isReleaseDateValid)
                {
                    sb.Append(ErrorMessage);
                    continue;
                }
                if (gameDto.Tags.Length == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Game game = new Game()
                {
                    Name = gameDto.Name,
                    Price = gameDto.Price,
                    ReleaseDate = releaseDate
                };
                Developer developer = developers
                    .FirstOrDefault(d => d.Name == gameDto.Developer);
                if (developer == null)
                {
                    Developer newDeveloper = new Developer()
                    {
                        Name = gameDto.Developer
                    };
                    developers.Add(newDeveloper);
                    game.Developer = newDeveloper;
                }
                else
                {
                    game.Developer = developer;
                }

                Genre genre = genres
                    .FirstOrDefault(g => g.Name == gameDto.Genre);
                if (genre == null)
                {
                    Genre newGenre = new Genre()
                    {
                        Name = gameDto.Genre
                    };
                    genres.Add(newGenre);
                    game.Genre = newGenre;
                }
                else
                {
                    game.Genre = genre;
                }

                foreach (var tagName in gameDto.Tags)
                {
                    if (String.IsNullOrEmpty(tagName))
                    {
                        continue;
                    }
                    Tag tag = tags
                        .FirstOrDefault(t => t.Name == tagName);
                    if (tag == null)
                    {
                        Tag newTag = new Tag()
                        {
                            Name = tagName
                        };
                        tags.Add(newTag);
                        game.GameTags.Add(new GameTag()
                        {
                            Game = game,
                            Tag = newTag
                        });
                    }
                    else
                    {
                        game.GameTags.Add(new GameTag()
                        {
                            Game = game,
                            Tag = tag
                        });
                    }
                }
                if (game.GameTags.Count == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                games.Add(game);
                sb.AppendLine(String.Format(SuccessfullyImportedGame,
                    game.Name, game.Genre.Name, game.GameTags.Count));
            }
            context.Games.AddRange(games);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            throw new NotImplementedException();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            throw new NotImplementedException();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}