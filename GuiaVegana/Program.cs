using Microsoft.EntityFrameworkCore;
using GuiaVegana.Data;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<GuiaVeganaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GuiaVeganaDBConnectionString")));

// Add controllers and other services
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setupAction =>
{
    //Esto va a permitir usar swagger con el token.
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
                    Id = "GuiaVeganaBearerAuth" }
                }, new List<string>() }
    });
});

builder.Services.AddAuthentication("Bearer") //"Bearer" es el tipo de auntenticacion que tenemos que elegir despues en PostMan para pasarle el token
    .AddJwtBearer(options => //Aca definimos la configuracion de la autenticacion. le decimos que cosas queremos comprobar. La fecha de expiracion se valida por defecto.
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Authentication:Issuer"],
            ValidAudience = builder.Configuration["Authentication:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Authentication:SecretForKey"]))
        };


        /////////////////////////////////aca para agregar el rol de usuario para poder ver luego de agarrarlo del front /////////////
        options.Events = new JwtBearerEvents
        {
            OnTokenValidated = context =>
            {
                // Agregar el rol como claim adicional al principal del usuario
                var identity = context.Principal.Identity as ClaimsIdentity;
                if (identity != null)
                {
                    var roleClaim = context.Principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);
                    if (roleClaim != null)
                    {
                        // Obtener el rol del token y agregarlo como claim adicional
                        var role = roleClaim.Value;
                        identity.AddClaim(new Claim(ClaimTypes.Role, role));
                    }
                }

                return Task.CompletedTask;
            }
        };
        //////////////////////////////////////////////////

    }
);


var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new UserProfile());
    cfg.AddProfile(new BusinessProfile());
    cfg.AddProfile(new HealthProfessionalProfile());
    cfg.AddProfile(new InformativeResourceProfile());
    cfg.AddProfile(new ActivismProfile());
});

var mapper = config.CreateMapper();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IBusinessRepository, BusinessRepository>();
builder.Services.AddScoped<IHealthProfessionalRepository, HealthProfessionalRepository>();
builder.Services.AddScoped<IInformativeResourceRepository, InformativeResourceRepository>();
builder.Services.AddScoped<IActivismRepository, ActivismRepository>();


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
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
