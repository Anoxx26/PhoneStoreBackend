using System.ComponentModel.DataAnnotations;

namespace PhoneStoreBackend.Models
{
    public class OrderDetails
    {
        [Key]
        public int OrderDetailsID { get; set; }

        [Key]
        public Product Product { get; set; }

        public int Quantity { get; set; }

    }
}
