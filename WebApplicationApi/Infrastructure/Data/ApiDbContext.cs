using Microsoft.EntityFrameworkCore;
using WebApplicationAPI.Business.Entities;
using WebApplicationAPI.Infrastructure.Data.Mappings;

namespace WebApplicationAPI.Infrastructure.Data
{
  public class ApiDbContext : DbContext
  {
    public DbSet<User> User { get; set; }
    public DbSet<Course> Courses { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //  optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=WebApplicationMVC;Integrated Security=True");
    //}

    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
    {

    }

    public virtual void SetModified(object entity)
    {
      Entry(entity).State = EntityState.Modified;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfiguration(new UserMapping());
      modelBuilder.ApplyConfiguration(new CourseMapping());
      base.OnModelCreating(modelBuilder);
    }


  }
}
 