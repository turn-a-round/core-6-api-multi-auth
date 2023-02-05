public class GoogleAuthHandler : AuthorizationHandler<GoogleAuthRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, GoogleAuthRequirement requirement)
    {
        var googleClaim = context.User.Claims.FirstOrDefault(c => c.Type == "urn:google:name");
        if (googleClaim != null)
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }
}