using Api;
using Api.Repositories;
using Api.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Dartboard.Test.Mocks
{
    public class StartupStub : Startup
    {
        public override void ConfigureRepositories(IServiceCollection services)
        {
            services.AddSingleton<IRoundRepository, RoundRepositoryStub>();
        }
    }
}