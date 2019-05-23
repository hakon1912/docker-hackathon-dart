using System;
using Api.Middleware;
using Api.Repositories.Interfaces;
using Api.Repositories.Mock;
using Api.Repositories.Real;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Api
{
    public class Startup
    {
        private const string LOCALHOST_CORS_POLICY = "localhost_cors";
        private bool useRealServices = true;
        public Startup()
        {
            var configurationBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            Configuration = configurationBuilder.Build();

        }

        public IConfiguration Configuration { get; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(LOCALHOST_CORS_POLICY,
                    builder => { builder.WithOrigins("http://localhost:3000"); });
            });
            services.AddMvc();
            services
                .AddEntityFrameworkNpgsql()
                .AddDbContext<ApiContext>();

            services.Configure<AppConfig>(Configuration);

            ConfigureRepositories(services);

            return services.BuildServiceProvider();
        }

        public virtual void ConfigureRepositories(IServiceCollection services)
        {
            if (useRealServices == true)
            {
                services.AddSingleton<IRoundRepository, RoundRepository>();
                services.AddSingleton<IGameRepository, GameRepository>();
            }
            else
            {
                services.AddSingleton<IRoundRepository, RoundRepositoryMock>();
                services.AddSingleton<IGameRepository, GameRepositoryMock>();
            }
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMiddleware<HttpExceptionMiddleware>();
            app.UseCors(LOCALHOST_CORS_POLICY);

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<ApiContext>();
                if (!context.Database.EnsureCreated())
                    context.Database.Migrate();
            }

        }
    }
}
