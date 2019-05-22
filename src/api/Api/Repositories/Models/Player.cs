namespace Api.Repositories.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GameId { get; set; }
        public int TurnOrder { get; set; }
    }
}