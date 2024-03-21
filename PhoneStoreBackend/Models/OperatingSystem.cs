using System.ComponentModel.DataAnnotations;

namespace PhoneStoreBackend.Models
{
    public class OperatingSystem
    {
        [Key]
        public int OperatingSystemId {  get; set; }

        [Required]
        public required string Name { get; set; }
    }
}
