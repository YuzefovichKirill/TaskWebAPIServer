using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using TaskWebAPIServer.Models;
using TaskWebAPIServer.Services;

namespace TaskWebAPIServer.Controllers
{
    [ApiController]
    public class FridgeProductController : ControllerBase
    {
        private IFridgeProductService _fridgeProductData;

        public FridgeProductController(IFridgeProductService fridgeProductData)
        {
            _fridgeProductData = fridgeProductData;
        }

        [HttpGet]
        [Route("api/[controller]/{fridgeId}")]
        public IActionResult GetFridgeProducts(Guid fridgeId)
        {
            return Ok(_fridgeProductData.GetFridgeProducts(fridgeId));
        }

        [HttpGet]
        [Route("api/[controller]/{fridgeId}/{productId}")]
        public IActionResult GetFridgeProduct(Guid fridgeId, Guid productId)
        {
            var product = _fridgeProductData.GetFridgeProduct(fridgeId, productId);
            if (product is not null)
            {
                return Ok(product);
            }

            return NotFound($"Product with id = {productId} was not found");
        }

        [HttpPost]
        [Route("api/[controller]/{fridgeId}/{productId}")]
        public IActionResult AddFridgeProduct(Guid fridgeId, Guid productId, Product product)
        {
            _fridgeProductData.AddFridgeProduct(fridgeId, productId, product);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host
                           + HttpContext.Request.Path + "/" + fridgeId + "/" + productId, product);
        }

        [HttpPut]
        [Route("api/[controller]/{fridgeId}/{productId}")]
        public IActionResult EditFridgeProduct(Guid fridgeId, Guid productId, Product product)
        {
            var _product = _fridgeProductData.GetFridgeProduct(fridgeId, productId);

            if (_product is not null)
            {
                product.Id = _product.Id;
                _fridgeProductData.EditFridgeProduct(fridgeId, productId, product);
                return Ok();
            }

            return NotFound($"Product with id = {productId} was not found");
        }

        [HttpDelete]
        [Route("api/[controller]/{fridgeId}/{productId}")]
        public IActionResult DeleteFridgeProduct(Guid fridgeId, Guid productId)
        {
            var _product = _fridgeProductData.GetFridgeProduct(fridgeId, productId);

            if (_product is not null)
            {
                _fridgeProductData.DeleteFridgeProduct(fridgeId, _product);
                return Ok();
            }

            return NotFound($"Product with id = {productId} was not found");
        }
    }
}
