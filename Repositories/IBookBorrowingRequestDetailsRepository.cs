using mid_assignment_backend.Entities;

namespace mid_assignment_backend.Repositories
{
    public interface IBookBorrowingRequestDetailsRepository
    {
        Task<BookBorrowingRequestDetails> GetBookBorrowingRequestDetailsById(int requestId,int bookId);
        Task<List<BookBorrowingRequestDetails>> GetAllBookBorrowingRequestDetails();
        Task<BookBorrowingRequestDetails> CreateBookBorrowingRequestDetails(BookBorrowingRequestDetails bookBorrowingRequestDetails);
        Task<BookBorrowingRequestDetails> UpdateBookBorrowingRequestDetails(BookBorrowingRequestDetails bookBorrowingRequestDetails);

        Task<BookBorrowingRequestDetails> DeleteBookBorrowingRequestDetails(int id);
    }
}