using System.ComponentModel.DataAnnotations;

namespace PhoneStoreBackend.Models
{
    public class Brand
    {
        [Key]
        public int BrandId { get; set; }

        [Required]
        public required string BrandName { get; set; }
    }
}
