using ProjetApiLFL.Models;

namespace ProjetApiLFL.Repositories
{
    public interface IUserRepository
    {
        List<User> GetUsers();
        User GetUserByName(string pseudo);
        void DeleteUser(string pseudo);
    }
}
