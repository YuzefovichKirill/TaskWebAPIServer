using System.Collections.Generic;
using System;
using TaskWebAPIServer.Models;

namespace TaskWebAPIServer.Services
{
    public interface IFridgeProductService
    {
        public void SetDefaultProductQuantities();
        List<Product> GetFridgeProducts(Guid fridgeId);

        Product GetFridgeProduct(Guid fridgeId, Guid productId);

        FridgeProduct AddFridgeProduct(FridgeProduct fridgeProduct);

        FridgeProduct EditFridgeProduct(FridgeProduct fridgeProduct);

        void DeleteFridgeProduct(Guid fridgeId, Guid productId);
    }
}
