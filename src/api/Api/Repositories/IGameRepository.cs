using System.Collections.Generic;
using Api.Models;

namespace Api.Repositories
{
    public interface IGameRepository
    {
        Game GetById(int id);
        List<Game> GetAll();
        int GetCount();
        void Remove();
        string Save(Game player);
    }
}