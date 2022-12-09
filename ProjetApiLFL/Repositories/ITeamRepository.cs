using ProjetApiLFL.Models;

namespace ProjetApiLFL.Repositories
{
    public interface ITeamRepository
    {
        Result GetTeamById(int id);
        List<Team> GetTeam();
        void CreateTeam(Team team);
        void UpdateTeam(Team newTeam, int oldTeamId);
        void DeleteTeamById(int id);
    }
}
