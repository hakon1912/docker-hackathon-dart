﻿using System;
using System.Collections.Generic;
using Api.Models;
using Api.Repositories.Interfaces;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Api.Repositories.Mock
{
    public class GameRepositoryMock : IGameRepository
    {
        public Game GetByKey(string key)
        {
            
            switch(key)
            {
                case "1":
                return new Game(){Date = DateTime.Now , IsComplete = true, Key="firstgame", Name="Game nr. 1" };
                case "2":
                return  new Game(){Date = DateTime.Now.AddDays(-2) , IsComplete = true, Key="second", Name="Game nr. 2" , Id=2 , StartingScore =301};
                default:
                return null;
            }
        }

        public List<Game> GetAll()
        {
            return new List<Game>(){
                new Game(){Date = DateTime.Now , IsComplete = true, Key="firstgame", Name="Game nr. 1" },
                 new Game(){Date = DateTime.Now.AddDays(-1) , IsComplete = true, Key="firstgame", Name="Game nr. 1", Id=1 , StartingScore =501},
                  new Game(){Date = DateTime.Now.AddDays(-2) , IsComplete = true, Key="second", Name="Game nr. 2" , Id=2 , StartingScore =301},
                   new Game(){Date = DateTime.Now.AddDays(-3) , IsComplete = true, Key="third", Name="Game nr. 3" , Id=3 , StartingScore =501},
                    new Game(){Date = DateTime.Now.AddDays(-4), IsComplete = true, Key="Lastone", Name="Game nr. 1000", Id=4 , StartingScore =201 },
                };
        }

        public List<Game> GetHistoric()
        {
            return new List<Game>(){
                new Game(){Date = DateTime.Now , IsComplete = true, Key="firstgame", Name="Game nr. 1" },
                new Game(){Date = DateTime.Now.AddDays(-1) , IsComplete = true, Key="firstgame", Name="Game nr. 1", Id=1 , StartingScore =501},
                new Game(){Date = DateTime.Now.AddDays(-2) , IsComplete = true, Key="second", Name="Game nr. 2" , Id=2 , StartingScore =301},
                new Game(){Date = DateTime.Now.AddDays(-3) , IsComplete = true, Key="third", Name="Game nr. 3" , Id=3 , StartingScore =501},
                new Game(){Date = DateTime.Now.AddDays(-4), IsComplete = true, Key="Lastone", Name="Game nr. 1000", Id=4 , StartingScore =201 },
            };
        }

        public int Add(Game game)
        {
            return 1;
        }
    }
}
