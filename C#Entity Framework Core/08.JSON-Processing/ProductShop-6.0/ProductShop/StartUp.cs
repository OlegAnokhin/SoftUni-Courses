using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using ProductShop.DTOs.Export;

namespace ProductShop
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using AutoMapper;
    using Newtonsoft.Json;

    using Data;
    using Models;
    using DTOs.Import;

    public class StartUp
    {
        public static void Main()
        {
            //Query1
            //ProductShopContext context = new ProductShopContext();

            ////context.Database.EnsureDeleted();
            ////context.Database.EnsureCreated();
            //string inputString = File.ReadAllText(@"../../../Datasets/users.json");
            //string result = ImportUsers(context, inputString);
            //Console.WriteLine(result);

            //Query2
            //ProductShopContext context = new ProductShopContext();
            //string inputString = File.ReadAllText(@"../../../Datasets/products.json");
            //string result = ImportProducts(context, inputString);
            //Console.WriteLine(result);

            //Query3
            //ProductShopContext context = new ProductShopContext();
            //string inputString = File.ReadAllText(@"../../../Datasets/categories.json");
            //string result = ImportCategories(context, inputString);
            //Console.WriteLine(result);

            //Query4
            //ProductShopContext context = new ProductShopContext();
            //string inputString = File.ReadAllText(@"../../../Datasets/categories-products.json");
            //string result = ImportCategoryProducts(context, inputString);
            //Console.WriteLine(result);

            //Query 5
            //ProductShopContext context = new ProductShopContext();
            //string result = GetProductsInRange(context);
            //Console.WriteLine(result);

            //Query 6
            //ProductShopContext context = new ProductShopContext();
            //string result = GetSoldProducts(context);
            //Console.WriteLine(result);

            //Query 7
            //ProductShopContext context = new ProductShopContext();
            //string result = GetCategoriesByProductsCount(context);
            //Console.WriteLine(result);

            //Query 8
            //ProductShopContext context = new ProductShopContext();
            //string result = GetUsersWithProducts(context);
            //Console.WriteLine(result);

        }


        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportUserDTO[] userDtos = JsonConvert.DeserializeObject<ImportUserDTO[]>(inputJson);

            ICollection<User> validUsers = new HashSet<User>();

            foreach (var userDto in userDtos)
            {
                User user = mapper.Map<User>(userDto);
                validUsers.Add(user);
            }
            context.Users.AddRange(validUsers);
            context.SaveChanges();

            return $"Successfully imported {validUsers.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();
            ImportProductDTO[] productsDtos = JsonConvert.DeserializeObject<ImportProductDTO[]>(inputJson);
            ICollection<Product> validProducts = new HashSet<Product>();
            foreach (var productDto in productsDtos)
            {
                Product product = mapper.Map<Product>(productDto);
                validProducts.Add(product);
            }
            context.Products.AddRange(validProducts);
            context.SaveChanges();
            return $"Successfully imported {validProducts.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportCategoryDTO[] categoryDtos = JsonConvert.DeserializeObject<ImportCategoryDTO[]>(inputJson);

            ICollection<Category> validCategories = new HashSet<Category>();
            foreach (var categoryDto in categoryDtos)
            {
                if (String.IsNullOrEmpty(categoryDto.Name))
                {
                    continue;
                }
                Category category = mapper.Map<Category>(categoryDto);
                validCategories.Add(category);
            }
            context.Categories.AddRange(validCategories);
            context.SaveChanges();
            return $"Successfully imported {validCategories.Count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportCategorieProductDTO[] cpDtos = JsonConvert.DeserializeObject<ImportCategorieProductDTO[]>(inputJson);

            ICollection<CategoryProduct> validEntries = new HashSet<CategoryProduct>();

            foreach (ImportCategorieProductDTO cpDto in cpDtos)
            {
                //if (!context.Categories.Any(c => c.Id == cpDto.CategoryId) ||
                //    !context.Products.Any(p => p.Id == cpDto.ProductId))
                //{
                //    continue;
                //}
                CategoryProduct categoryProduct = mapper.Map<CategoryProduct>(cpDto);
                validEntries.Add(categoryProduct);
                
            }
            context.CategoriesProducts.AddRange(validEntries);
            context.SaveChanges();
            return $"Successfully imported {validEntries.Count}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            // OPTION 1 - Anonymous object + manual mapping
            //var products = context.Products
            //    .Where(p => p.Price >= 500 && p.Price <= 1000)
            //    .OrderBy(p => p.Price)
            //    .Select(p => new 
            //    {
            //        name = p.Name,
            //        price = p.Price,
            //        seller = p.Seller.FirstName + " " + p.Seller.LastName,
            //    })
            //    .AsNoTracking()
            //    .ToArray();
            //return JsonConvert.SerializeObject(products, Formatting.Indented);

            // OPTION 2 - DTO + AutoMapper
            IMapper mapper = CreateMapper();
            ExportProductInRangeDTO[] productDtos = context
                .Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .AsNoTracking()
                .ProjectTo<ExportProductInRangeDTO>(mapper.ConfigurationProvider)
                .ToArray();
            return JsonConvert.SerializeObject(productDtos, Formatting.Indented);

        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            IContractResolver contractResolver = ConfigureCamelCaseNaming();

            var userWithSoldProducts = context.Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    SoldProducts = u.ProductsSold
                        .Where(p => p.Buyer != null)
                        .Select(p => new
                        {
                            p.Name,
                            p.Price,
                            BuyerFirstName = p.Buyer.FirstName,
                            BuyerLastName = p.Buyer.LastName
                        })
                        .ToArray()
                })
                .AsNoTracking()
                .ToArray();

            return JsonConvert.SerializeObject(userWithSoldProducts, 
                Formatting.Indented, 
                new JsonSerializerSettings()
                {
                    ContractResolver = contractResolver
                });
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            IContractResolver contractResolver = ConfigureCamelCaseNaming();

            var categories = context.Categories
                .OrderByDescending(c => c.CategoriesProducts.Count)
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.CategoriesProducts.Count,
                    averagePrice = Math.Round((double)c.CategoriesProducts.Average(p => p.Product.Price), 2).ToString(),
                    totalRevenue = Math.Round((double)c.CategoriesProducts.Sum(p => p.Product.Price), 2).ToString()
                })
                .ToArray();
            return JsonConvert.SerializeObject(categories, 
                Formatting.Indented
                //,
                //new JsonSerializerSettings()
                //{
                //    ContractResolver = contractResolver
                //}
                );
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            IContractResolver contractResolver = ConfigureCamelCaseNaming();

            var users = context.Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    u.Age,
                    SoldProducts = new
                    {
                        Count = u.ProductsSold.Count(p => p.Buyer != null),
                        Products = u.ProductsSold
                            .Where(p => p.Buyer != null)
                            .Select(p => new
                            {
                                p.Name,
                                p.Price
                            })
                            .ToArray()
                    }
                })
                .OrderByDescending(u => u.SoldProducts.Count)
                .AsNoTracking()
                .ToArray();
            var userWrapperDto = new
            {
                UsersCount = users.Length,
                Users = users
            };

            return JsonConvert.SerializeObject(userWrapperDto,
                Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ContractResolver = contractResolver,
                    NullValueHandling = NullValueHandling.Ignore
                });

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
            return new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(typeof(ProductShopProfile));
            }));
        }
    }
}