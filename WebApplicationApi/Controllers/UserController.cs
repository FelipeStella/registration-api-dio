using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebApplicationApi.Filters;
using WebApplicationApi.Models;
using WebApplicationApi.Models.Users;
using WebApplicationAPI.Business.Entities;
using WebApplicationAPI.Infrastructure.Data.Repositories.Interfaces;
using WebApplicationAPI.Services.Interfaces;

namespace WebApplicationApi.Controllers
{
  [Route("api/v1/user")]
  [ApiController]
  public class UserController : ControllerBase
  {

    private readonly IUserRepository _userRepository;
    private readonly IAuthenticationService _authenticationService;

    public UserController(
      IUserRepository userRepository, 
      IAuthenticationService authenticationService
      )
    {
      _userRepository = userRepository;
      _authenticationService = authenticationService;
    }

    [SwaggerResponse(StatusCodes.Status200OK, "Login autorizado", typeof(LoginViewModelInput))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Campos obrigatórios", typeof(ValidationFieldViewModelOutput))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno", typeof(GenericErrorViewModel))]
    [HttpPost]
    [Route("login")]
    [CustomValidationModelState]
    public IActionResult Login(LoginViewModelInput loginViewModelInput)
    {
      User user = _userRepository.Find(loginViewModelInput.LoginProvider);

      if (user == null)
        return BadRequest("Usuário ou senha incorretos!");

      var userViewModelOutput = new UserViewModelOutput()
      {
        Code = user.Id,
        UserName = user.Name,
        UserEmail = user.Email,
      };

      var token = _authenticationService.GetToken(userViewModelOutput);

      return Ok(new
      {
        Token = token,
        User = userViewModelOutput
      });
    }

    [SwaggerResponse(StatusCodes.Status200OK, "Registro realizado com sucesso", typeof(RegisterViewModelInput))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Campos obrigatórios", typeof(ValidationFieldViewModelOutput))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno", typeof(GenericErrorViewModel))]
    [HttpPost]
    [Route("register")]
    [CustomValidationModelState]
    public async Task<ActionResult<User>> Register(RegisterViewModelInput registerViewModelInput)
    {

      var user = new User();
      user.Name = registerViewModelInput.UserName;
      user.Email = registerViewModelInput.Email;
      user.Password = registerViewModelInput.Password;

      _userRepository.Add(user);

      return Created("", registerViewModelInput);
    }
  }

}
