using System.Text;
using System.Xml.Serialization;
using AutoMapper.QueryableExtensions;
using CarDealer.DTOs.Export;

namespace CarDealer
{
    using AutoMapper;
    using Models;
    using Data;
    using DTOs.Import;
    using Utilities;
    using Castle.Core.Resource;

    public class StartUp
    {
        public static void Main()
        {
            //Query 9
            //CarDealerContext context = new CarDealerContext();
            //string inputXml = File.ReadAllText("../../../Datasets/suppliers.xml");
            //string result = ImportSuppliers(context, inputXml);
            //Console.WriteLine(result);

            //Query 10
            //CarDealerContext context = new CarDealerContext();
            //string inputXml = File.ReadAllText("../../../Datasets/parts.xml");
            //string result = ImportParts(context, inputXml);
            //Console.WriteLine(result);

            //Query 11
            //CarDealerContext context = new CarDealerContext();
            //string inputXml = File.ReadAllText("../../../Datasets/cars.xml");
            //string result = ImportCars(context, inputXml);
            //Console.WriteLine(result);

            ////Query 12
            //CarDealerContext context = new CarDealerContext();
            //string inputXml = File.ReadAllText("../../../Datasets/customers.xml");
            //string result = ImportCustomers(context, inputXml);
            //Console.WriteLine(result);

            //Query 13
            //CarDealerContext context = new CarDealerContext();
            //string inputXml = File.ReadAllText("../../../Datasets/sales.xml");
            //string result = ImportSales(context, inputXml);
            //Console.WriteLine(result);

            //Query 14
            //using CarDealerContext context = new CarDealerContext();
            //string result = GetCarsWithDistance(context);
            //Console.WriteLine(result);

            //Query 15
            //using CarDealerContext context = new CarDealerContext();
            //string result = GetCarsWithDistance(context);
            //Console.WriteLine(result);

            //Query 16
            //using CarDealerContext context = new CarDealerContext();
            //string result = GetCarsWithDistance(context);
            //Console.WriteLine(result);

            //Query 17
            //using CarDealerContext context = new CarDealerContext();
            //string result = GetCarsWithDistance(context);
            //Console.WriteLine(result);

            //Query 18
            //using CarDealerContext context = new CarDealerContext();
            //string result = GetCarsWithDistance(context);
            //Console.WriteLine(result);

            //Query 19
            //using CarDealerContext context = new CarDealerContext();
            //string result = GetCarsWithDistance(context);
            //Console.WriteLine(result);



        }


        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper xmlHelper = new XmlHelper();
            ImportSupplierDto[] supplierDtos =
                xmlHelper.Deserialize<ImportSupplierDto[]>(inputXml, "Suppliers");
            ICollection<Supplier> validSuppliers = new HashSet<Supplier>();
            foreach (var supplierDto in supplierDtos)
            {
                if (string.IsNullOrEmpty(supplierDto.Name))
                {
                    continue;
                }

                //manual mapping
                //Supplier supplier = new Supplier()
                //{
                //    Name = supplierDto.Name,
                //    IsImporter = supplierDto.IsImporter
                //};
                //validSuppliers.Add(supplier);

                //AutoMapping
                Supplier supplier = mapper.Map<Supplier>(supplierDto);
                validSuppliers.Add(supplier);
            }

            context.Suppliers.AddRange(validSuppliers);
            context.SaveChanges();

            return $"Successfully imported {validSuppliers.Count}";

        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ImportPartDto[] partDtos =
                xmlHelper.Deserialize<ImportPartDto[]>(inputXml, "Parts");
            ICollection<Part> validParts = new HashSet<Part>();
            foreach (var partDto in partDtos)
            {
                if (string.IsNullOrEmpty(partDto.Name))
                {
                    continue;
                }

                if (!partDto.SupplierId.HasValue ||
                    !context.Suppliers.Any(s => s.Id == partDto.SupplierId))
                {
                    continue;
                }
                Part part = mapper.Map<Part>(partDto);
                validParts.Add(part);
            }
            context.Parts.AddRange(validParts);
            context.SaveChanges();

            return $"Successfully imported {validParts.Count}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ImportCarDto[] carDtos =
                xmlHelper.Deserialize<ImportCarDto[]>(inputXml, "Cars");
            ICollection<Car> validCars = new HashSet<Car>();
            foreach (var carDto in carDtos)
            {
                if (string.IsNullOrEmpty(carDto.Make) ||
                    string.IsNullOrEmpty(carDto.Model))
                {
                    continue;
                }

                Car car = mapper.Map<Car>(carDto);
                foreach (var partDto in carDto.Parts.DistinctBy(p => p.PartId))
                {
                    if (!context.Parts.Any(p => p.Id == partDto.PartId))
                    {
                        continue;
                    }
                    PartCar carPart = new PartCar()
                    {
                        PartId = partDto.PartId
                    };
                    car.PartsCars.Add(carPart);
                }
                validCars.Add(car);
            }

            context.Cars.AddRange(validCars);
            context.SaveChanges();

            return $"Successfully imported {validCars.Count}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ImportCustomerDto[] customerDtos =
                xmlHelper.Deserialize<ImportCustomerDto[]>(inputXml, "Customers");
            ICollection<Customer> validCustomers = new HashSet<Customer>();
            foreach (var customerDto in customerDtos)
            {
                if (string.IsNullOrEmpty(customerDto.Name) ||
                    string.IsNullOrEmpty(customerDto.BirthDate))
                {
                    continue;
                }
                Customer customer = mapper.Map<Customer>(customerDto);
                validCustomers.Add(customer);
            }
            context.Customers.AddRange(validCustomers);
            context.SaveChanges();
            return $"Successfully imported {validCustomers.Count}";
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ImportSaleDto[] saleDtos =
                xmlHelper.Deserialize<ImportSaleDto[]>(inputXml, "Sales");
            //Optimization
            ICollection<int> dbCarIds = context.Cars
                .Select(c => c.Id)
                .ToArray();

            ICollection<Sale> validSales = new HashSet<Sale>();
            foreach (var saleDto in saleDtos)
            {
                //if (!saleDto.CarId.HasValue ||
                //    !context.Cars.Any(c => c.Id == saleDto.CarId.Value))
                    if (!saleDto.CarId.HasValue ||
                    !dbCarIds.Any(id => id == saleDto.CarId.Value))
                {
                    continue;
                }
                Sale sale = mapper.Map<Sale>(saleDto);
                validSales.Add(sale);
            }
            context.Sales.AddRange(validSales);
            context.SaveChanges();
            return $"Successfully imported {validSales.Count}";
        }


        public static string GetCarsWithDistance(CarDealerContext context)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ExportCarWithDistanceDto[] cars = context.Cars
                .Where(c => c.TraveledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ProjectTo<ExportCarWithDistanceDto>(mapper.ConfigurationProvider)
                .ToArray();

            return xmlHelper.Serialize<ExportCarWithDistanceDto[]>(cars, "cars");
        }


        private static IMapper InitializeAutoMapper()
            => new Mapper(new MapperConfiguration(cfg => { cfg.AddProfile<CarDealerProfile>(); }));
    }
}