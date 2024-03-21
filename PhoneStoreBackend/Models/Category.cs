using System.ComponentModel.DataAnnotations;

namespace PhoneStoreBackend.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        public required string CategoryName { get; set; }
    }
}
