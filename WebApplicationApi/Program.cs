using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using WebApplicationAPI.Infrastructure.Data;
using WebApplicationAPI.Infrastructure.Data.Repositories;
using WebApplicationAPI.Services;
using WebApplicationAPI.Infrastructure.Data.Repositories.Interfaces;
using WebApplicationAPI.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
{
  options.SuppressModelStateInvalidFilter = true;
}); 

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
  c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
  {
    Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
    Name = "Authorization",
    In = ParameterLocation.Header,
    Type = SecuritySchemeType.ApiKey,
    Scheme = "Bearer"
  });

  c.AddSecurityRequirement(new OpenApiSecurityRequirement
  {
    {
      new OpenApiSecurityScheme
      {
          Reference = new OpenApiReference
          {
              Type = ReferenceType.SecurityScheme,
              Id = "Bearer"
          }
      },
      Array.Empty<string>()
    }
  });

});

var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json").Build();

var secret = Encoding.ASCII.GetBytes(config.GetSection("JwtConfigurations:Secret").Value);

builder.Services.AddAuthentication(s =>
{
  s.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
  s.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})

  .AddJwtBearer(s =>
  {
  s.RequireHttpsMetadata = false;
  s.SaveToken = true;
  s.TokenValidationParameters = new TokenValidationParameters
  {
    ValidateIssuerSigningKey = true,
    IssuerSigningKey = new SymmetricSecurityKey(secret),
    ValidateIssuer = false,
    ValidateAudience = false
  };
});

builder.Services.AddDbContext<ApiDbContext>(options =>
{
  options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthentication();

app.MapControllers();

app.Run();