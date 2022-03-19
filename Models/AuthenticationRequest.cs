using System.ComponentModel.DataAnnotations;

namespace mid_assignment_backend.Models
{
    public class AuthenticationRequest
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}