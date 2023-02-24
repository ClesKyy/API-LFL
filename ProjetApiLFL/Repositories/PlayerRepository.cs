using ProjetApiLFL.DbContexts;
using ProjetApiLFL.Dtos.Match;
using ProjetApiLFL.Dtos.Player;
using ProjetApiLFL.Models;

namespace ProjetApiLFL.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly LFLDbContext _context;
        public PlayerRepository(LFLDbContext context)
        {
            _context = context;
        }
        public Player GetPlayerById(int id)
        {
            return _context.Players.Where(t => t.PlayerId == id).FirstOrDefault();
        }
        public void CreatePlayer(Player player)
        {
            _context.Players.Add(player);
            _context.SaveChanges();
        }
        public List<Player> GetPlayer()
        {
            return _context.Players.ToList();
        }
        public void UpdatePlayer(UpdatePlayerDto newPlayer, int oldPlayerId)
        {
            Player player = GetPlayerById(oldPlayerId);
            player.Name = newPlayer.Name;
            player.Pseudo = newPlayer.Pseudo;
            player.Role = newPlayer.Role; 

            _context.Players.Update(player);
            _context.SaveChanges();
        }
        public void DeletePlayer(int playerId)
        {
            Player player = GetPlayerById(playerId);
            _context.Players.Remove(player);
            _context.SaveChanges();
        }
    }
}
