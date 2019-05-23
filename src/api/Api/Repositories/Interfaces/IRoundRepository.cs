using System.Collections.Generic;
using Api.Models;

namespace Api.Repositories.Interfaces
{
    public interface IRoundRepository
    {
      
        List<Round> GetAll(int gameId);
        Round GetLastRound(int gameId);
        Player NextRound(int gameId);
        void Add(Round round);
    }
}