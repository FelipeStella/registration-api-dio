namespace WebApplicationApi.Models.Views.Users
{
  public class LoginViewModelOutput
  {
    public string Token { get; set; }
    public LoginViewModelOutputDetails User { get; set; }


    public class LoginViewModelOutputDetails
    {
      public string UserName { get; set; }
      public string UserEmail { get; set; }
      public int Code { get; set; }
    }

  }
}
