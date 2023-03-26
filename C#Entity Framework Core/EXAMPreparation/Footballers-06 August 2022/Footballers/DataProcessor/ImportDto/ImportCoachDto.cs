namespace Footballers.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Coach")]
    public class ImportCoachDto
    {
        [Required]
        [XmlElement("Name")]
        [MinLength(2)]
        [MaxLength(40)]
        public string Name { get; set; }

        [Required]
        [XmlElement("Nationality")]
        public string? Nationality { get; set; }

        [XmlArray("Footballers")]
        public virtual ImportFootballerDto[] Footballers { get; set; }
    }
}
