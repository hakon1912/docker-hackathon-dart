using System.Collections.Generic;
using System.Linq;
using Api.Models;
using Api.Repositories;
using Api.Repositories.Interfaces;

namespace Dartboard.Test.Mocks
{
    public class RoundRepositoryStub : IRoundRepository
    {
        private Dictionary<int, Round> _rounds = new Dictionary<int, Round>();

        public RoundRepositoryStub()
        {
            _rounds.Add(1, new Round { Id = 1 });
        }

        
        public List<Round> GetAll()
        {
            return _rounds.Values.ToList();
        }

        public List<Round> GetAll(string gameKey)
        {
            throw new System.NotImplementedException();
        }

        public Round GetLastRound(string gameKey)
        {
            throw new System.NotImplementedException();
        }

        public Player NextRound(string gameKey)
        {
            throw new System.NotImplementedException();
        }

        public Player NextRound(int gameId)
        {
            throw new System.NotImplementedException();
        }

        void IRoundRepository.Add(Round round)
        {
            throw new System.NotImplementedException();
        }

        public string Add(Round player)
        {
            var result = "";
            if (_rounds.ContainsKey(player.Id))
            {
                result = "Updated Player with id=" + player.Id;
            }
            else
            {
                result = "Added Player with id=" + player.Id;
            }
            _rounds.Add(player.Id, player);
            return result;
        }

        List<Round> IRoundRepository.GetAll(string gameKey)
        {
            throw new System.NotImplementedException();
        }
    }
}