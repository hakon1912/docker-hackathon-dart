using System.Collections.Generic;
using System.Linq;
using Api.Models;

namespace Api.Repositories
{
    public class RoundRepository : IRoundRepository
    {
        private Dictionary<int, Round> _rounds = new Dictionary<int, Round>();

        public RoundRepository()
        {
            _rounds.Add(1, new Round { Id = 1 });
            _rounds.Add(2, new Round { Id = 2 });
            _rounds.Add(3, new Round { Id = 3 });
            _rounds.Add(4, new Round { Id = 4 });
        }

        public List<Round> GetAll()
        {

            return _rounds.Values.ToList();
        }

        public string Add(Round round)
        {
            if (_rounds.ContainsKey(round.Id))
            {
                _rounds[round.Id] = round;
                return "Updated Player with id=" + round.Id;
            }
            else
            {
                _rounds.Add(round.Id, round);
                return "Added Player with id=" + round.Id;
            }
        }

        public Player NextRound(int gameId)
        {
            return new Player(){Id=1,Name="NextOne" , GameId=gameId, RoundNumber=1, CurrentScore=201 };
        }
    }
}