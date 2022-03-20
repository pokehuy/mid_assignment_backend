using mid_assignment_backend.Entities;

namespace mid_assignment_backend.Repositories
{
    public interface IBookBorrowingRequestRepository
    {
        Task<BookBorrowingRequest> GetBookBorrowingRequestById(int id);
        Task<List<BookBorrowingRequest>> GetAllBookBorrowingRequests();
        Task<BookBorrowingRequest> UpdateBookBorrowingRequest(BookBorrowingRequest bookBorrowingRequest);
        Task<BookBorrowingRequest> CreateBookBorrowingRequest(BookBorrowingRequest bookBorrowingRequest);
        Task<BookBorrowingRequest> DeleteBookBorrowingRequest(int id);
    }
}