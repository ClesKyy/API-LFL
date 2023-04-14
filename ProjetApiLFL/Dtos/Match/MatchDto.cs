namespace ProjetApiLFL.Dtos.Match
{
    public class MatchDto
    {
        public DateTime? MatchDate { get; set; }
        public string? BlueTeamLogo { get; set; }
        public string? BlueTeamName { get; set; }
        public string? RedTeamLogo { get; set; }
        public string? RedTeamName { get; set; }
        public int RedTeamScore { get; set; }
        public int BlueTeamScore { get; set; }
    }
}
