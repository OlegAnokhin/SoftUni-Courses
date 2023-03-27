namespace SoftJail.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using AutoMapper;
    using ImportDto;
    using Newtonsoft.Json;
    using Data;
    using Data.Models;
    using Data.Models.Enums;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportDepartmentWithCellsDto[] departmentDtos =
                JsonConvert.DeserializeObject<ImportDepartmentWithCellsDto[]>(jsonString);

            ICollection<Department> validDepartments = new List<Department>();

            foreach (var depDto in departmentDtos)
            {
                if (!IsValid(depDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }
                if (!depDto.Cells.Any())
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }
                if (depDto.Cells.Any(c => !IsValid(c)))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }
                Department department = new Department()
                {
                    Name = depDto.Name
                };
                foreach (var cellDto in depDto.Cells)
                {
                    Cell cell = Mapper.Map<Cell>(cellDto);
                    department.Cells.Add(cell);
                }
                validDepartments.Add(department);
                sb.AppendLine($"Imported {department.Name} with {department.Cells.Count} cells");
            }
            context.Departments.AddRange(validDepartments);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportPrisonerWithMailDto[] prisonerDtos =
                JsonConvert.DeserializeObject<ImportPrisonerWithMailDto[]>(jsonString);

            ICollection<Prisoner> validPrisoners = new List<Prisoner>();

            foreach (var prisonerDto in prisonerDtos)
            {
                if (!IsValid(prisonerDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                if (prisonerDto.Mails.Any(m => !IsValid(m)))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                bool isIncarcerationDateValid =
                    DateTime.TryParseExact(prisonerDto.IncarcerationDate, "dd/MM/yyyy", 
                    CultureInfo.InvariantCulture,
               DateTimeStyles.None, out DateTime incarceratioDate);
                if (!isIncarcerationDateValid)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                DateTime? releaseDate = null;
                if (!String.IsNullOrEmpty(prisonerDto.ReleaseDate))
                {
                    bool isReleaseDateValid =
                        DateTime.TryParseExact(prisonerDto.ReleaseDate, "dd/MM/yyyy",
                            CultureInfo.InvariantCulture,
                            DateTimeStyles.None, out DateTime releaseDateValue);
                    if (!isReleaseDateValid)
                    {
                        sb.AppendLine("Invalid Data");
                        continue;
                    }

                    releaseDate = releaseDateValue;
                }

                Prisoner prisoner = new Prisoner()
                {
                    FullName = prisonerDto.FullName,
                    Nickname = prisonerDto.Nickname,
                    Age = prisonerDto.Age,
                    IncarcerationDate = incarceratioDate,
                    ReleaseDate = releaseDate,
                    Bail = prisonerDto.Bail,
                    CellId = prisonerDto.CellId
                };
                foreach (var mailDto in prisonerDto.Mails)
                {
                    Mail mail = Mapper.Map<Mail>(mailDto);
                    prisoner.Mails.Add(mail);
                }
                validPrisoners.Add(prisoner);
                sb.AppendLine($"Imported {prisoner.FullName} {prisoner.Age} years old");
            }
            context.Prisoners.AddRange(validPrisoners);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Officers");
            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(ImportOfficerWithPrisonersDto[]), xmlRoot);

            using StringReader reader = new StringReader(xmlString);
            ImportOfficerWithPrisonersDto[] officerDtos = (ImportOfficerWithPrisonersDto[])
                xmlSerializer.Deserialize(reader);

            ICollection<Officer> validOfficers = new List<Officer>();
            foreach (var officerDto in officerDtos)
            {
                if (!IsValid(officerDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                bool isPositionEnumValid = 
                    Enum.TryParse(typeof(Position), 
                        officerDto.Position, 
                        out object positionObj);
                if (!isPositionEnumValid)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }
                bool isWeaponEnumValid =
                    Enum.TryParse(typeof(Weapon),
                        officerDto.Weapon,
                        out object weaponObj);
                if (!isWeaponEnumValid)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }
                //if (!context.Departments.Any(d => d.Id == officerDto.DepartmentId))
                //{
                //    sb.AppendLine("Invalid Data");
                //    continue;
                //}

                Officer officer = new Officer()
                {
                    FullName = officerDto.FullName,
                    Salary = officerDto.Salary,
                    Position = (Position)positionObj,
                    Weapon = (Weapon)weaponObj,
                    DepartmentId = officerDto.DepartmentId
                };
                foreach (var prDto in officerDto.Prisoners)
                {
                    OfficerPrisoner officerPrisoner = new OfficerPrisoner()
                    {
                        Officer = officer,
                        PrisonerId = prDto.Id
                    };
                    officer.OfficerPrisoners.Add(officerPrisoner);
                }
                validOfficers.Add(officer);
                sb.AppendLine($"Imported {officer.FullName} ({officer.OfficerPrisoners.Count} prisoners)");
            }
            context.Officers.AddRange(validOfficers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}