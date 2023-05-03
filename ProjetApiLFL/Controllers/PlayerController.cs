using Microsoft.AspNetCore.Mvc;
using ProjetApiLFL.Dtos.Player;
using ProjetApiLFL.Dtos.Team;
using ProjetApiLFL.Models;
using ProjetApiLFL.Repositories;

namespace ProjetApiLFL.Controllers
{
    [ApiController]
    [Route("player")]
    public class PlayerController : Controller
    {
        private readonly IPlayerRepository _playerRepository; 

        public PlayerController(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Player>> GetPlayer()
        {
            return Ok(_playerRepository.GetPlayer());
        }
        [HttpGet("{playerId}")]
        public ActionResult<Player> GetPlayerById(int playerId)
        {
            Player player = _playerRepository.GetPlayerById(playerId);
            if (player == null)
            {
                return NotFound();
            }
            return Ok(_playerRepository.GetPlayerById(playerId));
        }
        [HttpPost]
          public ActionResult CreatePlayer(CreatePlayerDto playerDto)
          {
              Player player = new Player
              {
                  TeamId = playerDto.TeamId,
                  Pseudo = playerDto.Pseudo,
                  Role = playerDto.Role,
                  ProfileImg = playerDto.ProfileImg,
                  RoleIcon = playerDto.RoleIcon,
              };

              _playerRepository.CreatePlayer(player);
              return Ok();
          }
        [HttpPost("players")]
        public ActionResult CreateManyPlayers(List<CreatePlayerDto> playerDtos)
        {
            List<Player> playersToCreate = new List<Player>();

            foreach (var player in playerDtos)
            {
                playersToCreate.Add(new Player
                {
                    TeamId = player.TeamId,
                    Pseudo = player.Pseudo,
                    Role = player.Role,
                    ProfileImg = player.ProfileImg,
                    RoleIcon = player.RoleIcon,
                });
            }
            _playerRepository.CreateManyPlayers(playersToCreate);
            return Ok();
        }
        [HttpPut("{playerId}")]
        public ActionResult UpdatePlayer(UpdatePlayerDto playerDto, int playerId)
        {
            _playerRepository.UpdatePlayer(playerDto, playerId);
            return Ok();

        }
        [HttpDelete("{playerId}")]
        public ActionResult DeletePlayer(int playerId)
        {
            _playerRepository.DeletePlayer(playerId);
            return Ok();
        }

    }
}
