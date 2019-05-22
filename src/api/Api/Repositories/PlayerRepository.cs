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
            _persons.Add(1, new Player { Id = 1, FirstName = "FN1", LastName = "LN1", Email = "email1@email.na" });
            _persons.Add(2, new Player { Id = 2, FirstName = "FN2", LastName = "LN2", Email = "email2@email.na" });
            _persons.Add(3, new Player { Id = 3, FirstName = "FN3", LastName = "LN3", Email = "email3@email.na" });
            _persons.Add(4, new Player { Id = 4, FirstName = "FN4", LastName = "LN4", Email = "email4@email.na" });
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