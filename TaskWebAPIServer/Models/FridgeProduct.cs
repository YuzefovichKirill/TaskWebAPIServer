using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskWebAPIServer.Models
{
    public class FridgeProduct
    {
        [Key]
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Guid FridgeId { get; set; }
        public Fridge Fridge { get; set; }
        public int Quantity { get; set; }
    }
}
