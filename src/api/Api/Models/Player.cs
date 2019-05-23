namespace Api.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GameId { get; set; }
        public int TurnOrder { get; set; }

        public int CurrentScore {get;set;}
        public int RoundNumber {get;set;}
    }
}