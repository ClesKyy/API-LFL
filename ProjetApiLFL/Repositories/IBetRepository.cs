using ProjetApiLFL.Dtos.Bet;
using ProjetApiLFL.Models;

namespace ProjetApiLFL.Repositories
{
    public interface IBetRepository
    {
        Bet GetBetById(int id);
        List<Bet> GetBet();
        void CreateBet(Bet bet);
        void UpdateBet(UpdateBetDto newBet, int oldBetId);
        void DeleteBet(int id);

    }
}
