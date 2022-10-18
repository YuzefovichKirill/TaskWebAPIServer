using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskWebAPIServer.Models
{
    public class FridgeProduct
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int FridgeId { get; set; }
        public Fridge Fridge { get; set; }
        public int Quantity { get; set; }
    }
}
