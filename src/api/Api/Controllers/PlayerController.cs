using System.Collections.Generic;
using Api.Models;
using Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class PlayerController : Controller
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerController(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        [HttpGet("player/get/{id}")]
        public Player GetPerson(int id)
        {
            return _playerRepository.GetById(id);
        }

        [HttpGet("player/remove")]
        public string RemovePerson()
        {
            _playerRepository.Remove();
            return "Last player remove. Total count: " + _playerRepository.GetCount();
        }

        [HttpGet("player/all")]
        public List<Player> GetPersons()
        {
            return _playerRepository.GetAll();
        }

        [HttpPost("player/save")]
        public string AddPerson([FromBody]Player player)
        {
            return _playerRepository.Save(player);
        }
    }
}
