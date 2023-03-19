namespace CarDealer
{
    using Data;
    using Models;
    using DTOs.Import;
    using static DTOs.Export.CarWithPriceDto;

    using AutoMapper;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

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
            //CarDealerContext context = new CarDealerContext();
            //string inputString = File.ReadAllText(@"../../../Datasets/sales.json");
            //string result = ImportSales(context, inputString);
            //Console.WriteLine(result);

            //Query 14. Export Ordered Customers
            //CarDealerContext context = new CarDealerContext();
            //string result = GetOrderedCustomers(context);
            //Console.WriteLine(result);

            //Query 15. Export Cars from Make Toyota
            //CarDealerContext context = new CarDealerContext();
            //string result = GetCarsFromMakeToyota(context);
            //Console.WriteLine(result);

            //Query 16. Export Local Suppliers
            //CarDealerContext context = new CarDealerContext();
            //string result = GetLocalSuppliers(context);
            //Console.WriteLine(result);

            //Query 17. Export Cars with Their List of Parts
            //CarDealerContext context = new CarDealerContext();
            //string result = GetCarsWithTheirListOfParts(context);
            //Console.WriteLine(result);

            //Query 18. Export Total Sales by Customer
            //CarDealerContext context = new CarDealerContext();
            //string result = GetTotalSalesByCustomer(context);
            //Console.WriteLine(result);

            //Query 19. Export Sales with Applied Discount
            //CarDealerContext context = new CarDealerContext();
            //string result = GetSalesWithAppliedDiscount(context);
            //Console.WriteLine(result);
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

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy"),
                    IsYoungDriver = c.IsYoungDriver
                })
                .ToArray();
            return JsonConvert.SerializeObject(customers, Formatting.Indented);
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TraveledDistance)
                .Select(c => new
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance
                })
                .ToArray();
            return JsonConvert.SerializeObject(cars, Formatting.Indented);
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count,
                })
                .ToArray();
            return JsonConvert.SerializeObject(suppliers, Formatting.Indented);

        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new
                {
                    car = new
                    {
                        Make = c.Make,
                        Model = c.Model,
                        TraveledDistance = c.TraveledDistance
                    },
                    parts = c.PartsCars
                        .Select(ps => new
                        {
                            Name = ps.Part.Name,
                            Price = ps.Part.Price.ToString("f2")
                        }).ToList()
                }).ToList();

            return JsonConvert.SerializeObject(cars, Formatting.Indented);

        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            //opt 1 not work
            var totalSales = context.Sales
                .Where(c => c.Customer.Sales.Count() > 0)
                .Select(c => new
                {
                    fullName = c.Customer.Name,
                    boughtCars = c.Customer.Sales.Count(),
                    spentMoney = c.Customer.Sales.Sum(c => c.Car.PartsCars.Sum(pc => pc.Part.Price))
                })
                .OrderByDescending(ts => ts.spentMoney)
                .ThenByDescending(ts => ts.boughtCars)
                .ToList();
            return JsonConvert.SerializeObject(totalSales, Formatting.Indented);
            
            //opt 2 not work too
            //var totalSales = context.Customers
            //    .Where(c => c.Sales.Count() > 0)
            //    .Select(c => new
            //    {
            //        fullName = c.Name,
            //        boughtCars = c.Sales.Count(),
            //        spentMoney = c.Sales.Sum(s => s.Car.PartsCars.Sum(pc => pc.Part.Price))
            //    })
            //    .OrderByDescending(ts => ts.spentMoney)
            //    .ThenByDescending(ts => ts.boughtCars)
            //    .ToList();
            //return JsonConvert.SerializeObject(totalSales, Formatting.Indented);
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var salesInfo = context.Sales
                .Select(c => new
                {
                    car = new
                    {
                        Make = c.Car.Make,
                        Model = c.Car.Model,
                        TraveledDistance = c.Car.TraveledDistance
                    },
                    customerName = c.Customer.Name,
                    discount = c.Discount.ToString("f2"),
                    price = c.Car.PartsCars.Sum(pc => pc.Part.Price).ToString("f2"),
                    priceWithDiscount =
                        ((c.Car.PartsCars.Sum(pc => pc.Part.Price)) * (1 - c.Discount * 0.01m)).ToString("f2")
                }).Take(10).ToList();

            return JsonConvert.SerializeObject(salesInfo, Formatting.Indented);
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