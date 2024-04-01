namespace PhoneStoreBackend.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public int StatusId { get; set; }
        public OrderStatus Status { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int TotalPrice { get; set; }

        public DateOnly OrderCreate {  get; set; }

        public DateOnly OrderEnd { get; set; }

    }
}
