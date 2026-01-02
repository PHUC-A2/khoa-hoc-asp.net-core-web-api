namespace backend.DTOs.response
{
    public class ResUserDTO
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string Email { get; set; } = null!;
    }
}
