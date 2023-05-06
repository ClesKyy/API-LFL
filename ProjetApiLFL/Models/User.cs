using Microsoft.AspNetCore.Identity;

namespace ProjetApiLFL.Models
{
    public class User : IdentityUser<Guid>
    {
        public int UserId { get; set; }
        public string Pseudo { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int NbBet { get; set; } 
        public int Score { get; set; } 
        public int Games { get; set; }
        public int Win { get; set; }
        public int Lose { get; set; }
        public int Winrate { get; set; } 
    }
}
