using mid_assignment_backend.Entities;

namespace mid_assignment_backend.Repositories
{
    public interface IBookBorrowingRequestDetailsRepository
    {
        Task<BookBorrowingRequestDetails> GetBookBorrowingRequestDetails(int id);
        Task<List<BookBorrowingRequestDetails>> GetAllBookBorrowingRequestDetails();
        Task<BookBorrowingRequestDetails> CreateBookBorrowingRequestDetails(BookBorrowingRequestDetails bookBorrowingRequestDetails);
        Task<BookBorrowingRequestDetails> UpdateBookBorrowingRequestDetails(BookBorrowingRequestDetails bookBorrowingRequestDetails);
    }
}