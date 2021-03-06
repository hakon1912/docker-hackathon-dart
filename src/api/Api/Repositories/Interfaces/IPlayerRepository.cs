﻿using System.Collections.Generic;
using Api.Repositories.Models;

namespace Api.Repositories.Interfaces
{
    public interface IPlayerRepository
    {
        List<Player> GetAll();
        string Add(Player player);
    }
}