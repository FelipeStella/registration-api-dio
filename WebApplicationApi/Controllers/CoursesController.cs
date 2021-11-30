using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Claims;
using WebApplicationApi.Models;
using WebApplicationAPI.Business.Entities;
using WebApplicationAPI.Infrastructure.Data.Repositories.Interfaces;

namespace WebApplicationApi.Controllers
{
  [Route("api/v1/courses")]
  [ApiController]
  [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
  public class CoursesController : ControllerBase
  {
    private readonly ICourseRepository _courseRepository;

    public CoursesController(ICourseRepository courseRepository)
    {
      _courseRepository = courseRepository;
    }

    /// <summary>
    /// Este serviço permite cadastrar curso para o usuário autenticado.
    /// </summary>
    /// <param name="coursesViewModelInput"></param>
    /// <returns>Retorna status 201 e dados do curso do usuário</returns>
    [SwaggerResponse(StatusCodes.Status201Created, "Curso cadastrado com sucesso", typeof(CoursesViewModelInput))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Campos obrigatórios", typeof(ValidationFieldViewModelOutput))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno", typeof(GenericErrorViewModel))]
    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Post(CoursesViewModelInput coursesViewModelInput)
    {
      var userId = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);

      Course course = new();
      course.Name = coursesViewModelInput.Name;
      course.Description = coursesViewModelInput.Description;
      course.UserId = userId;

      _courseRepository.Add(course);

      return Created("Curso adicionado com sucesso!", coursesViewModelInput);
    }

    /// <summary>
    /// Este serviço permite obter todos os cursos ativos do usuário.
    /// </summary>
    /// <returns>Retorna status ok e dados do curso do usuário</returns>
    [SwaggerResponse(StatusCodes.Status200OK, "Dados exibidos com sucesso", typeof(CoursesViewModelOutput))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Campos obrigatórios", typeof(ValidationFieldViewModelOutput))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno", typeof(GenericErrorViewModel))]
    [HttpGet]
    [Route("list")]
    public async Task<ActionResult> Get()
    {
      var UserCode = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);

      var courses = _courseRepository.GetByIdUser(UserCode)
        .Select(c => new CoursesViewModelOutput()
        {
          Name = c.Name,
          Description = c.Description,
          Login = c.User.Name
        });

      return Ok(courses);
    }
  }
}
