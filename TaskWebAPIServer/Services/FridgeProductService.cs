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

        public FridgeProduct GetFridgeProduct(Guid fridgeId, Guid productId)
        {
            List<FridgeProduct> fridgeProduct =
                _context.FridgeProducts.Where(fp => fp.FridgeId == fridgeId && fp.ProductId == productId).ToList();

            return fridgeProduct.FirstOrDefault();
        }

        public List<FridgeProduct> GetFridgeProducts(Guid fridgeId)
        {
            List<FridgeProduct> fridgeProducts = _context.FridgeProducts.Where(fp => fp.FridgeId == fridgeId).ToList();
            return fridgeProducts;
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
            var dbFridge = _context.Fridges.Find(fridgeProduct.FridgeId);
            var dbProduct = dbFridge.fridgeProducts.Find(fp =>
                fp.FridgeId == fridgeProduct.FridgeId && fp.ProductId == fridgeProduct.ProductId);

            dbProduct.Quantity = fridgeProduct.Quantity;
            _context.SaveChanges();
            return fridgeProduct;
        }

        public void DeleteFridgeProduct(FridgeProduct fridgeProduct)
        {
            var dbFridge = _context.Fridges.Find(fridgeProduct.FridgeId);
            dbFridge.fridgeProducts.Remove(fridgeProduct);
            _context.SaveChanges();
        }
    }
}
