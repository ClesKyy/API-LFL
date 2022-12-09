using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetApiLFL.Models
{
    public class Player
    {
        public int PlayerId { get; set; }
        public int TeamId { get; set; }
        [ForeignKey("TeamId")]
        public string Name { get; set; }
        public string Pseudo { get; set; }
        public string Role { get; set; }
    }
}
