using mid_assignment_backend.Entities;

namespace mid_assignment_backend.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Roll Roll { get; set; }

    }
}