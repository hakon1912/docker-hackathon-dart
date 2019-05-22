namespace Api.Models
{
    public class Round
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int PlayerId { get; set; }
        public int Score { get; set; }
        public int DartsUsed { get; set; }
    }
}