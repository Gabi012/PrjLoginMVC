using System.ComponentModel.DataAnnotations;

namespace PrjBase.Models;

public class RegisterViewModel
{
    [Required]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "O usuário deve ter entre {2} e {1} caracteres")]
    [Display(Name = "Usuário")]
    public string Username { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.Password)]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "A senha deve ter ao menos {2} caracteres")]
    [Display(Name = "Senha")]
    public string Password { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.Password)]
    [Compare(nameof(Password), ErrorMessage = "As senhas não conferem")]
    [Display(Name = "Confirmar senha")]
    public string ConfirmPassword { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Perfil (Role)")]
    public string Role { get; set; } = "User";
}
