using ProjetApiLFL.Dtos.Match;
using ProjetApiLFL.Models;

namespace ProjetApiLFL.Repositories
{
    public interface IMatchRepository
    {
        //Match GetMatchById(int id);
        List<Match> GetMatches();
        void CreateMatch(Match match);
        //void UpdateMatch(UpdateMatchDto newMatch, int oldMatchId);
        //void DeleteMatchById(int id);
    }
}
