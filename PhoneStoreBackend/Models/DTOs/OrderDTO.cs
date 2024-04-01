namespace PhoneStoreBackend.Models.DTOs
{
    public class OrderDTO
    {

            public int StatusId { get; set; }
            public int UserId { get; set; }
            public int TotalPrice { get; set; }
            public List<OrderDetailDTO> OrderDetails { get; set; }
        
    }
}
