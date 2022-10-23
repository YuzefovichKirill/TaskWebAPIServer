using System.Collections.Generic;
using System;
using TaskWebAPIServer.Models;

namespace TaskWebAPIServer.Services
{
    public interface IFridgeProductService
    {
        List<FridgeProduct> GetFridgeProducts(Guid fridgeId);

        FridgeProduct GetFridgeProduct(Guid fridgeId, Guid productId);

        FridgeProduct AddFridgeProduct(FridgeProduct fridgeProduct);

        FridgeProduct EditFridgeProduct(FridgeProduct fridgeProduct);

        void DeleteFridgeProduct(FridgeProduct fridgeProduct);
    }
}
