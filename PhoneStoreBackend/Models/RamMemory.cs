using System.ComponentModel.DataAnnotations;

namespace PhoneStoreBackend.Models
{
    public class RamMemory
    {
        [Key]
        public int RamMemoryId { get; set; }

        public int RamSize { get; set; }
    }
}
