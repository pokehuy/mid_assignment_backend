using mid_assignment_backend.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mid_assignment_backend.Models
{
    public class BookBorrowingRequestModel
    {
        public int? Id { get; set; }
        public int RequestByUserId { get; set; }
        public DateTime Date { get; set; }
        public RequestStatus Status { get; set; }
        public int ProcessedByUserId { get; set; }
        public List<BookBorrowingRequestDetailsModel> listDetails { get; set; }
    }
}