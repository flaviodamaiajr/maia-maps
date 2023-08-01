using Maia.Maps.Domain.Behaviors;
using Maia.Maps.Domain.Interfaces;
using Maia.Maps.Domain.Interfaces.Services;
using Maia.Maps.Domain.Services;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Maia.Maps.Domain
{
    public static class Container
    {
        public static IMaiaMapsServiceBuilder AddMaiaMaps(this IServiceCollection services)
        {
            var assembly = typeof(Container).Assembly;
            services.AddMediatR(assembly);

            services.AddValidatorsFromAssembly(assembly);

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            AddServices(services);

            return new MaiaMapsServiceBuilder(services);
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IMapsService, MapsService>();
        }

        public class MaiaMapsBuilder : IMaiaMapsServiceBuilder
        {
            public MaiaMapsBuilder(IServiceCollection services)
            {
                Services = services;
            }

            public IServiceCollection Services { get; }
        }
    }
}