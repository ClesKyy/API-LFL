using ProjetApiLFL.Dtos.Team;
using ProjetApiLFL.Models;

namespace ProjetApiLFL.Repositories
{
    public interface ITeamRepository
    {
        Team GetTeamById(int id);
        Team GetTeamByName(string name);
        List<Player> GetAllByTeamName (string name);
        List<Team> GetTeam();
        void CreateTeam(Team team);
        void UpdateTeam(UpdateTeamDto newTeam, int oldTeamId);
        void DeleteTeam(int id);
    }
}
