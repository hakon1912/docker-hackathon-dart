using System.Collections.Generic;
using Api.Repositories.Interfaces;
using Api.Repositories.Models;

namespace Api.Repositories
{
    public class PlayerRepositoryMock : IPlayerRepository
    {
        public string Add(Player player)
        {
            throw new System.NotImplementedException();
        }

        public List<Player> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}