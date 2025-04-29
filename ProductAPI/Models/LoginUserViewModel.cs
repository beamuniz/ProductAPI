using System.ComponentModel.DataAnnotations;

namespace ProductAPI.Models;

public class LoginUserViewModel
{
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Email is invalid")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [StringLength(100, ErrorMessage = "Password must be at least 6 characters")]
    public string? Password { get; set; }
}