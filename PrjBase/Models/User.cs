using System.ComponentModel.DataAnnotations;

namespace PrjBase.Models;

public class User
{
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Username { get; set; } = string.Empty;

    [Required]
    public string PasswordHash { get; set; } = string.Empty;

    [Required]
    public string PasswordSalt { get; set; } = string.Empty;

    // Papel do usuário: "Admin", "User", etc.
    [Required]
    [MaxLength(30)]
    public string Role { get; set; } = "User";
}
