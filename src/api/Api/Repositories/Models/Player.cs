using System.Collections.Generic;

namespace Api.Repositories.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GameId { get; set; }
        public int TurnOrder { get; set; }

        public Game Game { get; set; }
        public List<Round> Rounds { get; set; }
    }
}