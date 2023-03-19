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