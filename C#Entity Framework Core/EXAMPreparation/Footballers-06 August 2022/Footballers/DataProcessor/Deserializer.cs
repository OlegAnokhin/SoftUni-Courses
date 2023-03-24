using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using Footballers.Data.Models;
using Footballers.Data.Models.Enums;
using Footballers.DataProcessor.ImportDto;
using Newtonsoft.Json;

namespace Footballers.DataProcessor
{
    using Footballers.Data;
    using System.ComponentModel.DataAnnotations;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCoach
            = "Successfully imported coach - {0} with {1} footballers.";

        private const string SuccessfullyImportedTeam
            = "Successfully imported team - {0} with {1} footballers.";

        public static string ImportCoaches(FootballersContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            ImportCoachDto[] coaches;
            XmlSerializer serializer = new XmlSerializer(typeof(ImportCoachDto[]), new XmlRootAttribute("Coaches"));

            using (TextReader reader = new StringReader(xmlString))
            {
                coaches = (ImportCoachDto[])serializer.Deserialize(reader);

            }

            List<Coach> coachEntitys = new List<Coach>();
            foreach (var coach in coaches)
            {
                Coach coachEntity = new Coach();
                coachEntity.Name = coach.Name ?? "";
                coachEntity.Nationality = coach.Nationality ?? "";
                if (!IsValid(coachEntity))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                foreach (var footballer in coach.Footballers)
                {
                    Footballer footballerEntity = new Footballer();
                    try
                    {
                        footballerEntity.Name = footballer.Name ?? "";
                        footballerEntity.PositionType = (PositionType)footballer.PositionType;
                        footballerEntity.ContractEndDate =
                            DateTime.ParseExact(footballer.ContractStartDate, "dd/MM/yyyy",
                                CultureInfo.InvariantCulture);
                        footballerEntity.ContractEndDate =
                            DateTime.ParseExact(footballer.ContractEndDate, "dd/MM/yyyy",
                                CultureInfo.InvariantCulture);
                        footballerEntity.BestSkillType = (BestSkillType)footballer.BestSkillType;
                        if (IsValid(footballerEntity)
                            || footballerEntity.ContractEndDate < footballerEntity.ContractStartDate)
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }
                    }
                    catch (Exception)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    coachEntity.Footballers.Add(footballerEntity);
                }
                sb.AppendLine(string.Format(SuccessfullyImportedCoach, coachEntity.Name, coachEntity.Footballers.Count));
            }
            context.Coaches.AddRange(coachEntitys);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportTeams(FootballersContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            var teamsEntities = new List<Team>();

            var teams = JsonConvert.DeserializeObject<TeamDto[]>(jsonString);

            foreach (var team in teams)
            {
                Team teamEntity = new Team();
                teamEntity.Name = team.Name ?? "";
                teamEntity.Nationality = team.Nationality ?? "";

                if (!int.TryParse(team.Trophies, out var trophiesCount)
                    || trophiesCount <= 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                teamEntity.Trophies = trophiesCount;
                if (!IsValid(teamEntity))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                foreach (var footballer in team.Footballers.Distinct())
                {
                    Footballer? footballerEntity = context.Footballers.Find(footballer);

                    if (footballerEntity == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                 //   if (!teamEntity.TeamsFootballers.Any(f => f.FootballerId == footballer))
                 //   {
                        teamEntity.TeamsFootballers.Add(new TeamFootballer()
                            {Footballer = footballerEntity, FootballerId = footballer});
                   // }
                }

                teamsEntities.Add(teamEntity);
                sb.AppendLine(String.Format(SuccessfullyImportedTeam, teamEntity.Name, teamEntity.TeamsFootballers.Count));

            }
            context.Teams.AddRange(teamsEntities);
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
