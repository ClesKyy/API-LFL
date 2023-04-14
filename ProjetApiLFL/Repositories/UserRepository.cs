using ProjetApiLFL.DbContexts;
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
        public void DeleteUser(string pseudo)
        {
            User user = GetUserByName(pseudo);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}
