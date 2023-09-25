using System.ComponentModel.DataAnnotations;

namespace Resort.UI.Contracts.LandingPages;

public class SignUpCreate
{
    [Required]
    public string Username { get; set; }
    public string PhoneNumber { get; set; }
    
    [Required]
    public string Email { get; set; }
    
    [Required]
    public string Password { get; set; }
    
    [Required]
    [Compare("Password", ErrorMessage = "The password and confirm password do not match.")]
    public string ConfirmPassword { get; set; }
}