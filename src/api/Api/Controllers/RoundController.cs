using System.Collections.Generic;
using Api.Models;
using Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class RoundController : Controller
    {
        private readonly IRoundRepository _roundRepository;

        public RoundController(IRoundRepository playerRepository)
        {
            _roundRepository = playerRepository;
        }

         [HttpGet("round/next/{gameKey}")]
        public Player NextRound(int gameId)
        {
            return _roundRepository.NextRound(gameId);
        }

        [HttpGet("round/all/{gameKey}")]
        public List<Round> GetRounds(int gameKey)
        {
            return _roundRepository.GetAll(gameKey);
        }

        [HttpPost("round/add")]
        public Player AddRound([FromBody]Round round)
        {
            _roundRepository.Add(round);
            return _roundRepository.NextRound(round.GameId);
        }
    }
}
