using System.ComponentModel.DataAnnotations;

namespace PhoneStoreBackend.Models
{
    public class OrderStatus
    {
        [Key]
        public int OrderStatusId { get; set; }

        [Required]
        public required string OrderStatusName { get; set;}
    }
}
