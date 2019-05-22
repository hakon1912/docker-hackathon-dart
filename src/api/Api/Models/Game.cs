using System;

namespace Api.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int StartingScore { get; set; }
        public bool IsComplete { get; set; }
    }
}