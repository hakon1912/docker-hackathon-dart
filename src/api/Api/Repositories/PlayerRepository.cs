using System.Collections.Generic;
using System.Linq;
using Api.Models;

namespace Api.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private Dictionary<int, Player> _persons = new Dictionary<int, Player>();

        public PlayerRepository()
        {
            _persons.Add(1, new Player { Id = 1, Name = "FN1", GameId=1, TurnOrder=0 });
            _persons.Add(2, new Player { Id = 2, Name = "FN2", GameId=1, TurnOrder=1 });
            _persons.Add(3, new Player { Id = 3, Name = "FN3", GameId=1, TurnOrder=2 });
            _persons.Add(4, new Player { Id = 4, Name = "FN4", GameId=1, TurnOrder=3 });
        }

        public Player GetById(int id)
        {
            return _persons[id];
        }

        public List<Player> GetAll()
        {
            return _persons.Values.ToList();
        }

        public int GetCount()
        {
            return _persons.Count();
        }

        public void Remove()
        {
            if (_persons.Keys.Any())
            {
                _persons.Remove(_persons.Keys.Last());
            }
        }

        public string Save(Player player)
        {
            if (_persons.ContainsKey(player.Id))
            {
                _persons[player.Id] = player;
                return "Updated Player with id=" + player.Id;
            }
            else
            {
                _persons.Add(player.Id, player);
                return "Added Player with id=" + player.Id;
            }
        }
    }
}