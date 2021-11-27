using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplicationAPI.Business.Entities;

namespace WebApplicationAPI.Infrastructure.Data.Mappings
{
  public class CourseMapping : IEntityTypeConfiguration<Course>
  {
    public void Configure(EntityTypeBuilder<Course> builder)
    {
      builder.ToTable("TB_COURSE");
      builder.HasKey(x => x.Id);
      builder.Property(x => x.Id).ValueGeneratedOnAdd();
      builder.Property(x => x.Name);
      builder.Property(x => x.Description);
      builder.HasOne(x => x.User).WithMany().HasForeignKey(fk => fk.UserId);
    }
  }
}
