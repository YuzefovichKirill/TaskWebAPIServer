using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TaskWebAPIServer.Data;
using TaskWebAPIServer.Models;
using TaskWebAPIServer.Services;

namespace TaskWebAPIServer.Controllers
{
    [ApiController]
    public class FridgeController : ControllerBase
    {
        private IFridgeService _fridgeData;

        public FridgeController(IFridgeService fridgeData)
        {
            _fridgeData = fridgeData;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetFridges()
        {
            return Ok(_fridgeData.GetFridges());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetFridge(Guid id)
        {
            var fridge = _fridgeData.GetFridge(id);
            if (fridge is not null)
            {
                return Ok(fridge);
            }

            return NotFound($"Fridge with id = {id} was not found");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddFridge(Fridge fridge)
        {
            _fridgeData.AddFridge(fridge);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host
                           + HttpContext.Request.Path + "/" + fridge.Id, fridge);
        }

        [HttpPut]
        [Route("api/[controller]/{id}")]
        public IActionResult EditFridge(Guid id, Fridge fridge)
        {
            var _fridge = _fridgeData.GetFridge(id);

            if (_fridge is not null)
            {
                fridge.Id = _fridge.Id;
                _fridgeData.EditFridge(fridge);
                return Ok();
            }

            return NotFound($"Fridge with id = {id} was not found");
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteFridge(Guid id)
        {
            var fridge = _fridgeData.GetFridge(id);

            if (fridge is not null)
            {
                _fridgeData.DeleteFridge(fridge);
                return Ok();
            }

            return NotFound($"Fridge with id = {id} was not found");
        }
    }
}
