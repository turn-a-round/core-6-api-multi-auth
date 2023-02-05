using Microsoft.AspNetCore.Authentication;

services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = Configuration["Jwt:Issuer"],
            ValidAudience = Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
        };
    })
    .AddGoogle(options =>
    {
        options.ClientId = Configuration["Authentication:Google:ClientId"];
        options.ClientSecret = Configuration["Authentication:Google:ClientSecret"];
    });

services.AddAuthorization(options =>
{
    options.AddPolicy("GoogleOnly", policy => policy.Requirements.Add(new GoogleAuthRequirement()));
    options.AddPolicy("JwtOnly", policy => policy.Requirements.Add(new JwtAuthRequirement()));
});

services.AddSingleton<IAuthorizationHandler, GoogleAuthHandler>();
services.AddSingleton<IAuthorizationHandler, JwtAuthHandler>();



app.UseAuthentication();
app.UseAuthorization();

