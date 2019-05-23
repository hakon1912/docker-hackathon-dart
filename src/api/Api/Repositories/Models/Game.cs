using System;
using System.Collections.Generic;

namespace Api.Repositories.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int StartingScore { get; set; }
        public bool IsComplete { get; set; }

        public List<Player> Players { get; set; }
        public List<Round> Rounds { get; set; }
    }
}