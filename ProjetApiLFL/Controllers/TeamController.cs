using Microsoft.AspNetCore.Mvc;
using ProjetApiLFL.Dtos.Player;
using ProjetApiLFL.Dtos.Team;
using ProjetApiLFL.Models;
using ProjetApiLFL.Repositories;

namespace ProjetApiLFL.Controllers
{
    [ApiController]
    [Route("team")]
    public class TeamController : Controller
    {
        private readonly ITeamRepository _teamRepository;
        public TeamController(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }
        [HttpPost]
        public ActionResult CreateTeam(CreateTeamDto teamDto)
        {
            Team team = new Team
            {
                Name = teamDto.Name,
                Logo = teamDto.Logo,

            };

            _teamRepository.CreateTeam(team);
            return Ok();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Team>> GetTeam()
        {
            return Ok(_teamRepository.GetTeam());
        }
        [HttpGet("{teamName}")]
        public ActionResult<Team> GetTeamByName(string teamName)
        {
            Team team = _teamRepository.GetTeamByName(teamName);
            if (team == null)
            {
                return NotFound();
            }
            return Ok(_teamRepository.GetTeamByName(teamName));
        }
        [HttpGet("{teamName}/player")]

        public ActionResult<IEnumerable<Player>> GetAllByTeamName(string teamName)
        {
            var team = _teamRepository.GetTeamByName(teamName);
            if (team == null)
            {
                return NotFound();
            }
            var players = _teamRepository.GetAllByTeamName(teamName)
            .Where(p => p.TeamId == team.TeamId);
            return Ok(players);
        }
        [HttpPut]
        public ActionResult UpdateTeam(UpdateTeamDto teamDto, int teamId)
        {
            _teamRepository.UpdateTeam(teamDto, teamId);
            return Ok();

        }
    }
}
