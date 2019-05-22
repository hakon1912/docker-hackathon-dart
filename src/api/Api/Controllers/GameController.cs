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

        [HttpGet("game/get/{id}")]
        public Game GetGame(int id)
        {
            return _gameRepository.GetById(id);
        }

        [HttpGet("game/remove")]
        public string RemoveGame()
        {
            _gameRepository.Remove();
            return "Last player remove. Total count: " + _gameRepository.GetCount();
        }

        [HttpGet("game/all")]
        public List<Game> GetGames()
        {
            return _gameRepository.GetAll();
        }

        [HttpPost("game/save")]
        public string AddPerson([FromBody]Game game)
        {
            return _gameRepository.Save(game);
        }
    }
}
