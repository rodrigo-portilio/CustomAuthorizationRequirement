using Microsoft.AspNetCore.Authorization;

namespace CustomAuthorizationRequirement;

public class MyCustomHandler : AuthorizationHandler<MyCustomRequirement>
{

    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MyCustomRequirement requirement)
    {

        // It is validated if has a user in request
        if (context.User != null)
        {
            var group = context.User.Claims.FirstOrDefault(x => x.Type.ToLower() == "group")?.Value;
            
            if (group != null && requirement.IsValid(group))
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }

            context.Fail();
            
        }

        return Task.CompletedTask;
    }
}
