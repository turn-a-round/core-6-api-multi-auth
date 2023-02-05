public class JwtAuthHandler : AuthorizationHandler<JwtAuthRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, JwtAuthRequirement requirement)
    {
        var jwtClaim = context.
