using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TaskWebAPIServer.Data;
using TaskWebAPIServer.Models;

namespace TaskWebAPIServer.Services
{
    public class FridgeService : IFridgeService
    {
        private AppDbContext _context;

        public FridgeService(AppDbContext context)
        {
            _context = context;
        }

        public List<Fridge> GetFridges()
        {
            return _context.Fridges.ToList();
        }

        public Fridge GetFridge(Guid id)
        {
            var fridge = _context.Fridges.Find(id);
            return fridge;
        }

        public Fridge AddFridge(Fridge fridge)
        {
            fridge.Id = Guid.NewGuid();
            _context.Fridges.Add(fridge);
            _context.SaveChanges();
            return fridge;
        }

        public Fridge EditFridge(Fridge fridge)
        {
            var dbFridge = _context.Fridges.Find(fridge.Id);

            dbFridge.Name = fridge.Name;
            dbFridge.OwnerName = fridge.OwnerName;
            dbFridge.FridgeModelId = fridge.FridgeModelId;
            _context.SaveChanges();
            return fridge;
        }

        public void DeleteFridge(Fridge fridge)
        {
            _context.Fridges.Remove(fridge);
            _context.SaveChanges();
        }
    }
}
