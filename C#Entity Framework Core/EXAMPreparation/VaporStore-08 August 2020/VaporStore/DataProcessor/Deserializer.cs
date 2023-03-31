using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;
using VaporStore.Data.Models;
using VaporStore.Data.Models.Enums;
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
            StringBuilder sb = new StringBuilder();
            ImportUserDto[] userDtos = JsonConvert.DeserializeObject<ImportUserDto[]>(jsonString);
            List<User> users = new List<User>();

            foreach (var userDto in userDtos)
            {
                if (!IsValid(userDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                List<Card> userCards = new List<Card>();
                bool allCardsIsValid = true;

                foreach (var cardDto in userDto.Cards)
                {
                    if (!IsValid(cardDto))
                    {
                        allCardsIsValid = false;
                        break;
                    }
                    Object cardTypeResult;
                    bool isCardTypeValid = Enum.TryParse(typeof(CardType),
                        cardDto.Type, out cardTypeResult);
                    if (!isCardTypeValid)
                    {
                        allCardsIsValid = false;
                        break;
                    }
                    CardType cardType = (CardType)cardTypeResult;
                    userCards.Add(new Card()
                    {
                        Number = cardDto.Number,
                        Cvc = cardDto.Cvc,
                        Type = cardType
                    });
                }
                if (!allCardsIsValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                if (userCards.Count == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                var user = new User()
                {
                    Username = userDto.UserName,
                    FullName = userDto.FullName,
                    Email = userDto.Email,
                    Age = userDto.Age,
                    Cards = userCards
                };
                users.Add(user);
                sb.AppendLine(String.Format(SuccessfullyImportedUser, user.Username, user.Cards.Count));
            }
            context.Users.AddRange(users);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPurchaseDto[]),
                new XmlRootAttribute("Purchases"));
            using StringReader stringReader = new StringReader(xmlString);
            ImportPurchaseDto[] purchaseDtos = (ImportPurchaseDto[])xmlSerializer
                .Deserialize(stringReader);

            List<Purchase> purchases = new List<Purchase>();
            foreach (var purchaseDto in purchaseDtos)
            {
                if (!IsValid(purchaseDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Object purchaseTypeObj;
                bool isPurchaseTypeVaild = Enum.TryParse(typeof(PurchaseType),
                    purchaseDto.PurchaseType, out purchaseTypeObj);

                if (!isPurchaseTypeVaild)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                PurchaseType purchaseType = (PurchaseType)purchaseTypeObj;
                DateTime date;
                bool isDateValid = DateTime.TryParseExact(purchaseDto.Date, "dd/MM/yyyy HH:mm",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
                if (!isDateValid)
                {
                    sb.Append(ErrorMessage); 
                    continue;
                }
                Card card = context
                    .Cards.FirstOrDefault(c => c.Number == purchaseDto.CardNumber);
                if (card == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Game game = context
                    .Games.FirstOrDefault(g => g.Name == purchaseDto.GameTitle);
                if (game == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Purchase purchase = new Purchase()
                {
                    Type = purchaseType,
                    Date = date,
                    ProductKey = purchaseDto.Key,
                    Game = game,
                    Card = card
                };
                purchases.Add(purchase);
                sb.AppendLine(String.Format(SuccessfullyImportedPurchase, purchase.Game.Name,
                    purchase.Card.User.Username));
            }
            context.Purchases.AddRange(purchases);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}