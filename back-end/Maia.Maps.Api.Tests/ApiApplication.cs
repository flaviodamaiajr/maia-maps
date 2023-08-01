using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore.Storage;
using Maia.Maps.Infra.Data.Context;

namespace Maia.Maps.Api.Tests
{
    public class ApiApplication : WebApplicationFactory<Program>
    {
        protected override IHost CreateHost(IHostBuilder builder)
        {
            var root = new InMemoryDatabaseRoot();

            builder.ConfigureServices(services =>
            {
                services.RemoveAll(typeof(DbContextOptions<MaiaContext>));

                services.AddDbContext<MaiaContext>(options =>
                    options.UseInMemoryDatabase("MaiaMaps", root));
            });

            return base.CreateHost(builder);
        }
    }
}
