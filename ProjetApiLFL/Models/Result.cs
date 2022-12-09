using Microsoft.AspNetCore.Components.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetApiLFL.Models
{
    public class Result
    {
        public int ResultId { get; set; } 
        public int MatchId { get; set; }
        [ForeignKey("MatchId")]
        public int TeamId { get; set; }
        [ForeignKey("TeamId")]
        public int Score { get; set; } 
        public bool Winner { get; set; } 
    }
}
