using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace mid_assignment_backend.Entities
{
    public class BookBorrowingRequest : BaseEntity
    {
        [Required]
        public int RequestByUserId { get; set; }
        public virtual User? RequestByUser { get; set; }
        [Required, MaxLength(50)]
        public DateTime Date { get; set; }
        [Required, DefaultValue(RequestStatus.Waiting)]
        public RequestStatus Status { get; set; }
        [Required]
        public int ProcessedByUserId { get; set; };
        public virtual User? ProcessedByUser { get; set; }
        [JsonIgnore]
        public ICollection<BookBorrowingRequestDetails>? Details { get; set; }
    }
}