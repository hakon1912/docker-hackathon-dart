using System.Collections.Generic;
using System.Linq;
using Api.Models;

namespace Api.Repositories
{
    public class RoundRepository : IRoundRepository
    {
        private Dictionary<int, Round> _persons = new Dictionary<int, Round>();

        public RoundRepository()
        {
            _persons.Add(1, new Round { Id = 1 });
            _persons.Add(2, new Round { Id = 2 });
            _persons.Add(3, new Round { Id = 3 });
            _persons.Add(4, new Round { Id = 4 });
        }

        public List<Round> GetAll(string gameKey)
        {

            return _persons.Values.ToList();
        }

        public void Add(Round round)
        {
            
        }
    }
}