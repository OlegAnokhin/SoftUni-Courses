using FastFood.Common.EntityConfiguration;
using System.ComponentModel.DataAnnotations;

namespace FastFood.Web.ViewModels.Positions;

public class CreatePositionInputModel
{
    [MinLength(ViewModelsValidation.PositionNameMinLength)]
    [MaxLength(ViewModelsValidation.PositionNameMaxLength)]
    public string PositionName { get; set; } = null!;
}