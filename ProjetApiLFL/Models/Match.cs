using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetApiLFL.Models
{
    public class Match
    {
        public int MatchId { get; set; } 
        public DateTime Date { get; set; }
        public int BlueTeamId { get; set; }
        [ForeignKey("BlueTeamId")]
        public Team BlueTeam { get; set; }
        public int BlueScore { get; set; }
        public int RedTeamId { get; set; }
        [ForeignKey("RedTeamId")]
        public Team RedTeam { get; set; }
        public int RedScore { get; set; }
    }
}
