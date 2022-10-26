using System;
using System.Collections.Generic;
using TaskWebAPIServer.Data;
using TaskWebAPIServer.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TaskWebAPIServer.Controllers;

namespace TaskWebAPIServer.Services
{
    public class FridgeProductService : IFridgeProductService
    {
        private AppDbContext _context;

        public FridgeProductService(AppDbContext context)
        {
            _context = context;
        }

        public void SetDefaultProductQuantities()
        {

            var fridgeProducts = _context.FridgeProducts.FromSqlRaw("EXECUTE SetDefaultProductQuantity").ToList();

            var products = _context.Products.ToList();

            var fridgeProductsChange = fridgeProducts.Join(products, fp => fp.ProductId, p => p.Id,
                (fp, p) => new FridgeProduct() { Id = fp.Id, FridgeId = fp.FridgeId, ProductId = fp.ProductId, Quantity = p.DefaultQuantity }).ToList();

            foreach (var fridgeProductChange in fridgeProductsChange)
            {
                EditFridgeProduct(fridgeProductChange);
                _context.SaveChanges();
            }
        }

        public Product GetFridgeProduct(Guid fridgeId, Guid productId)
        {
            // send quantity as DefaultQuantity
            List<Product> product = _context.Fridges
                    .Where(f => f.Id == fridgeId)
                    .Join(_context.FridgeProducts, f => f.Id, fp => fp.FridgeId, (f, fp) => new {fridgeId = f.Id, productId = fp.ProductId, quantity = fp.Quantity} )
                    .Where(ffp => ffp.productId == productId)
                    .Join(_context.Products, ffp => ffp.productId, p => p.Id, (ffp, p) => new Product(){Id = ffp.productId, Name = p.Name, DefaultQuantity = ffp.quantity}).ToList();

            return product.FirstOrDefault();
        }

        public List<Product> GetFridgeProducts(Guid fridgeId)
        {
            // send quantity as DefaultQuantity
            List<Product> products = _context.Fridges
                .Where(f => f.Id == fridgeId)
                .Join(_context.FridgeProducts, f => f.Id, fp => fp.FridgeId, (f, fp) => new { fridgeId = f.Id, productId = fp.ProductId, quantity = fp.Quantity })
                .Join(_context.Products, ffp => ffp.productId, p => p.Id, (ffp, p) => new Product() { Id = ffp.productId, Name = p.Name, DefaultQuantity = ffp.quantity }).ToList();

            return products;
        }

        public FridgeProduct AddFridgeProduct(FridgeProduct fridgeProduct)
        {
            fridgeProduct.Id = Guid.NewGuid();
            var res = _context.FridgeProducts.Add(fridgeProduct);
            _context.SaveChanges();
            return fridgeProduct;
        }

        public FridgeProduct EditFridgeProduct(FridgeProduct fridgeProduct)
        {
            var dbFridgeProduct = _context.FridgeProducts
                .Where(fp => fp.FridgeId == fridgeProduct.FridgeId && fp.ProductId == fridgeProduct.ProductId).ToList().FirstOrDefault();

            dbFridgeProduct.Quantity = fridgeProduct.Quantity;
            _context.SaveChanges();
            return fridgeProduct;
        }

        public void DeleteFridgeProduct(Guid fridgeId, Guid productId)
        {
            var dbFridgeProduct = _context.FridgeProducts
                .Where(fp => fp.FridgeId == fridgeId && fp.ProductId == productId).ToList().FirstOrDefault();

            _context.FridgeProducts.Remove(dbFridgeProduct);
            _context.SaveChanges();
        }
    }
}
