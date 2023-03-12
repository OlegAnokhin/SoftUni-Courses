using AutoMapper;
using FastFood.Models;
using FastFood.Web.ViewModels.Categories;
using FastFood.Web.ViewModels.Items;
using FastFood.Web.ViewModels.Positions;

namespace FastFood.Services.Mapping;

public class FastFoodProfile : Profile
{
    public FastFoodProfile()
    {
        //Positions
        this.CreateMap<CreatePositionInputModel, Position>()
            .ForMember(x => x.Name,
                y => y.MapFrom(s => s.PositionName));

        this.CreateMap<Position, PositionsAllViewModel>()
            .ForMember(x => x.Name,
                y => y.MapFrom(s => s.Name));

        //Category
        this.CreateMap<CreateCategoryInputModel, Category>()
            .ForMember(x => x.Name, y => y.MapFrom(x => x.CategoryName));

        this.CreateMap<Category, CategoryAllViewModel>();

        //Items
        this.CreateMap<Category, CreateItemViewModel>()
            .ForMember(x => x.CategoryId,
                x => x.MapFrom(src => src.Id))
            .ForMember(x => x.CategoryName,
                y => y.MapFrom(s => s.Name));

        this.CreateMap<CreateItemInputModel, Item>();

        this.CreateMap<Item, ItemsAllViewModel>()
            .ForMember(d => d.Category,
                opt => opt.MapFrom(s => s.Category.Name));

    }
}