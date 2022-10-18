using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskWebAPIServer.Models
{
    public class Fridge
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string OwnerName  { get; set; }
        public int FridgeModelId { get; set; }
        [ForeignKey("FridgeModelId")]
        public FridgeModel FridgeModel { get; set; }

        public List<FridgeProduct> fridgeProducts = new ();
    }
}
