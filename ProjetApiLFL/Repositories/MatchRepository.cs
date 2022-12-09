using Microsoft.EntityFrameworkCore;
using ProjetApiLFL.DbContexts;
using ProjetApiLFL.Dtos.Bet;
using ProjetApiLFL.Dtos.Match;
using ProjetApiLFL.Models;

namespace ProjetApiLFL.Repositories
{
    public class MatchRepository
    {
        private readonly LFLDbContext _context;
        public MatchRepository(LFLDbContext context)
        {
            _context = context;
        }
        public Match GetMatchById(int id)
        {
            return _context.Matchs.Where(t => t.MatchId == id).FirstOrDefault();
        }
        public void CreateMatch(Match match)
        {
            _context.Matchs.Add(match);
            _context.SaveChanges();
        }
        public List<Match> GetMatches()
        {
            return _context.Matchs.ToList();
        }
        public void UpdateMatch(UpdateMatchDto newMatch, int oldMatchId)
        {
            Match match = GetMatchById(oldMatchId);
            match.Date = newMatch.Date;

            _context.Matchs.Update(match);
            _context.SaveChanges();
        }
        public void DeleteMatch(int matchId)
        {
            Match match = GetMatchById(matchId);
            _context.Matchs.Remove(match);
            _context.SaveChanges();
        }
    }
    
    
}
