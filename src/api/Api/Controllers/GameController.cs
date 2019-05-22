using System.Collections.Generic;
using Api.Models;
using Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameRepository _gameRepository;

        public GameController(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
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
        public string AddGame([FromBody]Game game)
        {
            return _gameRepository.Add(game);
        }
    }
}
