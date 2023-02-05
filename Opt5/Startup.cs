public void ConfigureServices(IServiceCollection services)
{
   services.AddAuthentication(options =>
   {
      options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
      options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
   })
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
   .AddOAuth(options =>
   {
      options.ClientId = Configuration["OAuth:ClientId"];
      options.ClientSecret = Configuration["OAuth:ClientSecret"];
      options.CallbackPath = "/signin-OAuth";
      options.AuthorizationEndpoint = "https://authorization-server.com/oauth/authorize";
      options.TokenEndpoint = "https://authorization-server.com/oauth/token";
      options.UserInformationEndpoint = "https://authorization-server.com/oauth/user";
   });
}
