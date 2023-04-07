namespace ProjetApiLFL.Dtos.Player
{
    public class CreatePlayerDto
    {
        public int TeamId { get; set; }
        public string Pseudo { get; set; }
        public string Role { get; set; }
        public string ProfileImg { get; set; }
        public string RoleIcon { get; set; }
    }
}
