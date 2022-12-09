using ProjetApiLFL.Models;

namespace ProjetApiLFL.Repositories
{
    public interface IMatchRepository
    {
        Match GetMatchById(int id);
        List<Match> GetMatch();
        void CreateMatch(Match match);
        void UpdateMatch(Match newMatch, int oldMatchId);
        void DeleteMatchById(int id);
    }
}
