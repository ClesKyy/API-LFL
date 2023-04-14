namespace ProjetApiLFL.Dtos.Match
{
    public class MatchListDto
    {
        public DateTime? MatchDate { get; set; }
        public List<MatchDto> Matches { get; set; }
    }
}
