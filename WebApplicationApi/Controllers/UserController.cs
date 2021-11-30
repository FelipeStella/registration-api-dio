using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebApplicationApi.Filters;
using WebApplicationApi.Models;
using WebApplicationApi.Models.Users;
using WebApplicationApi.Models.Views.Users;
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

    /// <summary>
    /// Este serviço permite autenticar um usuário cadastrado e ativo.
    /// </summary>
    /// <param name="loginViewModelInput"></param>
    /// <returns>Retorna status ok, dados do usuario e o token em caso de sucesso</returns>
    [SwaggerResponse(StatusCodes.Status200OK, "Login autorizado", typeof(LoginViewModelOutput))]
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

    /// <summary>
    /// Este serviço permite cadastrar um novo usuário.
    /// </summary>
    /// <param name="registerViewModelInput">View model do registro de login</param>
    /// <returns></returns>
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
