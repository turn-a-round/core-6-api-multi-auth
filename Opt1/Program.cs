using Microsoft.AspNetCore.Authentication;

services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.Authority = "https://your_auth0_instance.auth0.com/";
    options.Audience = "your_api_identifier";
});

services.AddAuthorization(options =>
{
    options.AddPolicy("read:messages", policy => policy.Requirements.Add(new HasScopeRequirement("read:messages", "https://your_auth0_instance.auth0.com/")));
});
services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();



app.UseAuthentication();
app.UseAuthorization();

