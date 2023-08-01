using Maia.Maps.Domain.Interfaces;
using Maia.Maps.Domain.Interfaces.Repositories;
using Maia.Maps.Infra.Data.Context;
using Maia.Maps.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Maia.Maps.Infra.Data
{
    public static class Container
    {
        public static IMaiaMapsServiceBuilder AddMaiaMapsDbContext(this IMaiaMapsServiceBuilder builder, Action<DbContextOptionsBuilder> options)
        {
            AddDbContext(builder.Services, options);

            return builder;
        }

        private static void AddDbContext(IServiceCollection services, Action<DbContextOptionsBuilder> options)
        {
            var contextScope = ServiceLifetime.Scoped;

            services.AddDbContext<MaiaContext>(options, contextScope);
            services.Add(ServiceDescriptor.Describe(typeof(DbContext), provider => provider.GetRequiredService<MaiaContext>(), contextScope));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ISearchHistoryRepository, SearchHistoryRepository>();
            
        }
    }
}
