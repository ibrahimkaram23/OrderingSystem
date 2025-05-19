using Microsoft.Extensions.DependencyInjection;
using OrderingSystem.infrastructure.Abstract;
using OrderingSystem.infrastructure.Repositieries;
using OrderingSystem.Service.Abstracts;
using OrderingSystem.Service.AuthService.Implementations;
using OrderingSystem.Service.AuthService.Interfaces;
using OrderingSystem.Service.Implementations;

namespace OrderingSystem.Service
{
    public static class ModelServiceDepandencies
    {
        public static IServiceCollection AddServiceDepandencies(this IServiceCollection services)
        {
            services.AddTransient<IAuthenicationService, AuthenicationService>();
            services.AddTransient<IAuthorizationService, AuthorizationService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IApplicationUserService, ApplicationUserService>();
            services.AddTransient<ICurrentUserService, CurrentUserService>();
            services.AddTransient<IFileService, FileService>();
            return services;
        }
    }
}
