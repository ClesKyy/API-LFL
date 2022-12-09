using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetApiLFL.Models
{
    public class Bet
    {
        public int BetId { get; set; }
        public int MatchId { get; set; }
        [ForeignKey("MatchId")]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public int TeamId { get; set; }
        [ForeignKey("TeamId")]
        public string TeamBet { get; set; }
        public int Quantity { get; set; } 
    }
}
