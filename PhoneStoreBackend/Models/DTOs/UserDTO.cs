namespace PhoneStoreBackend.Models.DTOs
{
    public class UserDTO
    {
        public required string UserName { get; set; }

        public required string Password { get; set; }

        public required string Email { get; set; }
    }
}
