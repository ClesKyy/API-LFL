using ProjetApiLFL.DbContexts;
using ProjetApiLFL.Dtos.Bet;
using ProjetApiLFL.Dtos.Team;
using ProjetApiLFL.Models;

namespace ProjetApiLFL.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly LFLDbContext _context;
        public TeamRepository(LFLDbContext context)
        {
            _context = context;
        }
         public Team GetTeamById(int id)
        {
            return _context.Teams.Where(t => t.TeamId == id).FirstOrDefault();
        } 
        public void CreateTeam(Team team)
        {
            _context.Teams.Add(team);
            _context.SaveChanges();
        } 
        public List<Team> GetTeam()
        {
            return _context.Teams.ToList();
        }
         public void UpdateTeam(UpdateTeamDto newTeam, int oldTeamId)
        {
            Team team = GetTeamById(oldTeamId);
            team.Win = newTeam.Win;
            team.Lose = newTeam.Lose;

            _context.Teams.Update(team);
            _context.SaveChanges();
        }
        public void DeleteTeam(int teamId)
        {
            Team team = GetTeamById(teamId);
            _context.Teams.Remove(team);
            _context.SaveChanges();
        } 
    } 
}
