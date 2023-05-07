using Microsoft.AspNetCore.Mvc;
using ProjetApiLFL.Dtos.Match;
using ProjetApiLFL.Models;
using ProjetApiLFL.Repositories;

namespace ProjetApiLFL.Controllers
{
    [ApiController]
    [Route("match")]
    public class MatchController : Controller
    {
        private readonly IMatchRepository _matchRepository;
        public MatchController(IMatchRepository matchRepository)
        {
            _matchRepository = matchRepository;
        }
        [HttpGet]
        public ActionResult<MatchListDto> GetMatchesList()
        {
            List<Match> matches = _matchRepository.GetMatches();

            List<MatchDto> matchesList = new List<MatchDto>();

            foreach (var match in matches)
            {
                matchesList.Add(new MatchDto
                {
                    RedTeamLogo = match.RedTeam.Logo,
                    RedTeamName = match.RedTeam.Name,
                    RedTeamScore = match.RedScore,
                    BlueTeamLogo = match.BlueTeam.Logo,
                    BlueTeamName = match.BlueTeam.Name,
                    BlueTeamScore = match.BlueScore,
                    MatchDate = match.Date
                });
            }

            var groupedMatches = matchesList
            .OrderByDescending(m => m.MatchDate)
                .GroupBy(m => m.MatchDate.Value.Date)
                .Select(g => new MatchListDto
                {
                    MatchDate = g.Key,
                    Matches = g.ToList()
                })
                .ToList();

            return Ok(groupedMatches);
        }
        [HttpGet("{matchId}")]
        public ActionResult<Match> GetMatchById(int matchId)
        {
            Match match = _matchRepository.GetMatchById(matchId);
            if (match == null)
            {
                return NotFound();
            }
            return Ok(_matchRepository.GetMatchById(matchId));
        }
        [HttpPost]
        public ActionResult CreateMatch(CreateMatchDto MatchDto)
        {
            Match match = new Match
            {
                Date = MatchDto.Date,
                BlueTeamId = MatchDto.BlueTeamId,
                RedTeamId = MatchDto.RedTeamId,

            };
            _matchRepository.CreateMatch(match);
            return Ok();
        }
        [HttpPost("matches")]
        public ActionResult CreateManyMatches(List<CreateMatchDto> MatchDto)
        {
            List<Match> matchesToCreate = new List<Match>();

            foreach (var match in MatchDto)
            {
                matchesToCreate.Add(new Match
                {
                    Date = match.Date,
                    BlueTeamId = match.BlueTeamId,
                    RedTeamId = match.RedTeamId,

                });
            }
            _matchRepository.CreateManyMatches(matchesToCreate);
            return Ok();
        }
        [HttpPut("{matchId}")]
        public ActionResult UpdateMatch(UpdateMatchDto matchDto, int matchId)
        {
            _matchRepository.UpdateMatch(matchDto, matchId);
            return Ok();

        }
        [HttpDelete("{matchId}")]
        public ActionResult DeleteMatch(int matchId)
        {
            _matchRepository.DeleteMatch(matchId);
            return Ok();
        }
        [HttpDelete("all")]
        public ActionResult DeleteAllMatches()
        {
            _matchRepository.DeleteAllMatches();
            return Ok();
        }
    }
}
