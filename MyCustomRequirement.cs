using Microsoft.AspNetCore.Authorization;

namespace CustomAuthorizationRequirement;

public class MyCustomRequirement : IAuthorizationRequirement
{
  public string Group{ get; }
  
  public MyCustomRequirement(string group)
  {
    Group = group;
  }

  public bool IsValid(string group)
  {
    return string.Equals(group, Group, StringComparison.CurrentCultureIgnoreCase);
  }
}

