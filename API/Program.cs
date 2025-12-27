using API.Contexts;
using API.DAL;
using API.DAL.Interfaces;
using API.Repositories;
using API.Repositories.Interfaces;
using API.Services;
using API.Services.Core;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//this is for add authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

builder.Services.AddAuthorization();

ConfigureServices(builder.Services);

var app = builder.Build();

Configure(app);

app.Run();

void ConfigureServices(IServiceCollection services)
{
    var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

    // CORS
    services.AddCors(options =>
    {
        options.AddPolicy(MyAllowSpecificOrigins,
            policy =>
            {
                policy.WithOrigins("http://localhost:4200")
      .AllowAnyHeader()
      .AllowAnyMethod();
            });
    });

    // Add DbContext with SQL Server
    builder.Services.AddDbContext<MyContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

    // Controllers
    services.AddControllers();

    // Swagger
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();

    // Dependency Injection
    services.AddScoped<IAuthService, AuthService>();
    services.AddScoped<IAuthDAL, AuthDAL>();

    services.AddScoped<IEmployeeService, EmployeeService>();
    services.AddScoped<IEmployeeDAL, EmployeeDAL>();
    services.AddScoped<IEmployeeRepository, EmplopyeeRepository>();

    services.AddScoped<IUsersService, UsersService>();
    services.AddScoped<IUsersDAL, UsersDAL>();

    services.AddScoped<IUserRolesService, UserRolesService>();
    services.AddScoped<IUserRolesDAL, UserRolesDAL>();
}

void Configure(WebApplication app)
{
    var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

    // Serve Angular Files
    app.UseDefaultFiles();
    app.UseStaticFiles();

    // Development Tools
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    // HTTPS
    app.UseHttpsRedirection();

    // Add middleware here
    app.UseMiddleware<RequestCounterMiddleware>();

    // CORS
    app.UseCors(MyAllowSpecificOrigins);

    // Authentication and Authorization
    app.UseAuthentication();
    app.UseAuthorization();

    // API Endpoints
    app.MapControllers();

    // Angular SPA Fallback
    app.MapFallbackToFile("/index.html");
}
