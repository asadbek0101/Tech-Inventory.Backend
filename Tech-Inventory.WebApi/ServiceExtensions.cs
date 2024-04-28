using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Tech_Inventory.Application.Common.Interfaces;
using Tech_Inventory.WebApi.Services;
using Microsoft.AspNetCore.Identity;
using Tech_Inventory.Persistence;
using Tech_Inventory.Domain.IdentityEntities;

namespace Tech_Inventory.WebApi;

public static class ServiceExtensions
{
    public static void ConfigureWebApi(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", policy =>
            {
                policy.WithOrigins("https://localhost:3000", "https://localhost:3001");
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
                policy.AllowAnyOrigin();
            });
        });

        services.AddTransient<ICurrentUserService, CurrentUserService>();

        services.AddSwaggerGen(swagger =>
        {
            //This is to generate the Default UI of Swagger Documentation  
            swagger.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Tech-Inventory Api",
                Description = "ASP.NET Core 8 Clean Architecture"
            });
            // To Enable authorization using Swagger (JWT)  
            swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
            });
            swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

                    }
                });
        });

        services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<TechInventoryDB>()
                .AddDefaultTokenProviders();

        services.AddAuthorization(o =>
        {
            o.AddPolicy("ReadAllUsers", p => p.RequireClaim("readAllUsers", "ReadAllUsers"));
            o.AddPolicy("ReadOneUser", p => p.RequireClaim("readOneUser", "ReadOneUser"));
            o.AddPolicy("CreateUser", p => p.RequireClaim("createUser", "CreateUser"));
            o.AddPolicy("DeleteUser", p => p.RequireClaim("deleteUser", "DeleteUser"));
            o.AddPolicy("UpdateUser", p => p.RequireClaim("updateUser", "UpdateUser"));
            
            o.AddPolicy("ReadAllObyekts", p => p.RequireClaim("readAllObyekts", "ReadAllObyekts"));
            o.AddPolicy("ReadOneObyekt", p => p.RequireClaim("readOneObyekt", "ReadOneObyekt"));
            o.AddPolicy("CreateObyekt", p => p.RequireClaim("createObyekt", "CreateObyekt"));
            o.AddPolicy("UpdateObyekt", p => p.RequireClaim("updateObyekt", "UpdateObyekt"));
            o.AddPolicy("DeleteObyekt", p => p.RequireClaim("deleteObyekt", "DeleteObyekt"));
        });

        services.AddAuthentication(option =>
        {
            option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["Jwt:Issuer"],
                ValidAudience = configuration["Jwt:Issuer"],

                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
            };
        });
    }
}

