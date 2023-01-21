using ProjetApiLFL.Dtos.Player;
using ProjetApiLFL.Models;

namespace ProjetApiLFL.Repositories
{
    public interface IPlayerRepository
    {
        Player GetPlayerById(int id);
        List<Player> GetPlayer();
        void CreatePlayer(Player player);
        void UpdatePlayer(UpdatePlayerDto newPlayer, int oldPlayerId);
        void DeletePlayer(int id);
    }
}
