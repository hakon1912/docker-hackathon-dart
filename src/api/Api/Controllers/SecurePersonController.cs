using System.Collections.Generic;
using Api.Attributes;
using Api.Models;
using Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ServiceFilter(typeof(AuthenticationFilterAttribute))]
    public class SecurePersonController : Controller
    {
        private readonly IPlayerRepository _playerRepository;

        public SecurePersonController(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        [HttpGet("secure/person/all")]
        public List<Player> GetPersons()
        {
            return _playerRepository.GetAll();
        }
    }
}
