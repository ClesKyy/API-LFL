﻿namespace ProjetApiLFL.Dtos.User
{
    public class UpdatePasswordDto
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
    }
}
