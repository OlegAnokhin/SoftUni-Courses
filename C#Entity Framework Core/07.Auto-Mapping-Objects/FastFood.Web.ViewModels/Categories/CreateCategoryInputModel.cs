using FastFood.Common.EntityConfiguration;
using System.ComponentModel.DataAnnotations;

namespace FastFood.Web.ViewModels.Categories;

public class CreateCategoryInputModel
{
    //[MaxLength(ViewModelsValidation.CategoryNameMaxLength)]
    //[MinLength(ViewModelsValidation.CategoryNameMinLength)]
    public string CategoryName { get; set; } = null!;
}