namespace ProjetApiLFL.Dtos.Bet
{
    public class CreateBetDto
    {
        public int MatchId { get; set; }
        public int UserId { get; set; }
        public int TeamId { get; set; }
        public string TeamBet { get; set; }
        public int Quantity { get; set; }
        
    }
}
