using Microsoft.EntityFrameworkCore;
using WebApplicationAPI.Business.Entities;
using WebApplicationAPI.Infrastructure.Data.Repositories.Interfaces;

namespace WebApplicationAPI.Infrastructure.Data.Repositories
{
  public class CourseRepository : ICourseRepository
  {
    private readonly ApiDbContext _context;

    public CourseRepository(ApiDbContext apiDbContext)
    {
      _context = apiDbContext;
    }
    public void Add(Course course)
    {
      _context.Add(course);
      _context.SaveChanges(); 
    }

    public List<Course> GetByIdUser(int userId)
    {
      return _context.Courses.Include(i => i.User).Where(c => c.UserId == userId).ToList();
    }
  }
}
