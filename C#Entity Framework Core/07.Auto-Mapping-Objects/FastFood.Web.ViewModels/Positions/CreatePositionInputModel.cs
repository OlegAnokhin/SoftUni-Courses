using FastFood.Common.EntityConfiguration;
using System.ComponentModel.DataAnnotations;

namespace FastFood.Web.ViewModels.Positions;

public class CreatePositionInputModel
{
    [MaxLength(ViewModelsValidation.PositionNameMaxLength)]
    [MinLength(ViewModelsValidation.PositionNameMinLength)]
    public string PositionName { get; set; } = null!;
}