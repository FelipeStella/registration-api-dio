using WebApplicationApi.Models.Users;
using WebApplicationAPI.Business.Entities;

namespace WebApplicationAPI.Infrastructure.Data.Repositories.Interfaces
{
  public interface IUserRepository
  {
    public void Add(User user);
    User Find(LoginViewModelInput loginViewModelInput);
  }
}
