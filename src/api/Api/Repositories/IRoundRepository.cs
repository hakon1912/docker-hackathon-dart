using System.Collections.Generic;
using Api.Models;

namespace Api.Repositories
{
    public interface IRoundRepository
    {
      
        List<Round> GetAll(string gameKey);
        Round GetLastRound(string gameKey);
        Player NextRound(int gameId);
        void Add(Round round);
    }
}