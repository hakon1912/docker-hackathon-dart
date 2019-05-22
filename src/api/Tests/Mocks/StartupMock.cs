using Api;
using Api.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Dartboard.Test.Mocks
{
    public class StartupMock : Startup
    {
        private IRoundRepository _playerRepository;
        
        public StartupMock(IRoundRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public override void ConfigureRepositories(IServiceCollection services)
        {
            services.AddSingleton(_playerRepository);
        }
    }
}