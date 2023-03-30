// ReSharper disable InconsistentNaming

using Newtonsoft.Json;
using TeisterMask.Data.Models;
using TeisterMask.Data.Models.Enums;
using TeisterMask.DataProcessor.ImportDto;
using Task = TeisterMask.Data.Models.Task;

namespace TeisterMask.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    using Data;
    using System.Globalization;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            var deserializer = new XmlSerializer(typeof(ProjectDto[]), new XmlRootAttribute("Projects"));
            var objects = (ProjectDto[])deserializer.Deserialize(new StringReader(xmlString));
            var projects = new List<Project>();
            var sb = new StringBuilder();

            foreach (var project in objects)
            {
                if (!IsValid(project))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime openDate;
                bool isOpenDateValid = DateTime.TryParseExact(project.OpenDate, "dd/MM/yyyy",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out openDate);

                if (!isOpenDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                DateTime? dueDate = null;

                if (!String.IsNullOrWhiteSpace(project.DueDate))
                {
                    DateTime dueDateValid;
                    bool isDueDateValid = DateTime.TryParseExact(project.DueDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out dueDateValid);
                    if (!isDueDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    dueDate = dueDateValid;
                }
                var validProject = new Project()
                {
                    Name = project.Name,
                    OpenDate = openDate,
                    DueDate = dueDate
                };

                foreach (var task in project.Tasks)
                {
                    if (!IsValid(task))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    DateTime taskOpenDate;
                    bool isTaskOpenDateValid = 
                        DateTime.TryParseExact(task.OpenDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out taskOpenDate);
                    if (!isTaskOpenDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    DateTime taskDueDate;
                    bool isTaskDueDateValid =
                        DateTime.TryParseExact(task.DueDate, "dd/MM/yyyy",
                            CultureInfo.InvariantCulture, DateTimeStyles.None, out taskDueDate);
                    if (!isTaskDueDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    if (taskOpenDate < openDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    //Странна проверка след като искат същата като горната за DueDate.
                    if (dueDate.HasValue && taskDueDate > dueDate.Value)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Task validTask = new Task()
                    {
                        Name = task.Name,
                        OpenDate = taskOpenDate,
                        DueDate = taskDueDate,
                        ExecutionType = (ExecutionType)task.ExecutionType,
                        LabelType = (LabelType)task.LabelType
                    };
                    validProject.Tasks.Add(validTask);
                }
                projects.Add(validProject);
                sb.AppendLine(string.Format(SuccessfullyImportedProject, validProject.Name, validProject.Tasks.Count));
            }
            context.Projects.AddRange(projects);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var employeeDtos = JsonConvert.DeserializeObject<EmployeeDto[]>(jsonString);
            var employees = new List<Employee>();

            foreach (var employeeDto in employeeDtos)
            {
                if (!IsValid(employeeDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Employee employee = new Employee()
                {
                    Username = employeeDto.Username,
                    Email = employeeDto.Email,
                    Phone = employeeDto.Phone
                };
                foreach (int taskId in employeeDto.Tasks.Distinct())
                {
                    Task task = context.Tasks.Find(taskId);
                    if (task == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    employee.EmployeesTasks.Add(new EmployeeTask()
                    {
                        Task = task
                    });
                }
                employees.Add(employee);
                sb.AppendLine(String.Format(SuccessfullyImportedEmployee, employee.Username,
                    employee.EmployeesTasks.Count));
            }
            context.Employees.AddRange(employees);
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