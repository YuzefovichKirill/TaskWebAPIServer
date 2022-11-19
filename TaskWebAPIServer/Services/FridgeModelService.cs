using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TaskWebAPIServer.Data;
using TaskWebAPIServer.Models;

namespace TaskWebAPIServer.Services
{
    public class FridgeModelService : IFridgeModelService
    {
        private AppDbContext _context;

        public FridgeModelService(AppDbContext context)
        {
            _context = context;
        }

        public List<FridgeModel> GetFridgeModels()
        {
            return _context.FridgeModels.ToList();
        }

        public FridgeModel GetFridgeModel(Guid id)
        {
            var fridgeModel = _context.FridgeModels.Find(id);
            return fridgeModel;
        }

        public FridgeModel AddFridgeModel(FridgeModel fridgeModel)
        {
            fridgeModel.Id = Guid.NewGuid();
            _context.FridgeModels.Add(fridgeModel);
            _context.SaveChanges();
            return fridgeModel;
        }

        public FridgeModel EditFridgeModel(FridgeModel fridgeModel)
        {
            var dbFridgeModel = _context.FridgeModels.Find(fridgeModel.Id);

            dbFridgeModel.Name = fridgeModel.Name;
            dbFridgeModel.Year = fridgeModel.Year;
            _context.SaveChanges();
            return fridgeModel;
        }

        public void DeleteFridgeModel(FridgeModel fridgeModel)
        {
            _context.FridgeModels.Remove(fridgeModel);
            _context.SaveChanges();
        }
    }
}
