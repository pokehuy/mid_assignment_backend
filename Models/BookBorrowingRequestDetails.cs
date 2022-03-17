using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mid_assignment_backend.Models
{
    public class BookBorrowingRequestDetailsModel
    {
        public int RequestId { get; set; }
        public List<string> BookIds { get; set; }
    }
}