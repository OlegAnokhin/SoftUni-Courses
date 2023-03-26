using System.Xml.Serialization;

namespace Footballers.DataProcessor.ExportDto
{
    [XmlType("Coach")]
    public class ExportCoachDto
    {
        [XmlElement("CoachName")]
        public string Name { get; set; }

        [XmlElement("FootballersCount")]
        public int FootballersCount { get; set; }
        
        [XmlArray("Footballers")] 
        public ExportCoachFootballerDto[] Footballers { get; set; }
    }
}
