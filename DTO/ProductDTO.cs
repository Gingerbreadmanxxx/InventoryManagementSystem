using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class Product
    {
               
        public int ProductId { get; set; } 
        public string Name { get; set; }
        public int QuantityInStock { get; set; }
        public decimal Price { get; set; }

    }
}
