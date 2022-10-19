using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using TaskWebAPIServer.Models;
using TaskWebAPIServer.Services;

namespace TaskWebAPIServer.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _productData;

        public ProductController(IProductService productData)
        {
            _productData = productData;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetProducts()
        {
            return Ok(_productData.GetProducts());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetProduct(Guid id)
        {
            var product = _productData.GetProduct(id);
            if (product is not null)
            {
                return Ok(product);
            }

            return NotFound($"Product with id = {id} was not found");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddProduct(Product product)
        {
            _productData.AddProduct(product);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host
                           + HttpContext.Request.Path + "/" + product.Id, product);
        }

        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult EditProduct(Guid id, Product product)
        {
            var _product = _productData.GetProduct(id);

            if (_product is not null)
            {
                product.Id = _product.Id;
                _productData.EditProduct(product);
                return Ok();
            }

            return NotFound($"Product with id = {id} was not found");
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteProduct(Guid id)
        {
            var product = _productData.GetProduct(id);

            if (product is not null)
            {
                _productData.DeleteProduct(product);
                return Ok();
            }

            return NotFound($"Product with id = {id} was not found");
        }
    }
}
