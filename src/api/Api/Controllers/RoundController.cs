using System.Collections.Generic;
using Api.Models;
using Api.Repositories;
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
        public List<Round> GetRounds()
        {
            return _roundRepository.GetAll();
        }

        [HttpPost("round/add")]
        public string AddRound([FromBody]Round round)
        {
            return _roundRepository.Add(round);
        }
    }
}
