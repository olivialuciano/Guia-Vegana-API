using Microsoft.EntityFrameworkCore;
using GuiaVegana.Data;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using AutoMapper;
using GuiaVegana.Profiles;
using GuiaVegana.Data.Repository.Interfaces;
using GuiaVegana.Data.Repository.Implementations;
using GuiaVegana.Repositories;
using GuiaVegana.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<GuiaVeganaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GuiaVeganaDBConnectionString")));

// Add controllers and other services
builder.Services.AddControllers().AddNewtonsoftJson();

// Swagger/OpenAPI configuration
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setupAction =>
{
    setupAction.AddSecurityDefinition("GuiaVeganaBearerAuth", new OpenApiSecurityScheme()
    {
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        Description = "Token:"
    });

    setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "GuiaVeganaBearerAuth"
                }
            },
            new List<string>()
        }
    });
});

// Configure authentication
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Authentication:Issuer"],
            ValidAudience = builder.Configuration["Authentication:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes(builder.Configuration["Authentication:SecretForKey"])
            )
        };

        // Add role claims from token
        options.Events = new JwtBearerEvents
        {
            OnTokenValidated = context =>
            {
                var identity = context.Principal.Identity as ClaimsIdentity;
                if (identity != null)
                {
                    var roleClaim = context.Principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);
                    if (roleClaim != null)
                    {
                        identity.AddClaim(new Claim(ClaimTypes.Role, roleClaim.Value));
                    }
                }
                return Task.CompletedTask;
            }
        };
    });

// Register AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Register repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IBusinessRepository, BusinessRepository>();
builder.Services.AddScoped<IHealthProfessionalRepository, HealthProfessionalRepository>();
builder.Services.AddScoped<IInformativeResourceRepository, InformativeResourceRepository>();
builder.Services.AddScoped<IActivismRepository, ActivismRepository>();
builder.Services.AddScoped<IOpeningHourRepository, OpeningHourRepository>();
builder.Services.AddScoped<IVeganOptionRepository, VeganOptionRepository>();

// Enable CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
