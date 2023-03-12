namespace ProductShop
{
    using System;
    using System.IO;
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
            Mapper.Initialize(cfg => cfg.AddProfile(typeof(ProductShopProfile)));

            using ProductShopContext context = new ProductShopContext();
            string inputJson = File.ReadAllText("../../../Datasets/users.json");

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var result = ImportUsers(context, inputJson);
            Console.WriteLine(result);
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            ImportUserDTO[]? userDtos = JsonConvert.DeserializeObject<ImportUserDTO[]>(inputJson);
            
            ICollection<User> users = new List<User>();

            foreach (var usdto in userDtos)
            {
                users.Add(Mapper.Map<User>(usdto));
            }
            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }
    }
}