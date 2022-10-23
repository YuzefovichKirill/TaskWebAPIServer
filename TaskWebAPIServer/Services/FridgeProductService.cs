using System;
using System.Collections.Generic;
using TaskWebAPIServer.Data;
using TaskWebAPIServer.Models;
using System.Linq;

namespace TaskWebAPIServer.Services
{
    public class FridgeProductService : IFridgeProductService
    {
        private AppDbContext _context;

        public FridgeProductService(AppDbContext context)
        {
            _context = context;
        }

        public Product GetFridgeProduct(Guid fridgeId, Guid productId)
        {
            Fridge dbFridge = _context.Fridges.Find(fridgeId);
            Product dbProduct = _context.Products.Find(productId);

            var dbFP = _context.Fridges
                .Where(f => f.Id == fridgeId)
                .Join(_context.FridgeProducts, f => f.Id, fp => fp.FridgeId,
                    (f, fp) => new { fridgeId = f.Id, fridgeProductId = fp.Id, fp.ProductId, fp.Quantity })
                .Where(fp => fp.fridgeProductId == productId)
                .Join(_context.Products, ffp => ffp.ProductId, p => p.Id, 
                    (ffp, p) => new Product(){Id = p.Id,Name = p.Name,DefaultQuantity = ffp.Quantity });

            return dbFP.FirstOrDefault();
        }

        public List<Product> GetFridgeProducts(Guid fridgeId)
        {
            Fridge dbFridge = _context.Fridges.Find(fridgeId);
            var dbFP = _context.Fridges
                .Where(f => f.Id == fridgeId)
                .Join(_context.FridgeProducts, f => f.Id, fp => fp.FridgeId,
                    (f, fp) => new { fridgeId = f.Id, fridgeProductId = fp.Id, fp.ProductId, fp.Quantity })
                .Join(_context.Products, ffp => ffp.ProductId, p => p.Id,
                    (ffp, p) => new Product() { Id = p.Id, Name = p.Name, DefaultQuantity = ffp.Quantity });

            return dbFP.ToList();
        }

        public Product AddFridgeProduct(Guid fridgeId, Guid productId, Product product)
        {
            throw new NotImplementedException();
        }

        public Product EditFridgeProduct(Guid fridgeId, Guid productId, Product product)
        {
            throw new NotImplementedException();
        }
        public void DeleteFridgeProduct(Guid fridgeId, Product product)
        {
            throw new NotImplementedException();
        }
    }
}
