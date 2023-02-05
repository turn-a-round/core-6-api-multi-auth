using Microsoft.AspNetCore.Authentication;

services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.Authority = "https://example.com";
    options.Audience = "api";
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        // ValidIssuer = Configuration["Jwt:Issuer"],
        // ValidAudience = Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
        Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
    };
});

services.AddAuthorization(options =>
{
    options.AddPolicy("admin", policy => policy.Requirements.Add(new RoleRequirement("admin")));
    options.AddPolicy("user", policy => policy.Requirements.Add(new RoleRequirement("user")));

    // or
    options.AddPolicy("PolicyName", policy =>
        policy.RequireAuthenticatedUser().RequireRole("RoleName"));
});

services.AddSingleton<IAuthorizationHandler, RoleHandler>();



app.UseAuthentication();
app.UseAuthorization();

