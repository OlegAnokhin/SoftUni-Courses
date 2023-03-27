namespace Trucks.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    using Common;

    [XmlType("Truck")]
    public class ImportTruckDto
    {
        [XmlElement("RegistrationNumber")]
        [MinLength(ValidationConstants.RegistrationNumberLength)]
        [MaxLength(ValidationConstants.RegistrationNumberLength)]
        [RegularExpression(ValidationConstants.TruckRegistrationRegex)]
        public string RegistrationNumber { get; set; }

        [Required]
        [XmlElement("VinNumber")]
        [MinLength(ValidationConstants.VinNumberMaxLength)]
        [MaxLength(ValidationConstants.VinNumberMaxLength)]
        public string VinNumber { get; set; } = null!;


        [XmlElement("TankCapacity")]
        [Range(ValidationConstants.TankCapacityMinValue, 
            ValidationConstants.TankCapacityMaxValue)]
        public int TankCapacity { get; set; }

        [XmlElement("CargoCapacity")]
        [Range(ValidationConstants.CargoCapacityMinValue, 
            ValidationConstants.CargoCapacityMaxValue)]
        public int CargoCapacity { get; set; }

        [Required]
        [Range(0, 3)]
        [XmlElement("CategoryType")]
        public int CategoryType { get; set; }

        [Required]
        [Range(0, 4)]
        [XmlElement("MakeType")]
        public int MakeType { get; set; }
    }
}