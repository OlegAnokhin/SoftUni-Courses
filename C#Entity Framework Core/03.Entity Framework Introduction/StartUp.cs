using System.Globalization;
using System.Text;
using System.Linq;
using SoftUni.Data;
using SoftUni.Models;

namespace SoftUni;

public class StartUp
{
    static void Main(string[] args)
    {
        SoftUniContext dbContext = new SoftUniContext();

        //Pr03
        //string result = GetEmployeesFullInformation(dbContext);
        //Console.WriteLine(result);

        //Pr04
        //string result = GetEmployeesWithSalaryOver50000(dbContext);
        //Console.WriteLine(result);

        //Pr05
        //string result = GetEmployeesFromResearchAndDevelopment(dbContext);
        //Console.WriteLine(result);

        //Pr06
        //string result = AddNewAddressToEmployee(dbContext);
        //Console.WriteLine(result);

        //Pr07
        //string result = GetEmployeesInPeriod(dbContext);
        //Console.WriteLine(result);

        //Pr08
        //string result = GetAddressesByTown(dbContext);
        //Console.WriteLine(result);

        //Pr09
        //string result = GetEmployee147(dbContext);
        //Console.WriteLine(result);

        //Pr10
        //string result = GetDepartmentsWithMoreThan5Employees(dbContext);
        //Console.WriteLine(result);

        ////Pr11
        //string result = GetLatestProjects(dbContext);
        //Console.WriteLine(result);

        //Pr12
        //string result = IncreaseSalaries(dbContext);
        //Console.WriteLine(result);

        //Pr13
        //string result = GetEmployeesByFirstNameStartingWithSa(dbContext);
        //Console.WriteLine(result);

        //Pr14
        //string result = DeleteProjectById(dbContext);
        //Console.WriteLine(result);

        //Pr15
        string result = RemoveTown(dbContext);
        Console.WriteLine(result);
    }
    //Pr03
    public static string GetEmployeesFullInformation(SoftUniContext context)
    {
        StringBuilder output = new StringBuilder();

        var allEmployees = context
            .Employees
            .OrderBy(e => e.EmployeeId)
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.MiddleName,
                e.JobTitle,
                e.Salary
            })
            .ToList();
        foreach (var employee in allEmployees)
        {
            output.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:f2}");
        }
        return output.ToString().TrimEnd();
    }
    //Pr04
    public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
    {
        StringBuilder output = new StringBuilder();

        var allEmployees = context
            .Employees
            .Where(e => e.Salary > 50000)
            .OrderBy(e => e.FirstName)
            .Select(e => new
            {
                e.FirstName,
                e.Salary
            })
            .ToList();
        foreach (var employee in allEmployees)
        {
            output.AppendLine(
                $"{employee.FirstName} - {employee.Salary:f2}");
        }
        return output.ToString().TrimEnd();
    }
    //Pr05
    public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
    {
        StringBuilder output = new StringBuilder();

        var allEmployees = context
            .Employees
            .Where(e => e.Department.Name == "Research and Development")
            .OrderBy(e => e.Salary)
            .ThenByDescending(e => e.FirstName)
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.Department.Name,
                e.Salary
            })
            .ToList();
        foreach (var employee in allEmployees)
        {
            output.AppendLine(
                $"{employee.FirstName} {employee.LastName} from {employee.Name} - ${employee.Salary:f2}");
        }
        return output.ToString().TrimEnd();
    }
    //Pr06
    public static string AddNewAddressToEmployee(SoftUniContext context)
    {
        Address newAddress = new Address()
        {
            AddressText = "Vitoshka 15",
            TownId = 4
        };
        Employee nakov = context
            .Employees
            .FirstOrDefault(e => e.LastName == "Nakov");
        nakov.Address = newAddress;
        context.SaveChanges();

        StringBuilder output = new StringBuilder();
        var addresses = context
            .Employees
            .OrderByDescending(e => e.AddressId)
            .Take(10)
            .Select(e => e.Address.AddressText)
            .ToArray();
        foreach (var adrText in addresses)
        {
            output.AppendLine(adrText);
        }
        return output.ToString().TrimEnd();
    }
    //Pr07
    public static string GetEmployeesInPeriod(SoftUniContext context)
    {
        StringBuilder output = new StringBuilder();

        var allEmployeesWithProject = context
            .Employees
            //.Where(e => e.EmployeesProjects
            //    .Any(ep => ep.Project.StartDate.Year >= 2001 
            //                         && ep.Project.StartDate.Year <= 2003))
            .Take(10)
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                ManagerFirstName = e.Manager.FirstName,
                ManagerLastName = e.Manager.LastName,
                Projects = e.EmployeesProjects
                    .Where(ep => ep.Project.StartDate.Year >= 2001 &&
                                              ep.Project.StartDate.Year <= 2003)
                    .Select(ep => new
                    {
                        ProjectName = ep.Project.Name,
                        ProjectStartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                        ProjectEndDate = ep.Project.EndDate.HasValue ?
                        ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) : "not finished"
                    })
                .ToArray()
            })
            .ToArray();
        foreach (var employee in allEmployeesWithProject)
        {
            output.AppendLine(
                $"{employee.FirstName} {employee.LastName} - Manager: {employee.ManagerFirstName} {employee.ManagerLastName}");

            foreach (var project in employee.Projects)
            {
                output.AppendLine($"--{project.ProjectName} - {project.ProjectStartDate} - {project.ProjectEndDate}");
            }
        }
        return output.ToString().TrimEnd();
    }
    //Pr08
    public static string GetAddressesByTown(SoftUniContext context)
    {
        StringBuilder output = new StringBuilder();

        var allAddresses = context
            .Addresses
            .Select(e => new
            {
                e.AddressText,
                Town = e.Town.Name,
                count = e.Employees.Count()
            })
            .OrderByDescending(e => e.count)
            .ThenBy(e => e.Town)
            .ThenBy(e => e.AddressText)
            .Take(10)
            .ToArray();
        foreach (var address in allAddresses)
        {
            output.AppendLine($"{address.AddressText}, {address.Town} - {address.count} employees");
        }
        return output.ToString().TrimEnd();
    }
    //Pr09
    public static string GetEmployee147(SoftUniContext context)
    {
        StringBuilder output = new StringBuilder();

        var employee147 = context
            .Employees
            .Where(e => e.EmployeeId == 147)
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.JobTitle,
                Projects = e.EmployeesProjects
                    .Select(ep => new
                    {
                        ep.Project.Name
                    })
                    .OrderBy(ep => ep.Name)
                    .ToArray()
            })
            .ToArray();
        foreach (var employee in employee147)
        {
            output.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");

            foreach (var projects in employee.Projects)
            {
                output.AppendLine($"{projects.Name}");
            }
        }
        return output.ToString().TrimEnd();
    }
    //Pr10
    public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
    {
        StringBuilder output = new StringBuilder();

        var allDepartments = context
            .Departments
            .Where(d => d.Employees.Count > 5)
            .OrderBy(d => d.Employees.Count)
            .ThenBy(d => d.Name)
            .Select(d => new
            {
                d.Name,
                ManagerFirstName = d.Manager.FirstName,
                ManagerLastName = d.Manager.LastName,
                DepEmployees = d.Employees
                    .Select(de => new
                    {
                        de.FirstName,
                        de.LastName,
                        de.JobTitle
                    })
                    .OrderBy(de => de.FirstName)
                    .ThenBy(de => de.LastName)
                    .ToArray()
            })
            .ToArray();
        foreach (var department in allDepartments)
        {
            output.AppendLine(
                $"{department.Name} - {department.ManagerFirstName} {department.ManagerLastName}");

            foreach (var employee in department.DepEmployees)
            {
                output.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
            }
        }
        return output.ToString().TrimEnd();
    }
    //Pr11
    public static string GetLatestProjects(SoftUniContext context)
    {
        StringBuilder output = new StringBuilder();

        var latestProjects = context
            .Projects
            .OrderByDescending(lp => lp.StartDate)
            .Select(p => new
            {
                p.Name,
                p.Description,
                Date = p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
            })
            .Take(10)
            .ToArray()
            .OrderBy(p => p.Name);
        foreach (var project in latestProjects)
        {
            output.AppendLine(project.Name)
                  .AppendLine(project.Description)
                  .AppendLine((project.Date));
        }
        return output.ToString().TrimEnd();
    }
    //Pr12
    public static string IncreaseSalaries(SoftUniContext context)
    {
        StringBuilder output = new StringBuilder();

        var employees = context
            .Employees
            .Where(employee => employee.Department.Name == "Engineering"
                               || employee.Department.Name == "Tool Design"
                               || employee.Department.Name == "Marketing"
                               || employee.Department.Name == "Information Services")
            .OrderBy(employee => employee.FirstName)
            .ThenBy(employee => employee.LastName)
            .ToArray();
        foreach (var empl in employees)
        {
            empl.Salary += empl.Salary * 0.12m;
        }
        context.SaveChanges();
        foreach (var empl in employees)
        {
            output.AppendLine($"{empl.FirstName} {empl.LastName} (${empl.Salary:F2})");
        }
        return output.ToString().TrimEnd();
    }
    //Pr13
    public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
    {
        StringBuilder output = new StringBuilder();

        var employees = context
            .Employees
            .Where(e => e.FirstName.StartsWith("Sa"))
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.JobTitle,
                e.Salary
            })
            .OrderBy(e => e.FirstName)
            .ThenBy(e => e.LastName)
            .ToArray();
        foreach (var employee in employees)
        {
            output.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:f2})");
        }
        return output.ToString().TrimEnd();
    }
    //Pr14
    public static string DeleteProjectById(SoftUniContext context)
    {
        var employeeToDelete = context
            .EmployeesProjects
            .Where(ep => ep.ProjectId == 2);
        context.EmployeesProjects.RemoveRange(employeeToDelete);

        Project projectToDelete = context.Projects.Find(2);
        context.Remove(projectToDelete);
        context.SaveChanges();

        var projectNames = context.Projects
            .Take(10)
            .Select(p => p.Name)
            .ToArray();
        return String.Join(Environment.NewLine, projectNames);
    }
    //Pr15
    public static string RemoveTown(SoftUniContext context)
    {
        Town townToDelete = context
            .Towns
            .FirstOrDefault(t => t.Name == "Seattle");
        Address[] addressesToDelete = context
            .Addresses
            .Where(a => a.TownId == townToDelete.TownId)
            .ToArray();
        foreach (var e in context.Employees)
        {
            if (addressesToDelete.Any(a => a.AddressId == e.AddressId))
            {
                e.AddressId = null;
            }
        }
        int addressesCount = addressesToDelete.Length;
        context.Addresses.RemoveRange(addressesToDelete);
        context.Towns.Remove(townToDelete);
        context.SaveChanges();
        return $"{addressesCount} addresses in Seattle were deleted";
    }
}