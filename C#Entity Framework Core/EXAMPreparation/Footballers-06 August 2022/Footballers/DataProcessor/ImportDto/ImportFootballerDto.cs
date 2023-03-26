namespace Footballers.DataProcessor.ImportDto
{
    using System.Xml.Serialization;
    using System.ComponentModel.DataAnnotations;

   [XmlType("Footballer")]
    public class ImportFootballerDto
    {
        [XmlElement("Name")]
        [Required]
        [MaxLength(40)]
        [MinLength(2)]
        public string Name { get; set; }

        [XmlElement("ContractStartDate")]
        [Required]
        public string? ContractStartDate { get; set; }

        [XmlElement("ContractEndDate")]
        [Required]
        public string? ContractEndDate { get; set; }

        [XmlElement("BestSkillType")]
        [Required]
        public int BestSkillType { get; set; }

        [XmlElement("PositionType")]
        [Required]
        public int PositionType { get; set; }
    }
}
