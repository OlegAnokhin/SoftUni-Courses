using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace VaporStore.DataProcessor.ImportDto
{
    [XmlType("Purchase")]
    public class ImportPurchaseDto
    {
        [Required]
        [XmlElement("Type")]
        public string PurchaseType { get; set; } = null!;

        [Required]
        [RegularExpression(@"([A-Z0-9]{4})\-([A-Z0-9]{4})\-([A-Z0-9]{4})")]
        [XmlElement("Key")]
        public string Key { get; set; } = null!;

        [Required]
        [XmlElement("Date")]
        public string Date { get; set; } = null!;

        [Required]
        [RegularExpression(@"\d{4}\s\d{4}\s\d{4}\s\d{4}")]
        [XmlElement("Card")]
        public string CardNumber { get; set; } = null!;

        [Required]
        [XmlAttribute("title")]
        public string GameTitle { get; set; } = null!;
    }
}