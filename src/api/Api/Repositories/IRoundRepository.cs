using System.Collections.Generic;
using Api.Models;

namespace Api.Repositories
{
    public interface IRoundRepository
    {
      
        List<Round> GetAll();
        string Add(Round round);
    }
}