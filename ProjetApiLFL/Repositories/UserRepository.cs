using ProjetApiLFL.DbContexts;
using ProjetApiLFL.Dtos.User;
using ProjetApiLFL.Models;

namespace ProjetApiLFL.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly LFLDbContext _context;
        public UserRepository(LFLDbContext context)
        {
            _context = context;
        }
        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }
        public User GetUserByName(string pseudo)
        {
            return _context.Users.Where(t => t.Pseudo == pseudo).FirstOrDefault();
        }
        public void UpdatePassword(UpdatePasswordDto newUser, string pseudo)
        {
            User user = GetUserByName(pseudo);
            user.Password = newUser.Password;
            _context.Users.Update(user);
            _context.SaveChanges();
        }
        public void DeleteUser(string pseudo)
        {
            User user = GetUserByName(pseudo);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}
