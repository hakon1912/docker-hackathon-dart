using Api.Repositories;
using Api.Repositories.Interfaces;
using Dartboard.Test.Client;
using Dartboard.Test.Mocks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Dartboard.Test
{
    public abstract class BaseTest
    {
        protected PersonServiceClient PersonServiceClient;
        protected Mock<IRoundRepository> PersonRepositoryMock;

        public BaseTest()
        {
            PersonRepositoryMock = new Mock<IRoundRepository>();

            var server = new TestServer(new WebHostBuilder()
                .UseStartup<StartupMock>()
                .ConfigureServices(services =>
                {
                    services.AddSingleton(PersonRepositoryMock.Object);
                }));

            var httpClient = server.CreateClient();
            PersonServiceClient = new PersonServiceClient(httpClient);
        }

        [TestCleanup]
        public void BaseTearDown()
        {
            PersonRepositoryMock.Reset();
        }
    }
}