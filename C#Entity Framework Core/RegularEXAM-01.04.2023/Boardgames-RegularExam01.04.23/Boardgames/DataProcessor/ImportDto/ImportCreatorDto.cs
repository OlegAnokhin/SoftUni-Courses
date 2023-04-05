using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Boardgames.Common;

namespace Boardgames.DataProcessor.ImportDto
{
    [XmlType("Creator")]
    public class ImportCreatorDto
    {
        [Required]
        [MinLength(ValidationConstants.CreatorFirstNameMinLenght)]
        [MaxLength(ValidationConstants.CreatorFirstNameMaxLenght)]
        [XmlElement("FirstName")]
        public string FirstName { get; set; } = null!;

        [Required]
        [MinLength(ValidationConstants.CreatorLastNameMinLenght)]
        [MaxLength(ValidationConstants.CreatorLastNameMaxLenght)]
        [XmlElement("LastName")]
        public string LastName { get; set; } = null!;

        [XmlArray("Boardgames")]
        public ImportBoardgameDto[] Boardgames { get; set; }
    }
}