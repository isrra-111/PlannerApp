
using System.ComponentModel.DataAnnotations;

namespace PlannerApp.Shared.Models
{
    public class LoginRequest
    {
        [EmailAddress]
        public string Email {  get; set; }
        [Required]
        [StringLength(20),MinLength(6)]
        public string Password { get; set; }
    }
}
