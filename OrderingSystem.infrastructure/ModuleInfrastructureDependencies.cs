using Microsoft.Extensions.DependencyInjection;
using OrderingSystem.infrastructure.Abstract;
using OrderingSystem.infrastructure.InfastructureBases;
using OrderingSystem.infrastructure.Repositieries;

namespace OrderingSystem.infrastructure
{
    public static class ModuleInfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {
           
            services.AddTransient<IRefershTokenRepository, RefershTokenRepository>();
            services.AddTransient(typeof(IGenericRepositoryAsync<>), (typeof(GenericRepositoryAsync<>)));
            return services;
        }
    }
}
