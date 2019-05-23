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
        private readonly Round _round = new Round
        {
            Id = 1
           
        };

       
        [TestMethod]
        public async Task GetRounds()
        {
            PersonRepositoryMock.Setup(x => x.GetAll("key"))
                .Returns(new List<Round> { _round });

            var response = await PersonServiceClient.GetPersons();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(1, response.Result.Count);
            Assert.AreEqual("Mocked FN1", response.Result[0].Name);
        }
    }
}
