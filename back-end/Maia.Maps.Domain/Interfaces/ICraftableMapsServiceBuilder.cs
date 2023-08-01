using Microsoft.Extensions.DependencyInjection;

namespace Maia.Maps.Domain.Interfaces
{
    public interface IMaiaMapsServiceBuilder
    {
        IServiceCollection Services { get; }

    }

    internal class MaiaMapsServiceBuilder : IMaiaMapsServiceBuilder
    {
        public MaiaMapsServiceBuilder(IServiceCollection services)
        {
            Services = services;
        }

        public IServiceCollection Services { get; }
    }
}
