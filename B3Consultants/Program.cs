using B3Consultants;
using B3Consultants.DB;
using B3Consultants.Services;
using B3Consultants.Middleware;
using System.Text.Json.Serialization;
using NLog.Web;
using Microsoft.AspNetCore.Identity;
using B3Consultants.Entities;
using B3Consultants.EntitiesDTOs.Validators;
using B3Consultants.EntitiesDTOs;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var authenticationSettings = new AuthenticationSettings();

builder.Configuration.GetSection("Authentication").Bind(authenticationSettings);

builder.Services.AddSingleton(authenticationSettings);

//Authentication
builder.Services.AddAuthentication(option =>
   {
       option.DefaultAuthenticateScheme = "Bearer";
       option.DefaultScheme = "Bearer";
       option.DefaultChallengeScheme = "Bearer";
   }).AddJwtBearer(cfg =>
   {
       cfg.RequireHttpsMetadata = false;
       cfg.SaveToken = true;
       cfg.TokenValidationParameters = new TokenValidationParameters
       {
           ValidIssuer = authenticationSettings.JwtIssuer,
           ValidAudience = authenticationSettings.JwtIssuer,
           IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey))
       };
   });

// Add services to the container.
builder.Services.AddControllers().AddFluentValidation();
builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// NLog: Setup NLog for Dependency injection
builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
builder.Host.UseNLog();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<ConsultantDBContext>();
builder.Services.AddScoped<DataSeeder>();
builder.Services.AddScoped<IConsultantService, ConsultantService>();
builder.Services.AddScoped<IExperienceService, ExperienceService>();
builder.Services.AddScoped<IAvailabilityService, AvailabilityService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
builder.Services.AddScoped<IValidator<RegisterUserDTO>, RegisterUserDTOValidator>();
builder.Services.AddScoped<IValidator<AddConsultantDTO>, AddConsultantDTOValidator>();
builder.Services.AddScoped<ErrorHandlingMiddleware>();
builder.Services.AddScoped<RequestTimeMiddleware>();

var app = builder.Build();

var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<DataSeeder>();

// Configure the HTTP request pipeline.

seeder.Seed();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

seeder.Seed();

app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseMiddleware<RequestTimeMiddleware>();

app.UseAuthentication();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
