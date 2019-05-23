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

         [HttpGet("round/next")]
        public Player NextRound([FromBody]int gameid)
        {
            return _roundRepository.NextRound(gameid);
        }

        [HttpGet("round/all")]
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
