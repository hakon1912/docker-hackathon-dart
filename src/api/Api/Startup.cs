using Api.Middleware;
using Api.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api
{
    public class Startup
    {
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
            services.AddMvc();
            services.Configure<AppConfig>(Configuration);

            ConfigureRepositories(services);
        }

        public virtual void ConfigureRepositories(IServiceCollection services)
        {
            services.AddSingleton<IPlayerRepository, PlayerRepository>();
            services.AddSingleton<IGameRepository, GameRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMiddleware<HttpExceptionMiddleware>();
            app.UseMvc();
        }
    }
}
