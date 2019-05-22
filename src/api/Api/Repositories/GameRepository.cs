using System;
using System.Collections.Generic;
using System.Text;
using Api.Models;

namespace Api.Repositories
{
    public class GameRepository : IGameRepository
    {
        public Game GetById(int id)
        {
            
            switch(id)
            {
                case 1:
                return new Game(){Date = DateTime.Now , IsComplete = true, Key="firstgame", Name="Game nr. 1" };
                case 2:
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

        public string Add(Game game)
        {
            throw new NotImplementedException();
        }
    }
}
