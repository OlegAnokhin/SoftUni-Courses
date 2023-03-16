using System.Globalization;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;

namespace CarDealer
{
    using AutoMapper;

    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            //Supplier
            this.CreateMap<ImportSupplierDto, Supplier>();

            //Part
            this.CreateMap<ImportPartDto, Part>()
                .ForMember(d => d.SupplierId,
                    opt => opt.MapFrom(s => s.SupplierId.Value));
            //Car
            this.CreateMap<ImportCarDto, Car>()
                .ForSourceMember(d => d.Parts, opt => opt.DoNotValidate());

            this.CreateMap<Car, ExportCarWithDistanceDto>();

            //Customer
            this.CreateMap<ImportCustomerDto, Customer>()
                .ForMember(d => d.BirthDate,
                    opt => opt.MapFrom(s => DateTime.Parse(s.BirthDate, CultureInfo.InvariantCulture)));

            //Sale
            this.CreateMap<ImportSaleDto, Sale>()
                .ForMember(d => d.CarId, opt => opt.MapFrom(s => s.CarId.Value));



        }
    }
}
