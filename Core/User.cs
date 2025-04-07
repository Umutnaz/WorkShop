using System.ComponentModel.DataAnnotations;

namespace Core;

public class User
{
    public int UserId { get; set; }

    public int LoanerId { get; set; }

    [Required]
    [StringLength(15, MinimumLength = 5, ErrorMessage = "Username must be between 5 and 15 characters")]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    public string Role { get; set; }
    [Required]
    [Range(8, 8, ErrorMessage = "Must be a valid phone number")]
    public int PhoneNumber { get; set; }
    
    public List<Clothing> Clothes { get; set; } = new List<Clothing>();
    
}