using WebApplicationApi.Models.Users;

namespace WebApplicationAPI.Services.Interfaces
{
  public interface IAuthenticationService
  {
    public string GetToken(UserViewModelOutput userViewModelOutput);
  }
}
