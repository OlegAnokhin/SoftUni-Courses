using ProductShop.DTOs.Export;

namespace ProductShop
{
    using DTOs.Import;
    using Models;

    using AutoMapper;

    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            //User
            CreateMap<ImportUserDto, User>();

            //Product
            CreateMap<ImportProductDto, Product>();
            this.CreateMap<Product, ExportProductDto>()
                .ForMember(d => d.ProductName,
                    opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.ProductPrice,
                    opt => opt.MapFrom(s => s.Price))
                .ForMember(d => d.BuyerName,
                    opt => opt.MapFrom(s => $"{s.Buyer.FirstName} {s.Buyer.LastName}"));

            //Categories
            CreateMap<ImportCategoryDto, Category>();

            //CategoryProduct
            CreateMap<ImportCategoryProductDto, CategoryProduct>();
            //CreateMap<ImportCategoryProductDto, Product>()
            //    .ForMember(d => d.Id, opt => opt.MapFrom(s => s.ProductId));
            //CreateMap<ImportCategoryProductDto, Category>()
            //    .ForMember(d => d.Id, opt => opt.MapFrom(s => s.CategoryId));



        }
    }
}