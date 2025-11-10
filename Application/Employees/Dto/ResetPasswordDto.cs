using System.ComponentModel.DataAnnotations;

namespace AuthWebApp.Service.UserLogins.Dto;

public class ResetPasswordDto
{

    //string pattern match  
    [Required(ErrorMessage = "Code is required")]
    public string Code { get; set; } = string.Empty;

    [Required(ErrorMessage = "Password is required")]
    [StringLength(100, MinimumLength = 8,
        ErrorMessage = "Password must be at least 8 characters long")]
    public string Password { get; set; }

    [Required(ErrorMessage = "Confirm Password is required")]
    [Compare("Password", ErrorMessage = "Passwords do not match")]
    public string ConfirmPassword { get; set; }
}