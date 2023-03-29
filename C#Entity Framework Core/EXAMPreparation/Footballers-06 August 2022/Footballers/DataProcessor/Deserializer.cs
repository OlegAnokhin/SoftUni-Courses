using Castle.Core.Internal;

namespace Footballers.DataProcessor
{
    using System.Globalization;
    using System.Text;
    using Newtonsoft.Json;
    using System.Xml.Serialization;
    using System.ComponentModel.DataAnnotations;

    using Data;
    using Data.Models;
    using Data.Models.Enums;
    using ImportDto;
    using System.Diagnostics.Metrics;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCoach
            = "Successfully imported coach - {0} with {1} footballers.";

        private const string SuccessfullyImportedTeam
            = "Successfully imported team - {0} with {1} footballers.";

        public static string ImportCoaches(FootballersContext context, string xmlString)
        {
            var deserializer = new XmlSerializer(typeof(ImportCoachDto[]), new XmlRootAttribute("Coaches"));
            var objects = (ImportCoachDto[])deserializer.Deserialize(new StringReader(xmlString));
            var coaches = new List<Coach>();
            var sb = new StringBuilder();

            foreach (var coach in objects)
            {
                if (!IsValid(coach))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                if (coach.Nationality.IsNullOrEmpty())
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                ICollection<Footballer> validFootballers = new HashSet<Footballer>();
                foreach (var footballer in coach.Footballers)
                {
                    if (!IsValid(footballer))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Footballer validFootballer = new Footballer();
                    validFootballer.Name = footballer.Name;
                    validFootballer.ContractStartDate =
                        DateTime.ParseExact(footballer.ContractStartDate, "dd/MM/yyyy",
                            CultureInfo.InvariantCulture);
                    validFootballer.ContractEndDate =
                        DateTime.ParseExact(footballer.ContractEndDate, "dd/MM/yyyy",
                            CultureInfo.InvariantCulture);
                    validFootballer.BestSkillType = (BestSkillType)footballer.BestSkillType;
                    validFootballer.PositionType = (PositionType)footballer.PositionType;
                    
                    if (validFootballer.ContractStartDate > validFootballer.ContractEndDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    validFootballers.Add(validFootballer);
                }
                var validCoach = new Coach()
                {
                    Name = coach.Name,
                    Nationality = coach.Nationality,
                    Footballers = validFootballers
                };
                coaches.Add(validCoach);
                sb.AppendLine(string.Format(SuccessfullyImportedCoach, validCoach.Name, validCoach.Footballers.Count));
            }
            context.Coaches.AddRange(coaches);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }
        public static string ImportTeams(FootballersContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            ImportTeamDto[] teamDtos = JsonConvert.DeserializeObject<ImportTeamDto[]>(jsonString);

            List<Team> teams = new List<Team>();

            foreach (ImportTeamDto teamDto in teamDtos)
            {
                if (!IsValid(teamDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Team t = new Team()
                {
                    Name = teamDto.Name,
                    Nationality = teamDto.Nationality,
                    Trophies = teamDto.Trophies,
                };

                if (t.Trophies == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                foreach (int footballerId in teamDto.Footballers.Distinct())
                {
                    Footballer f = context.Footballers.Find(footballerId);
                    if (f == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    t.TeamsFootballers.Add(new TeamFootballer()
                    {
                        Footballer = f
                    });
                }
                teams.Add(t);
                sb.AppendLine(String.Format(SuccessfullyImportedTeam, t.Name, t.TeamsFootballers.Count));
            }
            context.Teams.AddRange(teams);
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
