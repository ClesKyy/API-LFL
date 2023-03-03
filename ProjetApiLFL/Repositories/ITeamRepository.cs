using ProjetApiLFL.Dtos.Team;
using ProjetApiLFL.Models;

namespace ProjetApiLFL.Repositories
{
    public interface ITeamRepository
    {
        Team GetTeamById(int id);
        List<Team> GetTeam();
        void CreateTeam(Team team);
        void UpdateTeam(UpdateTeamDto newTeam, int oldTeamId);
        void DeleteTeam(int id);
    }
}
