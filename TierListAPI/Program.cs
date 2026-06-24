using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TierListAPI.Middlewares;
using TierListAPI.Persistence.Context;
using TierListAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigurePersistence();
builder.Services.ConfigureApplication();

builder.Services.ConfigureCorsPolicy();

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var jwtSecret = builder.Configuration["Jwt:Secret"] ?? throw new InvalidOperationException("Jwt:Secret não configurado em appsettings.json.");
var jwtIssuer = builder.Configuration["Jwt:Issuer"];
var jwtAudience = builder.Configuration["Jwt:Audience"];

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = jwtIssuer,

        ValidateAudience = true,
        ValidAudience = jwtAudience,

        ValidateLifetime = true,

        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret!))
    };
});

builder.Services.AddAuthorization();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseExceptionMiddleware();

var serviceScope = app.Services.CreateScope();
var context = serviceScope.ServiceProvider.GetRequiredService<TierListDBContext>()
    ?? throw new InvalidOperationException("Failed to resolve context from service provider.");

context.Database.EnsureCreated();

serviceScope.Dispose();

app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.Run();