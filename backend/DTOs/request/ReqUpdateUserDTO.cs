using System.ComponentModel.DataAnnotations;

namespace backend.DTOs.request
{
    public class ReqUpdateUserDTO
    {
        public string? Name { get; set; }

        [Required(ErrorMessage = "Email không được để trống")]
        [EmailAddress(ErrorMessage = "Email không đúng định dạng")]
        public string Email { get; set; } = null!;
    }
}
