using System.Text.Json.Serialization;

namespace mid_assignment_backend.Models
{
    public class ResponseUser
    {
        //public int? Id { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        //[JsonIgnore]
        public string? Token { get; set; }
        public string Message { get; set; }
    }
}