using Microsoft.AspNetCore.Mvc;
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
        [HttpGet]
        public ActionResult<IEnumerable<Team>> GetTeamByOrder()
        {
            return Ok(_teamRepository.GetTeam());
        }
        [HttpGet("order")]
        public ActionResult<IEnumerable<Team>> GetTeam()
        {
            var teams = _teamRepository.GetTeam().OrderBy(t => t.Position);
            return Ok(teams);
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
        [HttpPost("teams")]
        public ActionResult CreateManyTeams(List<CreateTeamDto> teamDtos)
        {
            List<Team> teamsToCreate = new List<Team>();

            foreach(var team in teamDtos)
            {
                teamsToCreate.Add(new Team
                {
                    Name = team.Name,
                    Label = team.Label,
                    Logo = team.Logo
                });
            }
            _teamRepository.CreateManyTeams(teamsToCreate);
            return Ok();
        }
        [HttpPut("{teamId}")]
        public ActionResult UpdateTeam(UpdateTeamDto teamDto, int teamId)
        {
            _teamRepository.UpdateTeam(teamDto, teamId);
            return Ok();

        }
        [HttpDelete("{teamId}")]
        public ActionResult DeleteTeam(int teamId)
        {
            _teamRepository.DeleteTeam(teamId);
            return Ok();
        }
    }
}
