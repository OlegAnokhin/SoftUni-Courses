namespace Artillery.DataProcessor
{
    using Data;
    using Data.Models;
    using Data.Models.Enums;
    using ImportDto;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        private const string ErrorMessage =
            "Invalid data.";
        private const string SuccessfulImportCountry =
            "Successfully import {0} with {1} army personnel.";
        private const string SuccessfulImportManufacturer =
            "Successfully import manufacturer {0} founded in {1}.";
        private const string SuccessfulImportShell =
            "Successfully import shell caliber #{0} weight {1} kg.";
        private const string SuccessfulImportGun =
            "Successfully import gun {0} with a total weight of {1} kg. and barrel length of {2} m.";

        public static string ImportCountries(ArtilleryContext context, string xmlString)
        {
            var deserializer = new XmlSerializer(typeof(ImportCountryDto[]), new XmlRootAttribute("Countries"));
            var countries = (ImportCountryDto[])deserializer.Deserialize(new StringReader(xmlString));
            var validCountries = new List<Country>();
            var sb = new StringBuilder();

            foreach (var country in countries)
            {
                if (!IsValid(country))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                validCountries.Add(new Country()
                {
                    CountryName = country.CountryName,
                    ArmySize = country.ArmySize
                });
                sb.AppendLine(String.Format(SuccessfulImportCountry, country.CountryName, country.ArmySize));
            }
            context.Countries.AddRange(validCountries);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportManufacturers(ArtilleryContext context, string xmlString)
        {
            var deserializer = new XmlSerializer(typeof(ManufacturerDto[]), new XmlRootAttribute("Manufacturers"));
            var manufacturers = (ManufacturerDto[])deserializer.Deserialize(new StringReader(xmlString));
            var validManufacturers = new List<Manufacturer>();
            var sb = new StringBuilder();

            foreach (var manufacturer in manufacturers)
            {
                var uniqueManufacturer = validManufacturers.FirstOrDefault(x => x.ManufacturerName == manufacturer.ManufacturerName);
                
                if (!IsValid(manufacturer) || uniqueManufacturer != null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                var validManufacturer = new Manufacturer
                {
                    ManufacturerName = manufacturer.ManufacturerName,
                    Founded = manufacturer.Founded
                };
                validManufacturers.Add(validManufacturer);

                var foundedArr = validManufacturer.Founded.Split(", ").ToArray();
                var last = foundedArr.Skip(Math.Max(0, foundedArr.Count() -2)).ToArray();

                sb.AppendLine(String.Format(SuccessfulImportManufacturer, manufacturer.ManufacturerName, string.Join(", ", last)));
            }
            context.Manufacturers.AddRange(validManufacturers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportShells(ArtilleryContext context, string xmlString)
        {
            var deserializer = new XmlSerializer(typeof(ShellDto[]), new XmlRootAttribute("Shells"));
            var shells = (ShellDto[])deserializer.Deserialize(new StringReader(xmlString));
            var validShells = new List<Shell>();
            var sb = new StringBuilder();

            foreach (var shell in shells)
            {
                if (!IsValid(shell))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                validShells.Add(new Shell()
                {
                    ShellWeight = shell.ShellWeight,
                    Caliber = shell.Caliber
                });
                sb.AppendLine(String.Format(SuccessfulImportShell, shell.Caliber, shell.ShellWeight));
            }
            context.Shells.AddRange(validShells);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportGuns(ArtilleryContext context, string jsonString)
        {
            var validGunTypes = new string[] { "Howitzer", "Mortar", "FieldGun", "AntiAircraftGun", "MountainGun", "AntiTankGun" };
            var guns = JsonConvert.DeserializeObject<GunDto[]>(jsonString);
            var validGuns = new List<Gun>();
            var sb = new StringBuilder();

            foreach (var gun in guns)
            {
                if (!IsValid(gun) ||
                    !validGunTypes.Contains(gun.GunType))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Gun validGun = new Gun
                {
                    ManufacturerId = gun.ManufacturerId,
                    GunWeight = gun.GunWeight,
                    BarrelLength = gun.BarrelLength,
                    NumberBuild = gun.NumberBuild,
                    Range = gun.Range,
                    GunType = (GunType)Enum.Parse(typeof(GunType), gun.GunType),
                    ShellId = gun.ShellId
                };
                foreach (var country in gun.Countries)
                {
                    validGun.CountriesGuns.Add( new CountryGun
                    {
                        CountryId = country.Id,
                        Gun = validGun
                    });
                }
                validGuns.Add(validGun);
                sb.AppendLine(String.Format(SuccessfulImportGun, gun.GunType, gun.GunWeight, gun.BarrelLength));
            }
            context.Guns.AddRange(validGuns);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }
        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}