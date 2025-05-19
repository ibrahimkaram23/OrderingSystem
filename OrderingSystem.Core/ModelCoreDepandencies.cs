using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OrderingSystem.Core.Behaviors;
using OrderingSystem.Service.Abstracts;
using OrderingSystem.Service.Implementations;
using System.Reflection;
using Mapster;
using MapsterMapper;

namespace OrderingSystem.Core
{
    public static class ModelCoreDepandencies
    {
        public static IServiceCollection AddCoreDepandencies(this IServiceCollection services)
        {
            //configratation of madiator
            services.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            //configration of AddMapster
            #region Mappster

            var config = TypeAdapterConfig.GlobalSettings;

            config.Scan(Assembly.GetExecutingAssembly());

            services.AddSingleton(config);

            TypeAdapterConfig.GlobalSettings.Default.NameMatchingStrategy(NameMatchingStrategy.Flexible);

            services.AddScoped<IMapper, ServiceMapper>();

            #endregion

            //Get validators
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>)); 
            return services;
        }

    }
}
