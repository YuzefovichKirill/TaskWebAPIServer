using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using TaskWebAPIServer.Models;
using TaskWebAPIServer.Services;

namespace TaskWebAPIServer.Controllers
{
    [ApiController]
    public class FridgeModelController : ControllerBase
    {
        private IFridgeModelService _fridgeModelData;

        public FridgeModelController(IFridgeModelService fridgeModelData)
        {
            _fridgeModelData = fridgeModelData;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetFridgeModels()
        {
            return Ok(_fridgeModelData.GetFridgeModels());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetFridgeModel(Guid id)
        {
            var fridgeModel = _fridgeModelData.GetFridgeModel(id);
            if (fridgeModel is not null)
            {
                return Ok(fridgeModel);
            }

            return NotFound($"FridgeModel with id = {id} was not found");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddFridgeModel(FridgeModel fridgeModel)
        {
            _fridgeModelData.AddFridgeModel(fridgeModel);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host
                           + HttpContext.Request.Path + "/" + fridgeModel.Id, fridgeModel);
        }

        [HttpPut]
        [Route("api/[controller]/{id}")]
        public IActionResult EditFridgeModel(Guid id, FridgeModel fridgeModel)
        {
            var _fridgeModel = _fridgeModelData.GetFridgeModel(id);

            if (_fridgeModel is not null)
            {
                fridgeModel.Id = _fridgeModel.Id;
                _fridgeModelData.EditFridgeModel(fridgeModel);
                return Ok();
            }

            return NotFound($"FridgeModel with id = {id} was not found");
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteFridgeModel(Guid id)
        {
            var fridgeModel = _fridgeModelData.GetFridgeModel(id);

            if (fridgeModel is not null)
            {
                _fridgeModelData.DeleteFridgeModel(fridgeModel);
                return Ok();
            }

            return NotFound($"Fridge model with id = {id} was not found");
        }
    }
}
