using Microsoft.AspNetCore.Identity;

namespace ProjetApiLFL.Models
{
    public class User : IdentityUser<Guid>
    {
        public int User_id { get; set; } 
        public string Pseudo { get; set; }
        public int NbBet { get; set; } 
        public int Score { get; set; } 
        public string Role { get; set; } 

    }
}
