namespace PhoneStoreBackend.Models.DTOs
{
    public class ProductDTO
    {
        public int Price { get; set; }

        public string Description { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public int ReleaseDate { get; set; }

        public double DisplaySize { get; set; }

        public string OperatingSystem { get; set; }

        public string Processor { get; set; }

        public int RamMemory { get; set; }

        public int Memory { get; set; }

        public int CameraPx { get; set; }

        public int BatteryCapacity { get; set; }

        public required string Color { get; set; }
    }
}
