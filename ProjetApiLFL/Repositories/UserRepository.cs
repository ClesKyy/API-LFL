using Microsoft.AspNetCore.Identity;
using ProjetApiLFL.DbContexts;
using ProjetApiLFL.Dtos.User;
using ProjetApiLFL.Models;

namespace ProjetApiLFL.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly LFLDbContext _context;
        private readonly UserManager<User> _userManager;
        public UserRepository(LFLDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }
        public User GetUserByName(string name)
        {
            return _context.Users.Where(t => t.Name == name).FirstOrDefault();
        }
        public void UpdatePassword(UpdatePasswordDto userDto, string userName)
        {
            var user = _context.Users.SingleOrDefault(u => u.Name == userName);

            if (user != null)
            {
                var passwordValidator = new PasswordValidator<User>();
                var result = passwordValidator.ValidateAsync(_userManager, user, userDto.NewPassword).Result;

                if (!result.Succeeded)
                {
                    throw new Exception("Nouveau mot de passe invalide.");
                }

                var token = _userManager.GeneratePasswordResetTokenAsync(user).Result;
                var resetResult = _userManager.ResetPasswordAsync(user, token, userDto.NewPassword).Result;

                if (!resetResult.Succeeded)
                {
                    throw new Exception("La mise à jour du mot de passe a échoué.");
                }
            }
            else
            {
                throw new Exception("Utilisateur introuvable.");
            }
        }
        public void DeleteUser(string name)
        {
            User user = GetUserByName(name);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}
