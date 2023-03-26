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
                        footballerEntity.ContractStartDate =
                            DateTime.ParseExact(footballer.ContractStartDate, "dd/MM/yyyy",
                                CultureInfo.InvariantCulture);
                        footballerEntity.ContractEndDate =
                            DateTime.ParseExact(footballer.ContractEndDate, "dd/MM/yyyy",
                                CultureInfo.InvariantCulture);
                        footballerEntity.BestSkillType = (BestSkillType)footballer.BestSkillType;
                        if (!IsValid(footballerEntity)
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
