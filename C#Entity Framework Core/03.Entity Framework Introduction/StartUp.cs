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

        //Pr14
        string result = DeleteProjectById(dbContext);
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
        foreach (var employee in employee147)
        {
            output.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:f2}");
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
}
