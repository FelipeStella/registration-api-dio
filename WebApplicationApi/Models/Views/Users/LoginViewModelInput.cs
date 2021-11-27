using System.ComponentModel.DataAnnotations;

namespace WebApplicationApi.Models.Users
{
  public class LoginViewModelInput
  {
    [Required(ErrorMessage = "O login de usuário é obrigatório")]
    public string LoginProvider { get; set; }

    [Required(ErrorMessage = "A senha de usuário é obrigatória")]
    public string ProviderKey { get; set; }
  }
}
