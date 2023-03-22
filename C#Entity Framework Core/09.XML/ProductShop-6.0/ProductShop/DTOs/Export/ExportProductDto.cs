namespace ProductShop.DTOs.Export
{
    using System.Xml.Serialization;

    [XmlType("Product")]
    public class ExportProductDto
    {
        [XmlElement("name")]
        public string ProductName { get; set; } = null!;

        [XmlElement("price")]
        public decimal ProductPrice { get; set; }

        [XmlElement("buyer")]
        public string BuyerName { get; set; } = null!;
    }
}