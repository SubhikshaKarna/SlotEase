using System.ComponentModel.DataAnnotations;

namespace SlotEase.Application.DTOs.Auth
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "Full name is required")]
        [StringLength(150,MinimumLength =2,ErrorMessage ="Full name must be between 2 and 150 characters")]
        public string FullName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [StringLength(256, ErrorMessage = "Email cannot exceed 256 characters")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Password is required")]
        [StringLength(100,MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters long")]
        public string Password { get; set; } = string.Empty;
    }
}
