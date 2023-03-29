namespace Artillery.DataProcessor.ExportDto
{
    using System.Xml.Serialization;

    [XmlType("Country")]
    public class CountriesExportDto
    {
        [XmlAttribute("Country")]
        public string CountryName { get; set; }

        [XmlAttribute("ArmySize")]
        public int ArmySize { get; set; }
    }
}