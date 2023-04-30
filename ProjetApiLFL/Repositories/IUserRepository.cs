using ProjetApiLFL.Dtos.User;
using ProjetApiLFL.Models;

namespace ProjetApiLFL.Repositories
{
    public interface IUserRepository
    {
        List<User> GetUsers();
        User GetUserByName(string pseudo);
        void DeleteUser(string pseudo);
        void UpdatePassword(UpdatePasswordDto newUser, string pseudo);
    }
}
