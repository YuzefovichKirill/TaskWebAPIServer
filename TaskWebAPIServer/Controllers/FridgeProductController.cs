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
        public IActionResult AddFridgeProduct(FridgeProduct fridgeProduct)
        {
            _fridgeProductData.AddFridgeProduct(fridgeProduct);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host
                           + HttpContext.Request.Path + "/" + fridgeProduct.FridgeId + "/" + fridgeProduct.ProductId, fridgeProduct);
        }

        [HttpPut]
        [Route("api/[controller]/{fridgeId}/{productId}")]
        public IActionResult EditFridgeProduct(FridgeProduct fridgeProduct)
        {
            var _product = _fridgeProductData.GetFridgeProduct(fridgeProduct.FridgeId, fridgeProduct.ProductId);

            if (_product is not null)
            {
                _fridgeProductData.EditFridgeProduct(fridgeProduct);
                return Ok();
            }

            return NotFound($"Product with id = {fridgeProduct.ProductId} was not found");
        }

        [HttpDelete]
        [Route("api/[controller]/{fridgeId}/{productId}")]
        public IActionResult DeleteFridgeProduct(Guid fridgeId, Guid productId)
        {

            _fridgeProductData.DeleteFridgeProduct(fridgeId, productId);
            return Ok();
        }
    }
}