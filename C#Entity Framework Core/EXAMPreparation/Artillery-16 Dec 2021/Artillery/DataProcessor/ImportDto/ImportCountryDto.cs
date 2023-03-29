namespace Artillery.DataProcessor.ImportDto
{
    using System.Xml.Serialization;
    using System.ComponentModel.DataAnnotations;

    [XmlType("Country")]
    public class ImportCountryDto
    {
        [Required]
        [MinLength(4)]
        [MaxLength(60)]
        [XmlElement("CountryName")]
        public string CountryName { get; set; }

        [Required]
        [Range(50000, 10000000)]
        [XmlElement("ArmySize")]
        public int ArmySize { get; set; }
    }
}