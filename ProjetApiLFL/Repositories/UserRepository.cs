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

    }
}
