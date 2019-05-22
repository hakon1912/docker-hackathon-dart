using System.Collections.Generic;
using System.Linq;
using Api.Models;
using Api.Repositories;

namespace SampleDotNetCore2RestStub.Integration.Test.Mocks
{
    public class PlayerRepositoryStub : IPlayerRepository
    {
        private Dictionary<int, Player> _persons = new Dictionary<int, Player>();

        public PlayerRepositoryStub()
        {
            _persons.Add(1, new Player { Id = 1, FirstName = "Stubbed FN1", LastName = "Stubbed LN1", Email = "stubbed.email1@email.na" });
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
            var result = "";
            if (_persons.ContainsKey(player.Id))
            {
                result = "Updated Player with id=" + player.Id;
            }
            else
            {
                result = "Added Player with id=" + player.Id;
            }
            _persons.Add(player.Id, player);
            return result;
        }
    }
}