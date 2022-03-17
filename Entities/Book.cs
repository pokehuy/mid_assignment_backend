using System.ComponentModel.DataAnnotations;

namespace mid_assignment_backend.Entities
{
    public class Book : BaseEntity
    {
        public string? Title { get; set; }
        public string? Author { get; set; }
        [Required]
        public int CategoryId { get; set; }

        public virtual Category? Category { get; set; }
        public ICollection<BookBorrowingRequestDetails>? Details { get; set; }

    }
}