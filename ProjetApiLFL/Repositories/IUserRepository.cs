using ProjetApiLFL.Dtos.User;
using ProjetApiLFL.Models;

namespace ProjetApiLFL.Repositories
{
    public interface IUserRepository
    {
        List<User> GetUsers();
        User GetUserByName(string name);
        void DeleteUser(string name);
        void UpdatePassword(UpdatePasswordDto newUser, string name);
    }
}
