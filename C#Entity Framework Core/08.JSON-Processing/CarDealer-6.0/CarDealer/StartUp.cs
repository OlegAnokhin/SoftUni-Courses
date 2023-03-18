namespace CarDealer
{
    using DTOs.Import;
    using Models;
    using Data;

    using AutoMapper;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using System.Xml.Serialization;

    public class StartUp
    {
        public static void Main()
        {
            //Reset Databese
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();


            //Query 9. Import Suppliers
            //CarDealerContext context = new CarDealerContext();
            //string inputString = File.ReadAllText(@"../../../Datasets/suppliers.json");
            //string result = ImportSuppliers(context, inputString);
            //Console.WriteLine(result);

            //Query 10. Import Parts
            //CarDealerContext context = new CarDealerContext();
            //string inputString = File.ReadAllText(@"../../../Datasets/parts.json");
            //string result = ImportParts(context, inputString);
            //Console.WriteLine(result);

            //Query 11. Import Cars
            //CarDealerContext context = new CarDealerContext();
            //string inputString = File.ReadAllText(@"../../../Datasets/cars.json");
            //string result = ImportCars(context, inputString);
            //Console.WriteLine(result);

            //Query 12. Import Customers
            //CarDealerContext context = new CarDealerContext();
            //string inputString = File.ReadAllText(@"../../../Datasets/customers.json");
            //string result = ImportCustomers(context, inputString);
            //Console.WriteLine(result);

            //Query 13. Import Sales
            CarDealerContext context = new CarDealerContext();
            string inputString = File.ReadAllText(@"../../../Datasets/sales.json");
            string result = ImportSales(context, inputString);
            Console.WriteLine(result);


        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();
            ImportSuppliersDto[]? supplierDtos = JsonConvert.DeserializeObject<ImportSuppliersDto[]>(inputJson);
            ICollection<Supplier> valiSuppliers = new HashSet<Supplier>();

            foreach (var supplierDto in supplierDtos)
            {
                Supplier supplier = mapper.Map<Supplier>(supplierDto);
                valiSuppliers.Add(supplier);
            }

            context.Suppliers.AddRange(valiSuppliers);
            context.SaveChanges();
            return $"Successfully imported {valiSuppliers.Count}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();
            ImportPartsDto[] partDtos = JsonConvert.DeserializeObject<ImportPartsDto[]>(inputJson);
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
            return $"Successfully imported {validParts.Count}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carsDto = JsonConvert.DeserializeObject<ImportCarDto[]>(inputJson);
            var cars = new List<Car>();
            var carParts = new List<PartCar>();

            foreach (var carDto in carsDto)
            {
                var car = new Car
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TraveledDistance = carDto.TraveledDistance
                };
                foreach (var part in carDto.PartsId.Distinct())
                {
                    var carPart = new PartCar()
                    {
                        PartId = part,
                        Car = car
                    };

                    carParts.Add(carPart);
                }
            }
            context.Cars.AddRange(cars);
            context.PartsCars.AddRange(carParts);
            context.SaveChanges();
            return $"Successfully imported {context.Cars.Count()}.";
        }
        //public static string ImportCars(CarDealerContext context, string inputJson)
        //{
        //    IMapper mapper = CreateMapper();
        //    ImportCarDto[] carDtos = JsonConvert.DeserializeObject<ImportCarDto[]>(inputJson);
        //    ICollection<Car> validCars = new HashSet<Car>();
        //    foreach (var carDto in carDtos)
        //    {
        //        if (string.IsNullOrEmpty(carDto.Make) ||
        //            string.IsNullOrEmpty(carDto.Model))
        //        {
        //            continue;
        //        }
        //        Car car = mapper.Map<Car>(carDto);

        //        foreach (var partDto in carDto.Parts.DistinctBy(p => p.PartId))
        //        {
        //            if (!context.Parts.Any(p => p.Id == partDto.PartId))
        //            {
        //                continue;
        //            }

        //            PartCar carPart = new PartCar()
        //            {
        //                PartId = partDto.PartId
        //            };
        //            car.PartsCars.Add(carPart);
        //        }
        //        validCars.Add(car);
        //    }
        //    context.Cars.AddRange(validCars);
        //    context.SaveChanges();
        //    return $"Successfully imported {validCars.Count}.";
        //}

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();
            ImportCustomersDto[]? customerDtos = JsonConvert.DeserializeObject<ImportCustomersDto[]>(inputJson);
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
            return $"Successfully imported {validCustomers.Count}.";
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();
            ImportSaleDto[]? saleDtos = JsonConvert.DeserializeObject<ImportSaleDto[]>(inputJson);
            ICollection<Sale> validSales = new HashSet<Sale>();

            foreach (var saleDto in saleDtos)
            {
                //if (!saleDto.CarId.HasValue ||
                //    !context.Sales.Any(id => id.CarId != saleDto.CarId))
                //{
                //    continue;
                //}
                Sale sale = mapper.Map<Sale>(saleDto);
                validSales.Add(sale);
            }
            context.Sales.AddRange(validSales);
            context.SaveChanges();
            return $"Successfully imported {validSales.Count}.";
        }


        private static IContractResolver ConfigureCamelCaseNaming()
        {
            return new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy(false, true)
            };

        }

        private static IMapper CreateMapper()
        {
            return new Mapper(new MapperConfiguration(cfg => { cfg.AddProfile(typeof(CarDealerProfile)); }));
        }

    }
}