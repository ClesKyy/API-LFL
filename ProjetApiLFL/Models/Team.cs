namespace ProjetApiLFL.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public int Games { get; set; }
        public int Win { get; set; }
        public int Lose { get; set; } 
        public int Position { get; set; }
        public ICollection<Match> MatchesAsRedTeam { get; set; }
        public ICollection<Match> MatchesAsBlueTeam { get; set; }
    }
}
