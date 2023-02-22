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
        string result = GetAddressesByTown(dbContext);
        Console.WriteLine(result);
    }

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
            output.AppendLine(
                $"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:f2}");
        }
        return output.ToString().TrimEnd();
    }

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
        string[] addresses = context
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

    // public static string GetEmployeesInPeriod(SoftUniContext context)
    //{
    //    StringBuilder output = new StringBuilder();

    //    var allEmployeesWithProject = context
    //        .Employees
    //        .Where(e => e.EmployeesProjects.Any(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year >= 2003))
    //        .Take(10)
    //        .Select(e => new
    //        {
    //            e.FirstName,
    //            e.LastName,
    //            ManagerFirstName = e.Manager.FirstName,
    //            ManagerLastName = e.Manager.LastName,
    //            EmployeesProjects = e.EmployeesProjects
    //                .Select(ep => new
    //                {
    //                    ProjectName = ep.Project.Name,
    //                    ProjectStartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt"),
    //                    ProjectEndDate = ep.Project.EndDate.HasValue?
    //                    ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt"): "not finished"
    //                })
    //            .ToArray()
    //        })
    //        .ToArray();
    //    foreach (var employee in allEmployeesWithProject)
    //    {
    //        output.AppendLine(
    //            $"{employee.FirstName} {employee.LastName} - Manager: {employee.ManagerFirstName} {employee.ManagerLastName}");

    //        foreach (var project in employee.EmployeeProjects)
    //        {
    //            output.AppendLine($"--{project.ProjectName} - {project.ProjectStartDate} - {project.ProjectEndDate}");
    //        }
    //    }
    //    return output.ToString().TrimEnd();
    //}

    public static string GetAddressesByTown(SoftUniContext context)
    {

    }
}
