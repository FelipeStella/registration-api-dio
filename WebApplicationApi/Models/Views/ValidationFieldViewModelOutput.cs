namespace WebApplicationApi.Models
{
  public class ValidationFieldViewModelOutput
  {
    public IEnumerable<string> Errors { get; private set; } = new List<string>();

    public ValidationFieldViewModelOutput(IEnumerable<string> errors)
    {
      Errors = errors;
    }
  }
}
