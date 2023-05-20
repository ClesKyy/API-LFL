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
        public Team GetTeamByName(string name)
        {
            return _context.Teams.Where(t => t.Name == name).FirstOrDefault();
        }
        public List<Player> GetAllByTeamName(string name)
        {
            var team = GetTeamByName(name);
            return _context.Players.ToList();
        }
        public void CreateTeam(Team team)
        {
            _context.Teams.Add(team);
            _context.SaveChanges();
        }

        public void CreateManyTeams(List<Team> teams)
        {
            _context.Teams.AddRange(teams);
            _context.SaveChanges();
        }

        public List<Team> GetTeam()
        {
            return _context.Teams.ToList();
        }
         public void UpdateTeam(UpdateTeamDto newTeam, int oldTeamId)
        {
            Team team = GetTeamById(oldTeamId);
            team.Games = newTeam.Games;
            team.Win = newTeam.Win;
            team.Lose = newTeam.Lose;
            team.Position = newTeam.Position;

            _context.Teams.Update(team);
            _context.SaveChanges();
        }
        public void DeleteTeam(int teamId)
        {
            Team team = GetTeamById(teamId);
            _context.Teams.Remove(team);
            _context.SaveChanges();
        }
        public void DeleteAllTeams()
        {
            var teams = _context.Teams.ToList();
            _context.Teams.RemoveRange(teams);
            _context.SaveChanges();
        }
    } 
}
