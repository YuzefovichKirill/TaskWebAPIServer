using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using TaskWebAPIServer.Models;

namespace TaskWebAPIServer.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                Guid[] fridgeModelIds = new Guid[5];
                Guid[] fridgeIds = new Guid[10];
                Guid[] productIds = new Guid[10];
                Guid[] fridgeProductIds = new Guid[10];

                context.FridgeModels.AddRange(new List<FridgeModel>()
                {
                    new FridgeModel() { Id = fridgeModelIds[0], Name = "Атлант", Year = 2017 },
                    new FridgeModel() { Id = fridgeModelIds[1], Name = "Bosch", Year = 2018 },
                    new FridgeModel() { Id = fridgeModelIds[2], Name = "LG", Year = 2012 }
                });
                context.SaveChanges();

                /*context.Fridges.AddRange(new List<Fridge>()
                {
                    //new Fridge() { Id = FridgeIds[0], Name = "Атлант1", OwnerName = "Сын", FridgeModelId = FridgeModelIds[0]},
                    //new Fridge() { Id = ids[5], Name = "Bosch2", OwnerName = "Сын2", FridgeModelId = ids[1] },
                    //new Fridge() { Id = ids[6] ,Name = "LG1", OwnerName = "Сын2", FridgeModelId = ids[2] }
                });
                context.SaveChanges();*/

                context.Products.AddRange(new List<Product>()
                {
                    new Product() { Id = productIds[0], Name = "Колбаса", DefaultQuantity = 2 },
                    new Product() { Id = productIds[1], Name = "Рыба", DefaultQuantity = 1 },
                    new Product() { Id = productIds[2], Name = "Молоко", DefaultQuantity = 3 }
                });
                context.SaveChanges();

                /*context.FridgeProducts.AddRange(new List<FridgeProduct>()
                {
                    new FridgeProduct()
                    {
                        Id = fridgeProductIds[0],
                        FridgeId = fridgeIds[0],
                        ProductId = productIds[0],
                        Quantity = 3
                    },
                    new FridgeProduct()
                    {
                        Id = fridgeProductIds[1],
                        FridgeId = fridgeIds[1],
                        ProductId = productIds[1],
                        Quantity = 2
                    }
                });
                context.SaveChanges();*/
            }
        }
    }
}
