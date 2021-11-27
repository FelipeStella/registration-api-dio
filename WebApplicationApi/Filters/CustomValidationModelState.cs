using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApplicationApi.Models;

namespace WebApplicationApi.Filters
{
  public class CustomValidationModelState : ActionFilterAttribute
  {
    public override void OnActionExecuting(ActionExecutingContext context)
    {
      if (!context.ModelState.IsValid)
      {
        var validationFieldViewModelOutput = new ValidationFieldViewModelOutput(
          context.ModelState.SelectMany(sm => sm.Value.Errors)
          .Select(s => s.ErrorMessage));

        context.Result = new BadRequestObjectResult(validationFieldViewModelOutput);
      }
    }
  }
}
