using ProductShop.DTOs.Export;

namespace ProductShop
{
    using AutoMapper;
    using DTOs.Import;
    using Models;

    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            //User
            this.CreateMap<ImportUserDTO, User>();

            //Product
            this.CreateMap<ImportProductDTO, Product>();
            this.CreateMap<Product, ExportProductInRangeDTO>()
                .ForMember(d => d.ProductName,
                    opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.ProductPrice,
                    opt => opt.MapFrom(s => s.Price))
                .ForMember(d => d.SellerName,
                    opt => opt.MapFrom(s => $"{s.Seller.FirstName} {s.Seller.LastName}"));

            //Category
            this.CreateMap<ImportCategoryDTO, Category>();

            //CategoryProduct
            this.CreateMap<ImportCategorieProductDTO, CategoryProduct>();

        }
    }
}
