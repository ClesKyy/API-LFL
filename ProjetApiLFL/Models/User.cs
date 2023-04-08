﻿using Microsoft.AspNetCore.Identity;

namespace ProjetApiLFL.Models
{
    public class User : IdentityUser<Guid>
    {
        public string Pseudo { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int NbBet { get; set; } 
        public int Score { get; set; } 
    }
}
