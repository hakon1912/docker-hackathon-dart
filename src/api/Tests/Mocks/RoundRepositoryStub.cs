using System.Collections.Generic;
using System.Linq;
using Api.Models;
using Api.Repositories;

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
    }
}