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
    }
}
