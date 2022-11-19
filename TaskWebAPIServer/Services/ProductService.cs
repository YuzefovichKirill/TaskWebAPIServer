using System.Collections.Generic;
using System;
using TaskWebAPIServer.Models;
using TaskWebAPIServer.Data;
using System.Linq;

namespace TaskWebAPIServer.Services
{
    public class ProductService : IProductService
    {
        private AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public List<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public Product GetProduct(Guid id)
        {
            var product = _context.Products.Find(id);
            return product;
        }

        public Product AddProduct(Product product)
        {
            product.Id = Guid.NewGuid();
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        public Product EditProduct(Product product)
        {
            var dbProduct = _context.Products.Find(product.Id);

            dbProduct.Name = product.Name;
            dbProduct.DefaultQuantity = product.DefaultQuantity;
            _context.SaveChanges();
            return product;
        }

        public void DeleteProduct(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }
    }
}
