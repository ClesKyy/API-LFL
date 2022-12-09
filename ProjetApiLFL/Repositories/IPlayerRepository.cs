using ProjetApiLFL.Models;

namespace ProjetApiLFL.Repositories
{
    public interface IPlayerRepository
    {
        Player GetPlayerById(int id);
        List<Player> GetPlayer();
        void CreatePlayer(Player player);
        void UpdatePlayer(Player newPlayer, int oldPlayerId);
        void DeletePlayerById(int id);
    }
}
