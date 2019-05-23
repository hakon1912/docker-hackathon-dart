namespace Api.Repositories.Models
{
    public class Round
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int PlayerId { get; set; }
        public int Score { get; set; }
        public int DartsUsed { get; set; }

        public Game Game { get; set; }
        public Player Player { get; set; }
    }
}