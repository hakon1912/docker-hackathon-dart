using System.Collections.Generic;
using Api.Models;
using Api.Repositories;
using Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameRepository _gameRepository;
        private readonly IRoundRepository _roundRepository;

        public GameController(IGameRepository gameRepository,IRoundRepository roundRepository)
        {
            _gameRepository = gameRepository;
            _roundRepository = roundRepository;
        }

        [HttpGet("game/get/{key}")]
        public Game GetGame(string key)
        {
            return _gameRepository.GetByKey(key);
        }

        [HttpGet("game/all")]
        public List<Game> GetGames()
        {
            return _gameRepository.GetAll();
        }

        [HttpPost("game/add")]
        public Player AddGame([FromBody]Game game)
        {
            var gamekey = _gameRepository.Add(game);
            return _roundRepository.NextRound(gamekey);
        }
    }
}
