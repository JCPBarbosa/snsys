using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Text;
using TesteSNSYS.Apis;
using TesteSNSYS.Application.Interfaces;
using TesteSNSYS.Application.Service;
using TesteSNSYS.Domain.Core.Models;
using TesteSNSYS.Domain.Entities;
using TesteSNSYS.Domain.Interfaces.Repositories;
using TesteSNSYS.Domain.Interfaces.Service;
using TesteSNSYS.Domain.Service;
using TesteSNSYS.Infra.Data.Context;
using TesteSNSYS.Infra.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

AppContext.SetSwitch("Switch.AmazingLib.ThrowOnException", true);
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Host.UseSerilog((ctx, lc) => lc
    .MinimumLevel.Warning()
    .WriteTo.Console()
    .WriteTo.File(Path.Combine($"{Directory.GetCurrentDirectory()}\\Logs\\{DateTime.Now.ToString("dd-MM-yyyy")}", $"Log_{DateTime.Now.ToString("ddMMyyyy_HHmmss")}.txt"),
    rollingInterval: RollingInterval.Day));


builder.Services.AddDbContext<PostGresContext>(options => options.UseNpgsql(builder.Configuration["ConnectionStrings:DefaultConnection"]), ServiceLifetime.Scoped);

var autoMapperConfig = new MapperConfiguration(cfg =>
{
    /*Aqui seria feita a criptografia de algum dado sensivel com Ids ou outros, pensando na questão de seguraça*/
    cfg.CreateMap<Customer, CustomerViewModel>()
    .ReverseMap();
});

builder.Services.AddSingleton(autoMapperConfig.CreateMapper());

builder.Services.AddControllers();

var key = Encoding.ASCII.GetBytes(Settings.Secret);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(s =>
{
    s.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "SNSYS API",
        Description = "API .NET Core 6",
        Contact = new OpenApiContact
        {
            Name = "SNSYS",
            Email = string.Empty,
            Url = new Uri("https://www.snsys.com.br")
        }
    });

    s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme."
    });

    s.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme {
                            Reference = new OpenApiReference {
                                Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                            }
                        },
                        new string[] { }

                    }
                });
});

builder.Services.AddScoped(typeof(IAppServiceBase<>), typeof(AppServiceBase<>));
builder.Services.AddScoped<IUserAppService, UserAppService>();
builder.Services.AddScoped<ICustomerAppService, CustomerAppService>();

builder.Services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
builder.Services.AddScoped<IUserService, UserBase>();
builder.Services.AddScoped<ICustomerService, CustomerBase>();

builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
   app.UseSwagger();
   app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
