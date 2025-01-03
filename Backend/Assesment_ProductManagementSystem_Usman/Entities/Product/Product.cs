using System.ComponentModel.DataAnnotations;

namespace Assesment_ProductManagementSystem_Usman.Entities.Product
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, MaxLength(500)]
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
