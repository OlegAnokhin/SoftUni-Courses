﻿using AutoMapper;
using FastFood.Models;
using FastFood.Web.ViewModels.Categories;
using FastFood.Web.ViewModels.Positions;

namespace FastFood.Services.Mapping;

public class FastFoodProfile : Profile
{
    public FastFoodProfile()
    {
        //Positions
        this.CreateMap<CreatePositionInputModel, Position>()
            .ForMember(x => x.Name, y => y.MapFrom(s => s.PositionName));

        this.CreateMap<Position, PositionsAllViewModel>()
            .ForMember(x => x.Name, y => y.MapFrom(s => s.Name));

        this.CreateMap<CreateCategoryInputModel, Category>()
            .ForMember(x => x.Name, y => y.MapFrom(x => x.CategoryName));

        this.CreateMap<Category, CategoryAllViewModel>();
    }
}