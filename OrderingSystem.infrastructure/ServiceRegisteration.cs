using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using OrderingSystem.Data.Entities.Identity;
using OrderingSystem.Data.Helpers;
using OrderingSystem.infrastructure.Data;
using System.Text;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;
using Microsoft.OpenApi.Any;
using Swashbuckle.AspNetCore.SwaggerGen;

public static class ServiceRegistration
{
    public static IServiceCollection AddServiceRegistration(this IServiceCollection services,IConfiguration configuration)
    {
        
        services.AddIdentity<User, Role>(options =>
        {
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireUppercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequiredLength = 6;
            options.Password.RequiredUniqueChars = 1;

            //lockout setting
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.AllowedForNewUsers = true;

            //user settings
            options.User.AllowedUserNameCharacters =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            options.User.RequireUniqueEmail = true;
            options.SignIn.RequireConfirmedEmail = true;
        })
        .AddEntityFrameworkStores<APPDBContext>()
        .AddDefaultTokenProviders();

        // Jwt Authentication
        var jwtSettings = new JwtSettings();
        var emailSettings = new EmailSettings();
        configuration.GetSection(nameof(jwtSettings)).Bind(jwtSettings);
        configuration.GetSection(nameof(emailSettings)).Bind(emailSettings);
        services.AddSingleton(jwtSettings);
        services.AddSingleton(emailSettings);


        services.AddAuthentication(x =>
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
                 ValidateIssuer = jwtSettings.ValidateIssuser,
                 ValidIssuers = new[] { jwtSettings.Issuser },
                 ValidateIssuerSigningKey = jwtSettings.ValidateIssuserSigingKey,
                 IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Secret)),
                 ValidAudience = jwtSettings.Audience,
                 ValidateAudience = jwtSettings.ValidateAudience,
                 ValidateLifetime = jwtSettings.ValidateLifeTime,
             };
             x.Events = new JwtBearerEvents
             {
                 OnAuthenticationFailed = context =>
                 {
                     if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                     {
                         context.Response.Headers.Add("Token-Expired", "true");
                         context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                         context.Response.ContentType = "application/json";
                         var message = new { message = "access token has expired" };
                         var json = JsonSerializer.Serialize(message);
                         return context.Response.WriteAsync(json);
                     }
                     return System.Threading.Tasks.Task.CompletedTask;
                 }
             };
         });

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ordering System", Version = "v1" });
            c.EnableAnnotations();

            c.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = JwtBearerDefaults.AuthenticationScheme
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
            {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = JwtBearerDefaults.AuthenticationScheme
                }
            },
            Array.Empty<string>()
                }
           });
            c.OperationFilter<MyHeaderFilter>();
        });
        return services;
    }
}
public class MyHeaderFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        if (operation.Parameters == null)
            operation.Parameters = new List<OpenApiParameter>();

        operation.Parameters.Add(new OpenApiParameter
        {
            Name = "Accept-Language",
            In = ParameterLocation.Header,
            Schema = new OpenApiSchema
            {
                Type = "string",
                Default = new OpenApiString("En")
            },
            Required = false
        });
    }
}
