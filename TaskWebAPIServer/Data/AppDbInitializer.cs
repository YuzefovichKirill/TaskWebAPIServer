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
                context.Database.EnsureCreated();

                if (!context.FridgeModels.Any())
                {
                    context.FridgeModels.AddRange(new List<FridgeModel>()
                    {
                        new FridgeModel() {Name = "Холодос", Year = 2017 },
                        new FridgeModel() {Name = "Холодос2", Year = 2018 }
                    });
                    context.SaveChanges();
                }

                if (!context.Fridges.Any())
                {
                    context.Fridges.AddRange(new List<Fridge>()
                    {
                        new Fridge(){ Name = "Атлант", OwnerName = "Сын", FridgeModelId = 1},
                        new Fridge(){ Name = "Атлант2", OwnerName = "Сын2", FridgeModelId = 2}
                    });
                    context.SaveChanges();
                }
            }
        }

    }
}
