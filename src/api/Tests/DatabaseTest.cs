using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Api.Models;
using Api.Repositories.Real;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Game = Api.Repositories.Models.Game;

namespace Dartboard.Test
{
    [TestClass]
    public class DatabaseTest : BaseTest
    {
        [TestMethod]
        public async Task CreateAndRetrieveNewGame()
        {
            var dbGame = new Game
            {
                Date = DateTime.Now,
                Key = "TEST "+ DateTime.Now,
                Name = "TEST",
                StartingScore = 201,
                IsComplete = false
            };

            using (var db = new ApiContext())
            {
                var count = db.Games.Add(dbGame);
                //Assert.AreEqual(1, count);

                var storedGame = db.Games.Single(g => g.Key == dbGame.Key);
                Assert.IsNotNull(storedGame.Id);
            }
        }
    }
}
