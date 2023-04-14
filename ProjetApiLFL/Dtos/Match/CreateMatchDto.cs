namespace ProjetApiLFL.Dtos.Match
{
    public class CreateMatchDto
    {
        public DateTime Date { get; set; }
        public int BlueTeamId { get; set; }
        public int RedTeamId { get; set; }
    }
}
