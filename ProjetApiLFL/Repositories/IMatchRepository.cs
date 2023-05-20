using ProjetApiLFL.Dtos.Match;
using ProjetApiLFL.Models;

namespace ProjetApiLFL.Repositories
{
    public interface IMatchRepository
    {
        Match GetMatchById(int id);
        List<Match> GetMatches();
        void CreateMatch(Match match);
        void CreateManyMatches(List<Match> matches);
        void UpdateMatch(UpdateMatchDto newMatch, int oldMatchId);
        void DeleteMatch(int id);
        void DeleteAllMatches();
    }
}
