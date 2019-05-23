using System.Collections.Generic;
using Api.Models;

namespace Api.Repositories.Interfaces
{
    public interface IRoundRepository
    {
      
        List<Round> GetAll(string gameKey);
        Round GetLastRound(string gameKey);
        Player NextRound(string gameKey);
        void Add(Round round);
    }
}