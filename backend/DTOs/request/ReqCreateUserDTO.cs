using System.ComponentModel.DataAnnotations;

namespace backend.DTOs.request
{
    public class ReqCreateUserDTO
    {
        // Không bắt buộc
        public string? Name { get; set; }

        // Bắt buộc + đúng email
        [Required(ErrorMessage = "Email không được để trống")]
        [EmailAddress(ErrorMessage = "Email không đúng định dạng")]
        public string Email { get; set; } = null!;

        // Bắt buộc + tối thiểu 6 ký tự
        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [MinLength(6, ErrorMessage = "Mật khẩu phải có ít nhất 6 ký tự")]
        public string Password { get; set; } = null!;
    }
}
