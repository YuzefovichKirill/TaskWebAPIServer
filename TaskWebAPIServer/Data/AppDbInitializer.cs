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
                Guid[] fridgeModelIds = new Guid[] {Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() };
                Guid[] fridgeIds = new Guid[] { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() };
                Guid[] productIds = new Guid[10] { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() };
                Guid[] fridgeProductIds = new Guid[10] { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() };

                context.FridgeModels.AddRange(new List<FridgeModel>()
                {
                    new FridgeModel() { Id = fridgeModelIds[0], Name = "Атлант", Year = 2017 },
                    new FridgeModel() { Id = fridgeModelIds[1], Name = "Bosch", Year = 2018 },
                    new FridgeModel() { Id = fridgeModelIds[2], Name = "LG", Year = 2012 }
                });
                context.SaveChanges();

                context.Fridges.AddRange(new List<Fridge>()
                {
                    new Fridge() { Id = fridgeIds[0], Name = "Атлант1", OwnerName = "Сын", FridgeModelId = fridgeModelIds[0]},
                    new Fridge() { Id = fridgeIds[1], Name = "Bosch2", OwnerName = "Сын2", FridgeModelId = fridgeModelIds[1] },
                    new Fridge() { Id = fridgeIds[2], Name = "LG1", OwnerName = "Сын2", FridgeModelId = fridgeModelIds[2] }
                });
                context.SaveChanges();

                context.Products.AddRange(new List<Product>()
                {
                    new Product() { Id = productIds[0], Name = "Колбаса", DefaultQuantity = 2 },
                    new Product() { Id = productIds[1], Name = "Рыба", DefaultQuantity = 1 },
                    new Product() { Id = productIds[2], Name = "Молоко", DefaultQuantity = 3 }
                });
                context.SaveChanges();

                context.FridgeProducts.AddRange(new List<FridgeProduct>()
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
                context.SaveChanges();
            }
        }
    }
}
