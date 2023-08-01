using Maia.Maps.Domain;
using Maia.Maps.Infra.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace Maia.Maps.Api
{
    public class Startup : IStartup
    {
        private const string CorsPolicy = "Production";
        private const string MySQL = "MySQL";

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddMaiaMaps().AddMaiaMapsDbContext(options =>
            {
                var assembly = typeof(Startup).Assembly;

                var mySqlConnection = Configuration.GetConnectionString(MySQL);

                options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection),
                    b => b.MigrationsAssembly(assembly.FullName));

                if (Environment.IsDevelopment())
                {
                    options.EnableSensitiveDataLogging().EnableDetailedErrors();
                }
            });

            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
            });
            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
            services.AddCors(options => options.AddPolicy(CorsPolicy, b => b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

            services.AddHttpClient();
            services.AddHttpContextAccessor();

            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Maia.Maps",
                    Version = "v1",
                    Description = "",
                    Contact = new OpenApiContact()
                    {
                        Name = "Flávio Antônio da Maia Júnior",
                        Url = new Uri("https://github.com/flaviodamaiajr")
                    }
                });
            });

            services.AddAuthorization();
        }

        public void Configure(WebApplication app, IWebHostEnvironment environment)
        {
            app.UseCors(CorsPolicy);

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("v1/swagger.json", "Maia.Maps - API v1");
                });
            }
            else
            {
                app.UseHsts();
            }

            app.UseExceptionHandler("/error");

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

    public interface IStartup
    {
        IConfiguration Configuration { get; }
        void Configure(WebApplication app, IWebHostEnvironment env);
        void ConfigureServices(IServiceCollection services);
    }

    public static class StartupExtensions
    {
        public static WebApplicationBuilder UseStartup<TStartup>(this WebApplicationBuilder webApplicationBuilder) where TStartup : IStartup
        {
            var startup = Activator.CreateInstance(typeof(TStartup), webApplicationBuilder.Configuration, webApplicationBuilder.Environment) as IStartup;

            ArgumentNullException.ThrowIfNull(startup, "Startup class is invalid!");

            startup.ConfigureServices(webApplicationBuilder.Services);

            var app = webApplicationBuilder.Build();
            startup.Configure(app, app.Environment);

            app.Run();

            return webApplicationBuilder;
        }
    }
}
