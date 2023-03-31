using System.Xml.Serialization;

namespace VaporStore.DataProcessor.ExportDto
{
    [XmlType("Game")]
    public class ExportGameDto
    {
        [XmlElement("Genre")]
        public string Genre { get; set; }

        [XmlElement("Price")]
        public decimal Price { get; set; }

        [XmlAttribute("title")]
        public string Name { get; set; }
    }
}