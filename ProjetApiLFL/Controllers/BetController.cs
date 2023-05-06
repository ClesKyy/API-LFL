using Microsoft.AspNetCore.Mvc;
using ProjetApiLFL.Dtos.Bet;
using ProjetApiLFL.Dtos.Player;
using ProjetApiLFL.Models;
using ProjetApiLFL.Repositories;

namespace ProjetApiLFL.Controllers
{
    [ApiController]
    [Route("bet")]
    public class BetController : Controller
    {
        private readonly IBetRepository _betRepository;

        public BetController(IBetRepository betRepository)
        {
            _betRepository = betRepository;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Bet>> GetBet()
        {
            return Ok(_betRepository.GetBet());
        }
        [HttpPost]
        public ActionResult CreateBet(CreateBetDto betDto)
        {
            Bet bet = new Bet
            {
                MatchId = betDto.MatchId,
                UserId = betDto.UserId,
                TeamId = betDto.TeamId,
                TeamBet = betDto.TeamBet,
                Quantity = betDto.Quantity,
            };

            _betRepository.CreateBet(bet);
            return Ok();
        }
    }
}
