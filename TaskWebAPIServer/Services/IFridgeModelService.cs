using System.Collections.Generic;
using System;
using TaskWebAPIServer.Models;

namespace TaskWebAPIServer.Services
{
    public interface IFridgeModelService
    {
        List<FridgeModel> GetFridgeModels();

        FridgeModel GetFridgeModel(Guid id);

        FridgeModel AddFridgeModel(FridgeModel fridgeModel);

        FridgeModel EditFridgeModel(FridgeModel fridgeModel);

        void DeleteFridgeModel(FridgeModel fridgeModel);
    }
}
