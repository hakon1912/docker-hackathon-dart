using System.Collections.Generic;
using Api.Models;

namespace Api.Repositories
{
    public interface IPlayerRepository
    {
        Player GetById(int id);
        List<Player> GetAll();
        int GetCount();
        void Remove();
        string Save(Player player);
    }
}