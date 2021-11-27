//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Design;
//using WebApplicationAPI.Infrastructure.Data;

//namespace WebApplicationAPI.Config
//{
//  public class FactoryDbContext : IDesignTimeDbContextFactory<ApiDbContext>
//  {
//    public ApiDbContext CreateDbContext(string[] args)
//    {
//      var configuration = new ConfigurationBuilder()
//                              .AddJsonFile("appsettings.json")
//                              .Build();

//      var optionsBuilder = new DbContextOptionsBuilder<ApiDbContext>();
//      optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

//      ApiDbContext context = new ApiDbContext(optionsBuilder.Options);

//      return context;
//    }
//  }
//}

