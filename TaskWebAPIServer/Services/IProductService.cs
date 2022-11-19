using System.Collections.Generic;
using System;
using TaskWebAPIServer.Models;

namespace TaskWebAPIServer.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();

        Product GetProduct(Guid id);

        Product AddProduct(Product product);

        Product EditProduct(Product product);

        void DeleteProduct(Product product);
    }
}
