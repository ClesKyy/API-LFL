using Microsoft.AspNetCore.Mvc;
using ProjetApiLFL.Dtos.Player;
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
        [HttpPost]
        public ActionResult CreatePlayer(CreatePlayerDto playerDto)
        {
            Player player = new Player
            {
                Name = playerDto.Name,
                Pseudo = playerDto.Pseudo,
                Role = playerDto.Role,
            };

            _playerRepository.CreatePlayer(player);
            return Ok();
        }
        [HttpGet("{playerId}")]

        public ActionResult<Player> GetPlayerById(int playerId)
        {
            Player player = _playerRepository.GetPlayerById(playerId);
            if(player == null)
            {
                return NotFound();
            }
            return Ok(_playerRepository.GetPlayerById(playerId));
        }
        [HttpGet]
        public ActionResult<IEnumerable<Player>> GetPlayer()
        {
            return Ok(_playerRepository.GetPlayer());
        }
        [HttpPut]
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
