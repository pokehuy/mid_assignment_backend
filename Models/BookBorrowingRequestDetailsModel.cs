using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mid_assignment_backend.Models
{
    public class BookBorrowingRequestDetailsModel
    {
        //public int? Id { get; set; }
        public int BookBorrowingRequestId { get; set; }
        public int BookId { get; set; }
    }
}