using Newtonsoft.Json;
using System.Text;
using System.Xml.Serialization;
using TeisterMask.DataProcessor.ExportDto;

namespace TeisterMask.DataProcessor
{
    using Data;
    using System.Globalization;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            var sb = new StringBuilder();
            var xmlSerializer = new XmlSerializer(typeof(ExportProjectDto[]), new XmlRootAttribute("Projects"));
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            using StringWriter sw = new StringWriter(sb);
            ExportProjectDto[] projects = context
                .Projects
                .Where(p => p.Tasks.Any())
                .ToArray()
                .Select(p => new ExportProjectDto()
                {
                    Name = p.Name,
                    HasEndDate = p.DueDate.HasValue ? "Yes" : "No",
                    TaskCount = p.Tasks.Count,
                    Tasks = p.Tasks
                        .ToArray()
                        .Select(t => new ExportTaskDto()
                        {
                            Name = t.Name,
                            Label = t.LabelType.ToString()
                        })
                        .OrderBy(t => t.Name)
                        .ToArray()
                })
                .OrderByDescending(p => p.TaskCount)
                .ThenBy(p => p.Name)
                .ToArray();
            xmlSerializer.Serialize(sw, projects, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var employees = context
                .Employees
                .Where(e => e.EmployeesTasks.Any(et => et.Task.OpenDate >= date))
                .ToArray()
                .Select(e => new
                {
                    e.Username,
                    Tasks = e.EmployeesTasks
                        .Where(et => et.Task.OpenDate >= date)
                        .ToArray()
                        .OrderByDescending(еt => еt.Task.DueDate)
                        .ThenBy(еt => еt.Task.Name)
                        .Select(еt => new
                        {
                            TaskName = еt.Task.Name,
                            OpenDate = еt.Task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                            DueDate = еt.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                            LabelType = еt.Task.LabelType.ToString(),
                            ExecutionType = еt.Task.ExecutionType.ToString(),
                        })
                        .ToArray()
                })
                .OrderByDescending(e => e.Tasks.Length)
                .ThenBy(e => e.Username)
                .Take(10)
                .ToArray();
            return JsonConvert.SerializeObject(employees, Formatting.Indented);
        }
    }
}