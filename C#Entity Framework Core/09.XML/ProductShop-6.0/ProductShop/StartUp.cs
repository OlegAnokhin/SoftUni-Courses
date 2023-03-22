using AutoMapper.QueryableExtensions;
using ProductShop.DTOs.Export;

namespace ProductShop
{

    using AutoMapper;
    using Utilities;

    using DTOs.Import;
    using Data;
    using Models;
    using System.Xml.Serialization;

    public class StartUp
    {
        public static void Main()
        {
            //Query 1. Import Users
            //ProductShopContext context = new ProductShopContext();
            //string inputXml = File.ReadAllText("../../../Datasets/users.xml");
            //string result = ImportUsers(context, inputXml);
            //Console.WriteLine(result);

            //Query 2. Import Products
            //ProductShopContext context = new ProductShopContext();
            //string inputXml = File.ReadAllText("../../../Datasets/products.xml");
            //string result = ImportProducts(context, inputXml);
            //Console.WriteLine(result);

            //Query 3. Import Categories
            //ProductShopContext context = new ProductShopContext();
            //string inputXml = File.ReadAllText("../../../Datasets/categories.xml");
            //string result = ImportCategories(context, inputXml);
            //Console.WriteLine(result);

            //Query 4. Import Categories and Products
            //ProductShopContext context = new ProductShopContext();
            //string inputXml = File.ReadAllText("../../../Datasets/categories-products.xml");
            //string result = ImportCategoryProducts(context, inputXml);
            //Console.WriteLine(result);

            //Query 5. Export Products In Range
            //using ProductShopContext context = new ProductShopContext();
            //string result = GetProductsInRange(context);
            //Console.WriteLine(result);

            //Query 6. Export Sold Products
            using ProductShopContext context = new ProductShopContext();
            string result = GetSoldProducts(context);
            Console.WriteLine(result);


        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ImportUserDto[] userDtos =
                xmlHelper.Deserialize<ImportUserDto[]>(inputXml, "Users");
            ICollection<User> validUsers = new HashSet<User>();
            foreach (var userDto in userDtos)
            {
                if (string.IsNullOrEmpty(userDto.FirstName) ||
                    string.IsNullOrEmpty(userDto.LastName))
                {
                    continue;
                }
                User user = mapper.Map<User>(userDto);
                validUsers.Add(user);
            }
            context.Users.AddRange(validUsers);
            context.SaveChanges();

            return $"Successfully imported {validUsers.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ImportProductDto[] productDtos =
                xmlHelper.Deserialize<ImportProductDto[]>(inputXml, "Products");
            ICollection<Product> validProducts = new HashSet<Product>();
            foreach (var productDto in productDtos)
            {
                if (string.IsNullOrEmpty(productDto.Name))
                {
                    continue;
                }
                Product product = mapper.Map<Product>(productDto);
                validProducts.Add(product);
            }
            context.Products.AddRange(validProducts);
            context.SaveChanges();

            return $"Successfully imported {validProducts.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ImportCategoryDto[] categoryDtos =
                xmlHelper.Deserialize<ImportCategoryDto[]>(inputXml, "Categories");
            ICollection<Category> validCategories = new HashSet<Category>();
            foreach (var categoryDto in categoryDtos)
            {
                if (string.IsNullOrEmpty(categoryDto.Name))
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

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportCategoryProductDto[]),
                new XmlRootAttribute("CategoryProducts"));
            var categoryProducts = new List<CategoryProduct>();

            using (var reader = new StringReader(inputXml))
            {
                var categoryProductsFromDto = (ImportCategoryProductDto[])xmlSerializer.Deserialize(reader);

                var categoryIds = context.Categories.Select(c => c.Id).ToList();
                var productIds = context.Products.Select(p => p.Id).ToList();

                foreach (var dto in categoryProductsFromDto)
                 {
                    if (categoryIds.Any(c => c == dto.CategoryId &&
                                             productIds.Any(p => p == dto.ProductId)))
                    {
                        var categoryProduct = new CategoryProduct
                        {
                            CategoryId = dto.CategoryId,
                            ProductId = dto.ProductId
                        };

                        categoryProducts.Add(categoryProduct);
                    }
                }

                context.CategoryProducts.AddRange(categoryProducts);
                context.SaveChanges();
            }

            return $"Successfully imported {context.CategoryProducts.Count()}";
            //IMapper mapper = InitializeAutoMapper();
            //XmlHelper xmlHelper = new XmlHelper();

            //ImportCategoryProductDto[] categoryProductDtos =
            //    xmlHelper.Deserialize<ImportCategoryProductDto[]>(inputXml, "CategoryProducts");
            //ICollection<CategoryProduct> validCategoriesProducts = new HashSet<CategoryProduct>();
            //foreach (var categoryProductDto in categoryProductDtos)
            //{
            //    if (categoryProductDto.CategoryId == null ||
            //        categoryProductDto.ProductId == null)
            //    {
            //        continue;
            //    }
            //    CategoryProduct categoryProduct = mapper.Map<CategoryProduct>(categoryProductDto);
            //    validCategoriesProducts.Add(categoryProduct);
            //}
            //context.CategoryProducts.AddRange(validCategoriesProducts);
            // context.SaveChanges();

            //return $"Successfully imported {validCategoriesProducts.Count}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ExportProductDto[] productsDtos = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Take(10)
                .ProjectTo<ExportProductDto>(mapper.ConfigurationProvider)
                .ToArray();
            return xmlHelper.Serialize<ExportProductDto[]>(productsDtos, "Products");
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ExportProductDto[] productsDtos = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Take(10)
                .ProjectTo<ExportProductDto>(mapper.ConfigurationProvider)
                .ToArray();
            return xmlHelper.Serialize<ExportProductDto[]>(productsDtos, "Products");

        }

        private static IMapper InitializeAutoMapper()
            => new Mapper(new MapperConfiguration(cfg => { cfg.AddProfile<ProductShopProfile>(); }));
    }
}