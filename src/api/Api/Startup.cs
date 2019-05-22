using Api.Middleware;
using Api.Repositories;
using Api.Repositories.Real;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using GameRepository = Api.Repositories.GameRepository;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Microsoft.EntityFrameworkCore;

namespace Api
{
    public class Startup
    {
        private const string LOCALHOST_CORS_POLICY = "localhost_cors";

        public Startup()
        {
            var configurationBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            Configuration = configurationBuilder.Build();

        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(LOCALHOST_CORS_POLICY,
                    builder => { builder.WithOrigins("http://localhost:3000"); });
            });

            services
                .AddEntityFrameworkNpgsql()
                .AddDbContext<ApiContext>()
                .BuildServiceProvider();

            services.Configure<AppConfig>(Configuration);

            ConfigureRepositories(services);
        }

        public virtual void ConfigureRepositories(IServiceCollection services)
        {
            services.AddSingleton<IRoundRepository, RoundRepository>();
            services.AddSingleton<IGameRepository, GameRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMiddleware<HttpExceptionMiddleware>();
            app.UseCors(LOCALHOST_CORS_POLICY);
            app.UseMvc();
        }
    }
}
