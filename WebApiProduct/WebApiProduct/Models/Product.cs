using System.ComponentModel.DataAnnotations;
namespace WebApiProduct.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public bool Status { get; set; }
        public int Stock { get; set; }
        public string? Description { get; set; }
        public decimal  Price { get; set; }

    }
}
