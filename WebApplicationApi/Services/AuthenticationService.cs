using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplicationApi.Models.Users;
using WebApplicationAPI.Services.Interfaces;

namespace WebApplicationAPI.Services
{
  public class AuthenticationService : IAuthenticationService
  {
    private readonly IConfiguration _configuration;

    public AuthenticationService(IConfiguration configuration)
    {
      _configuration = configuration;
    }
    public string GetToken(UserViewModelOutput userViewModelOutput)
    {
      var secret = Encoding.ASCII.GetBytes(_configuration.GetSection("JwtConfigurations:Secret").Value);
      var symmetricSecurityKey = new SymmetricSecurityKey(secret);
      var securityTokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(new Claim[]
        {
          new Claim(ClaimTypes.NameIdentifier, userViewModelOutput.Code.ToString()),
          new Claim(ClaimTypes.Name, userViewModelOutput.UserName.ToString()),
          new Claim(ClaimTypes.Email, userViewModelOutput.UserEmail.ToString())
      }),
        Expires = DateTime.UtcNow.AddDays(1),
        SigningCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature)
      };
      var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
      var tokenGenerated = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
      var token = jwtSecurityTokenHandler.WriteToken(tokenGenerated);

      return token;
    }
  }
}
