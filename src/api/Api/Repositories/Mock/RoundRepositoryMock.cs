using System.Collections.Generic;
using System.Linq;
using Api.Models;
using Api.Repositories.Interfaces;

namespace Api.Repositories.Mock
{
    public class RoundRepositoryMock : IRoundRepository
    {
        private Dictionary<int, Round> _rounds = new Dictionary<int, Round>();

        public RoundRepositoryMock()
        {
            _rounds.Add(1, new Round { Id = 1 });
            _rounds.Add(2, new Round { Id = 2 });
            _rounds.Add(3, new Round { Id = 3 });
            _rounds.Add(4, new Round { Id = 4 });
        }

        public List<Round> GetAll(string gameKey)
        {

            return _rounds.Values.ToList();
        }

        public Round GetLastRound(string gameKey)
        {
            throw new System.NotImplementedException();
        }

        public Player NextRound(string gameKey)
        {
            throw new System.NotImplementedException();
        }

        public void Add(Round round)
        {
            
        }

        public Player NextRound(string gameKey)
        {
            return new Player(){Id=1,Name="NextOne" , GameId=1, RoundNumber=1, CurrentScore=201 };
        }
    }
}