using System.ComponentModel.DataAnnotations;

namespace WebApplicationApi.Models
{
  public class CoursesViewModelInput
  {
    [Required(ErrorMessage = "O nome do curso é obrigatório")]
    public string Name { get; set; }

    [Required(ErrorMessage = "A descrição é obrigatória")]
    public string Description { get; set; }
  }
}
