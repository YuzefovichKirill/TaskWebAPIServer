using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using TaskWebAPIServer.Models;

namespace TaskWebAPIServer.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<FridgeProduct>().HasKey(fp => new
            {
                fp.FridgeId, fp.ProductId
            });

            modelBuilder.Entity<FridgeProduct>().HasOne(fp => fp.Fridge)
                .WithMany(f => f.fridgeProducts).HasForeignKey(fp => fp.FridgeId);
            modelBuilder.Entity<FridgeProduct>().HasOne(fp => fp.Product)
                .WithMany(p => p.fridgeProducts).HasForeignKey(fp => fp.ProductId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Fridge> Fridges { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<FridgeModel> FridgeModels { get; set; }
        public DbSet<FridgeProduct> FridgeProducts { get; set; }


    }
}
