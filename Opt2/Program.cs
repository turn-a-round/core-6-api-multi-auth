using Microsoft.AspNetCore.Authentication;

services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.Authority = "https://api.mytenant.com";
    options.Audience = "my-api";
});

services.AddAuthorization(options =>
{
    options.AddPolicy("default", policy => policy.RequireClaim("scope", "my-api"));
});



app.UseAuthentication();
app.UseAuthorization();

