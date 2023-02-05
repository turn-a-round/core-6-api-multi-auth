public class RoleHandler : AuthorizationHandler<RoleRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RoleRequirement requirement)
    {
        var roleClaim = context.User.FindFirst(ClaimTypes.Role);
        if (roleClaim != null && roleClaim.Value == requirement.Role)
        {
            context.Succeed(requirement);
        }
        return Task.CompletedTask;
    }
}
