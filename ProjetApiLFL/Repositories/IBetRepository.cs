using ProjetApiLFL.Models;

namespace ProjetApiLFL.Repositories
{
    public interface IBetRepository
    {
        Bet GetBetById(int id);
        List<Bet> GetBet();
        void CreateBet(Bet bet);
        void UpdateBet(Bet newBet, int oldBetId);
        void DeleteBetById(int id);

    }
}
