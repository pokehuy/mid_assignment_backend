using System.ComponentModel.DataAnnotations;

namespace mid_assignment_backend.Entities
{
    public class User : BaseEntity
    {
        [Required, MaxLength(50)]
        public string Username { get; set; }
        [Required, MaxLength(50)]
        public string Password { get; set; }
        [Required]
        public Roll Roll { get; set; }

        public ICollection<BookBorrowingRequest>? BookBorrowingRequests { get; set; }

        public ICollection<BookBorrowingRequest>? ProcessedRequests { get; set; }
    }
}