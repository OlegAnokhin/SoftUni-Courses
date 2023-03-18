using System.Globalization;

namespace CarDealer
{
    using DTOs.Import;
    using Models;

    using AutoMapper;

    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            //Supplier
            this.CreateMap<ImportSuppliersDto, Supplier>();

            //Parts
            this.CreateMap<ImportPartsDto, Part>();

            //Car
            this.CreateMap<ImportCarDto, Car>()
                .ForSourceMember(d => d.PartsId,
                    opt => opt.DoNotValidate());

            //Customer
            this.CreateMap<ImportCustomersDto, Customer>()
                .ForMember(d => d.BirthDate,
                    opt => opt.MapFrom(s => DateTime
                        .Parse(s.BirthDate, CultureInfo.InvariantCulture)));

            //Sale
            this.CreateMap<ImportSaleDto, Sale>()
                .ForMember(d => d.CarId,
                    opt => opt.MapFrom(s => s.CarId.Value));



        }
    }
}
