using System.Collections.Generic;
using Api.Models;
using Api.Repositories;
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
        public Player NextRound(string gameKey)
        {
            return _roundRepository.NextRound(gameKey);
        }

        [HttpGet("round/all/{gameKey}")]
        public List<Round> GetRounds(string gameKey)
        {
            return _roundRepository.GetAll(gameKey);
        }

        [HttpPost("round/add")]
        public void AddRound([FromBody]Round round)
        {
            _roundRepository.Add(round);
        }
    }
}
