using Api;
using Api.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace SampleDotNetCore2RestStub.Integration.Test.Mocks
{
    public class StartupStub : Startup
    {
        public override void ConfigureRepositories(IServiceCollection services)
        {
            services.AddSingleton<IPlayerRepository, PlayerRepositoryStub>();
        }
    }
}