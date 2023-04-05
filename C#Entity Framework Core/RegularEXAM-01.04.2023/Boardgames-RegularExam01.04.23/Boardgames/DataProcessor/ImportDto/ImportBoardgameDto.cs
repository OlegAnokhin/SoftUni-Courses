using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Boardgames.Common;

namespace Boardgames.DataProcessor.ImportDto
{
    [XmlType("Boardgame")]
    public class ImportBoardgameDto
    {
        [Required]
        [MinLength(ValidationConstants.BoardgameNameMinLenght)]
        [MaxLength(ValidationConstants.BoardgameNameMaxLenght)]
        [XmlElement("Name")]
        public string Name { get; set; } = null!;

        [Required]
        [Range(ValidationConstants.BoardgameRatingMinValue, 
               ValidationConstants.BoardgameRatingMaxValue)]
        [XmlElement("Rating")]
        public double Rating { get; set; }

        [Required]
        [Range(ValidationConstants.BoardgameYearMinValue,
               ValidationConstants.BoardgameYearMaxValue)]
        [XmlElement("YearPublished")]
        public int YearPublished { get; set; }

        [Required]
        [XmlElement("CategoryType")]
        public int CategoryType { get; set; }

        [Required]
        [XmlElement("Mechanics")]
        public string Mechanics { get; set; } = null!;
    }
}