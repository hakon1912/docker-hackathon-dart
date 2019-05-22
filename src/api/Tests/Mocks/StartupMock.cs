using Api;
using Api.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace SampleDotNetCore2RestStub.Integration.Test.Mocks
{
    public class StartupMock : Startup
    {
        private IPlayerRepository _playerRepository;
        
        public StartupMock(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public override void ConfigureRepositories(IServiceCollection services)
        {
            services.AddSingleton(_playerRepository);
        }
    }
}