using System.Collections.Generic;
using System.Linq;
using Api.Models;

namespace Api.Repositories.Real
{
    public class RoundRepository : IRoundRepository
    {
        public void Add(Round round)
        {
            var dbRound = new Models.Round
            {
                GameId = round.GameId,
                PlayerId = round.PlayerId,
                Score = round.Score,
                DartsUsed = round.DartsUsed
            };

            using (var db = new ApiContext())
            {
                db.Rounds.Add(dbRound);
                db.SaveChanges();
            }
        }

        public List<Round> GetAll(string gameKey)
        {
            using (var db = new ApiContext())
            {
                var rounds = new List<Round>();
                var dbGame = db.Games.Single(g => g.Key == gameKey);

                foreach (var dbRound in db.Rounds.Where(r => r.GameId == dbGame.Id))
                {
                    rounds.Add(MapRound(dbRound));
                }

                return rounds;
            }
        }

        public Round GetLastRound(string gameKey)
        {
            using (var db = new ApiContext())
            {
                var dbGame = db.Games.Single(g => g.Key == gameKey);
                return MapRound(db.Rounds.Where(r => r.GameId == dbGame.Id).OrderBy(r => r.Id).Last());
            }
        }

        private Round MapRound(Models.Round dbRound)
        {
            return new Round
            {
                GameId = dbRound.GameId,
                PlayerId = dbRound.PlayerId,
                Score = dbRound.Score,
                DartsUsed = dbRound.DartsUsed
            };
        }

        public Player NextRound(string gameKey)
        {
            var lastRound = GetLastRound(gameKey);
            using (var db = new ApiContext())
            {

            }

            throw new System.NotImplementedException();
        }
    }
}