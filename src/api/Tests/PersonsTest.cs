using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Api.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Dartboard.Test
{
    [TestClass]
    public class PersonsTest : BaseTest
    {
        private readonly Player _player = new Player
        {
            Id = 1,
            Name = "Mocked FN1",
            GameId = 1,
            TurnOrder = 1
        };

        [TestMethod]
        public async Task GetPerson_ReturnsCorrectResult()
        {
            PersonRepositoryMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(_player);

            var response = await PersonServiceClient.GetPerson("1");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual("Mocked FN1", response.Result.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public async Task GetPerson_ThrowsException()
        {
            PersonRepositoryMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Throws(new InvalidOperationException());

            var result = await PersonServiceClient.GetPerson("1");
        }

        [TestMethod]
        public async Task GetPersons()
        {
            PersonRepositoryMock.Setup(x => x.GetAll())
                .Returns(new List<Player> { _player });

            var response = await PersonServiceClient.GetPersons();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(1, response.Result.Count);
            Assert.AreEqual("Mocked FN1", response.Result[0].Name);
        }
    }
}
