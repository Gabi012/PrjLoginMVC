using System.ComponentModel.DataAnnotations;

namespace PrjBase.Models;

public class LoginViewModel
{
    [Required(ErrorMessage = "Informe o usuário")]
    [Display(Name = "Usuário")]
    public string Username { get; set; } = string.Empty;

    [Required(ErrorMessage = "Informe a senha")]
    [DataType(DataType.Password)]
    [Display(Name = "Senha")]
    public string Password { get; set; } = string.Empty;

    [Display(Name = "Manter conectado")]
    public bool RememberMe { get; set; }
}
