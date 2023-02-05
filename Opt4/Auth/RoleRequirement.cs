public class RoleRequirement : IAuthorizationRequirement
{
  public string Role {get;set;}

  public RoleRequirement(string role)
  {
    Role = role;
  }
}