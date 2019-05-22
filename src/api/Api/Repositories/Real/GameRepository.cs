using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using Api.Models;
using Microsoft.Azure.KeyVault.Models;

namespace Api.Repositories.Real
{
    public class GameRepository : IGameRepository
    {
        public string Add(Game game)
        {
            var now = DateTime.Now;
            var key = Adler32(game.Name + now).ToString();

            using (var db = new ApiContext())
            {
                var dbGame = new Models.Game
                {
                    Key = key,
                    Name = game.Name,
                    Date = now,
                    StartingScore = game.StartingScore,
                    IsComplete = false
                };

                db.Games.Add(dbGame);
                db.SaveChanges();
            }

            return key;
        }

        public List<Game> GetAll()
        {
            using (var db = new ApiContext())
            {
                var games = new List<Game>();

                foreach (var dbGame in db.Games)
                {
                    games.Add(MapGame(db, dbGame));
                }

                return games;
            }
        }

        public List<Game> GetHistoric()
        {
            using (var db = new ApiContext())
            {
                var games = new List<Game>();

                foreach (var dbGame in db.Games.Where(g => g.IsComplete))
                {
                    games.Add(MapGame(db, dbGame));
                }

                return games;
            }
        }

        public Game GetByKey(string key)
        {
            using (var db = new ApiContext())
            {
                return MapGame(db, db.Games.SingleOrDefault(g => g.Key == key));
            }
        }


        private Game MapGame(ApiContext db, Models.Game dbGame)
        {
            var dbPlayers = db.Players.Where(p => p.GameId == dbGame.Id).OrderBy(p => p.TurnOrder);

            var players = new List<Player>();
            foreach (var dbPlayer in dbPlayers)
            {
                players.Add(
                    new Player
                    {
                        Name = dbPlayer.Name,
                        TurnOrder = dbPlayer.TurnOrder
                    }
                );
            }

            return new Game
            {
                Date = dbGame.Date,
                IsComplete = dbGame.IsComplete,
                Key = dbGame.Key,
                Name = dbGame.Name,
                Players = players,
                StartingScore = dbGame.StartingScore
            };
        }

        //https://gist.github.com/i-e-b/c37cc2d728fe5e5a56205cd7e62d682c
        private static uint Adler32(string str)
        {
            const int mod = 65521;
            uint a = 1, b = 0;
            foreach (char c in str)
            {
                a = (a + c) % mod;
                b = (b + a) % mod;
            }
            return (b << 16) | a;
        }
    }
}