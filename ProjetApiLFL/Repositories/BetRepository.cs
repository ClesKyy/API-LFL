using ProjetApiLFL.DbContexts;
using ProjetApiLFL.Dtos.Bet;
using ProjetApiLFL.Models;

namespace ProjetApiLFL.Repositories
{
    public class BetRepository
    {
        private readonly LFLDbContext _context;
        public BetRepository(LFLDbContext context)
        {
            _context = context;
        }
        public Bet GetBetById(int id)
        {
            return _context.Bets.Where(t => t.BetId == id).FirstOrDefault();
        }
        public void CreateBet(Bet bet)
        {
            _context.Bets.Add(bet);
            _context.SaveChanges();
        }
        public List<Bet> GetBet()
        {
            return _context.Bets.ToList();
        }
        public void UpdateBet(UpdateBetDto newBet, int oldBetId)
        {
            Bet bet = GetBetById(oldBetId);
            bet.TeamBet = newBet.TeamBet;
            bet.Quantity = newBet.Quantity;

            _context.Bets.Update(bet);
            _context.SaveChanges();
        }
        public void DeleteBet(int betId)
        {
            Bet bet = GetBetById(betId);
            _context.Bets.Remove(bet);
            _context.SaveChanges();
        }
    }
}
