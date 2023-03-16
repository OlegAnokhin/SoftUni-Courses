namespace CarDealer.DTOs.Import
{
    using System.Xml.Serialization;

    [XmlType("Car")]

    public class ImportCarDto
    {
        [XmlAttribute("make")]
        public string Make { get; set; } = null!;

        [XmlAttribute("model")]
        public string Model { get; set; } = null!;

        [XmlAttribute("traveledDistance")]
        public long TravelledDistance { get; set; }

        [XmlArray("parts")]
        public ImportCarPartDto[] Parts { get; set; } = null!;
    }
}
