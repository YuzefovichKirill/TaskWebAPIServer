using System;
using System.Collections.Generic;
using TaskWebAPIServer.Models;

namespace TaskWebAPIServer.Services
{
    public interface IFridgeService
    {
        List<Fridge> GetFridges();

        Fridge GetFridge(Guid id);

        Fridge AddFridge(Fridge fridge);

        Fridge EditFridge(Fridge fridge);

        void DeleteFridge(Fridge fridge);
    }
}
