namespace Footballers.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Coach")]
    public class ImportCoachDto
    {
        [XmlElement("Name")]
        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string? Name { get; set; }

        [XmlElement("Nationality")]
        [Required]
        public string? Nationality { get; set; }

        [XmlArray("Footballers")]
        [XmlArrayItem("Footballer")]
        public virtual ImportFootballerDto[] Footballers { get; set; }
    }
}
