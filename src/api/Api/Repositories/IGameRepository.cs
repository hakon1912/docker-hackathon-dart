using System.Collections.Generic;
using Api.Models;

namespace Api.Repositories
{
    public interface IGameRepository
    {
        Game GetByKey(string key);
        List<Game> GetAll();
        List<Game> GetHistoric();
        string Add(Game game);
    }
}