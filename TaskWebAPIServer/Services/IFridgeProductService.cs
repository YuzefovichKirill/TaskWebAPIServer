using System.Collections.Generic;
using System;
using TaskWebAPIServer.Models;

namespace TaskWebAPIServer.Services
{
    public interface IFridgeProductService
    {
        List<Product> GetFridgeProducts(Guid fridgeId);

        Product GetFridgeProduct(Guid fridgeId, Guid productId);

        Product AddFridgeProduct(Guid fridgeId, Guid productId, Product product);

        Product EditFridgeProduct(Guid fridgeId, Guid productId, Product product);

        void DeleteFridgeProduct(Guid fridgeId, Product product);
    }
}
