using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneStoreBackend.Models
{
    public class Product
    {
        [Key]
        [Required]
        public int PhoneID { get; set; }

        public int Price { get; set; }

        public Brand Brand { get; set; }

        public string Model { get; set; }

        public DateTime ReleaseDate { get; set; }

        public double DisplaySize { get; set; }

        public OperatingSystem OperatingSystem { get; set; }

        public string Processor { get; set; }

        public RamMemory RamMemory { get; set; }

        public Memory Memory { get; set; }

        public int CameraPx { get; set; }

        public int BatteryCapacity { get; set; }

        public required string Color { get; set; }
    }
}
