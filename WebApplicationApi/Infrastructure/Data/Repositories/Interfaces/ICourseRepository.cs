using WebApplicationAPI.Business.Entities;

namespace WebApplicationAPI.Infrastructure.Data.Repositories.Interfaces
{
  public interface ICourseRepository
  {
    public void Add(Course course);

    public List<Course> GetByIdUser(int userId);
  }
}
