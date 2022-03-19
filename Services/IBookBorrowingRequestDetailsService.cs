using mid_assignment_backend.Entities;

namespace mid_assignment_backend.Services
{
    public interface IBookBorrowingRequestDetailsService
    {
        Task<BookBorrowingRequestDetails> GetBookBorrowingRequestDetails(int id);
        Task<List<BookBorrowingRequestDetails>> GetAllBookBorrowingRequestDetails();
        Task<BookBorrowingRequestDetails> CreateBookBorrowingRequestDetails(BookBorrowingRequestDetails bookBorrowingRequestDetails);
        Task<BookBorrowingRequestDetails> UpdateBookBorrowingRequestDetails(BookBorrowingRequestDetails bookBorrowingRequestDetails);
    }
}