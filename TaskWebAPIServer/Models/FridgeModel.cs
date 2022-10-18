using System.ComponentModel.DataAnnotations;

namespace TaskWebAPIServer.Models
{
    public class FridgeModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
    }
}
